using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentMovement : MonoBehaviour
{
    // odwołanie do agenta
    public NavMeshAgent agent;
    // odniesienie do Animatora
    public Animator anim;


    private bool canMove = true;
   
    void Update()
    {
        anim.SetBool("isMoving", agent.hasPath);
    }
    // Przesuwanie się Agenta z punktu do punktu
    public void MoveToPoint(Vector3 pos)
    {
        if (canMove)
        {
            agent.SetDestination(pos);
        }
    }
    public void SetPosition(Vector3 pos)
    {
        agent.Warp(pos);
    }
    public void StopMoving()
    {
        agent.isStopped = true; // turn off moving
        agent.ResetPath(); // path between agent and end point
    }
    public void Die()
    {
        canMove = false;
    }
}
