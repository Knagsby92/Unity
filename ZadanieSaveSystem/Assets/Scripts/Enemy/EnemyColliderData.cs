using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColliderData : MonoBehaviour
{
    public EnemyController controller;
    private bool isPlayerInReach = false;
    public bool IsPlayerInReach()
    {
        return isPlayerInReach;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            isPlayerInReach = true;
            controller.SetTarget(other.gameObject.GetComponent<PlayerController3D>());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            isPlayerInReach = false;
            controller.ResetTarget();
        }
    }
}
