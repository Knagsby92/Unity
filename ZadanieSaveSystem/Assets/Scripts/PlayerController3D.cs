using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController3D : MonoBehaviour
{
    private Animator anim;
    private Vector3 destination; // mouse pos
    private GameObject target;
    public AgentMovement movement;
    private bool isApproachingTarget = false; // is going to target?
    private bool isAttacking = false;
    public float moveDistance = 8f;

    // Stats
    public Stats stats;
    public bool isAlive = true;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Move();
            StopAttacking();
        }
        if (isApproachingTarget)
        {
            MoveToTarget();
        }
        if (isAttacking)
        {
            FaceToTarget();
        }
    }
    public void Move()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // ray between camera and mouse pos in game
        RaycastHit hit; // data of ray

        if(Physics.Raycast(ray, out hit)) // true if is game object
        {
            destination = hit.point;
            if (hit.collider.transform.tag.Equals("Ground"))
            {
                movement.MoveToPoint(destination); // move to point
                isApproachingTarget = false;
            }
            else if (hit.collider.transform.tag.Equals("Enemy"))
            {
                target = hit.collider.gameObject;
                isApproachingTarget = true;
            }
        }

    }
    public void SetPosition(Vector3 pos)
    {
        movement.SetPosition(pos);
    }
    public void Hit()
    {
        if (target!= null)
        {
            EnemyController enemy = target.GetComponent<EnemyController>();
            if (enemy != null)
            {
                if (enemy.GetHit(stats.attack))
                {
                    StopAttacking();
                    target = null;
                }
            }
        }
    }
    public void StartAttacking()
    {
        if (!isAttacking)
        {
            isAttacking = true;
            anim.SetBool("isAttacking", isAttacking);
        }
    }
    public void StopAttacking()
    {
        if (isAttacking)
        {
            isAttacking = false;
            anim.SetBool("isAttacking", isAttacking);
        }
    }
    public bool GetHit(float value)
    {
        stats.health -= value;
        if (stats.health <= 0)
        {
            isAlive = false;
            StopAttacking();
            anim.SetBool("isAlive", isAlive);
            return true;
        }
        return false;
    }
    private void FaceToTarget()
    {
        Vector3 lookPos = target.transform.position - transform.position;
        lookPos.y = 0;

        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.75f);
    }
    // if is target, get close
    public void MoveToTarget()
    {
        if (target != null)
        {
            float distance = Vector3.Distance(transform.position, target.transform.position);

            if (distance >= moveDistance)
            {
                movement.MoveToPoint(target.transform.position);
            }
            else
            {
                movement.StopMoving();
                if (target.tag.Equals("Enemy"))
                {
                    StartAttacking();
                    isApproachingTarget = false;
                }
            }
        }
    }
}
