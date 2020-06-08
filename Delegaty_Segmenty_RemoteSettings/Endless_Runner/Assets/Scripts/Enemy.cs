using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

    GameController gameController;
    private void Start()
    {
        gameController = GameController.Instance;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            gameController.DecreaseLifes();
        else
        {
            gameObject.SetActive(false);
        }
    }
}
