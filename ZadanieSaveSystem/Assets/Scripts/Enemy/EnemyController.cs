using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public AgentMovement movement;
    public PlayerController3D target;
    public bool isAttacking = false;
    public float moveDistance = 8f;

    public Animator anim;
    public EnemyColliderData colliderData;

    // Roaming
    public Vector3 startingPos;
    public float RoamDelay = 5f;
    public float RoamDistanceX = 5f;
    public float RoamDistanceZ = 5f;
    private float RoamTimer = 0;

    // Stats
    public Stats stats;
    public bool isAlive = true;
    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
        RoamTimer = Random.Range(0, RoamDelay);
    }
    public void SetTarget(PlayerController3D t)
    {
        target = t;
    }
    public void ResetTarget()
    {
        target = null;
    }
    private void Roam()
    {
        RoamTimer -= Time.deltaTime;
        if (RoamTimer <= 0f)
        {
            RoamTimer = RoamDelay;

            float newPosX = Random.Range(-RoamDistanceX, RoamDistanceX);
            float newPosZ = Random.Range(-RoamDistanceZ, RoamDistanceZ);

            Vector3 newPosition = new Vector3(startingPos.x + newPosX, 0, startingPos.z + newPosZ);
            movement.MoveToPoint(newPosition);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            if (colliderData.IsPlayerInReach())
            {
                float distance = Vector3.Distance(transform.position, target.transform.position);
                if (distance >= moveDistance)
                {
                    MoveToTarget();
                    StopAttacking();
                }
                else
                {
                    movement.StopMoving();
                    StartAttacking();
                }
                if (isAttacking)
                {
                    FaceToTarget();
                }
            }
            else
            {
                Roam();
            }
        }
    }
    private void FaceToTarget()
    {
        Vector3 lookPos = target.transform.position - transform.position;
        lookPos.y = 0;

        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.75f);
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
    public void MoveToTarget()
    {
        if(target != null)
        {
            movement.MoveToPoint(target.transform.position);
        }
    }
    public bool GetHit(float value)
    {
        stats.health -= value;
        if (stats.health <= 0)
        {
            Die();
            return true;
        }
        return false;
    }
    public void Die()
    {
        isAlive = false;
        StopAttacking();
        GetComponent<CapsuleCollider>().enabled = false;
        anim.SetBool("isAlive", isAlive);
    }
    public void Hit()
    {
        if (target != null)
        {
            if (target.GetHit(stats.attack))
            {
                StopAttacking();
            }
        }
    }
}
