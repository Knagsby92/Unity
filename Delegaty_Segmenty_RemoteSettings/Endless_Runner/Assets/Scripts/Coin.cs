using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour
{
    GameController gameController;
    private void Start()
    {
        gameController = GameController.Instance;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameController.IncreasePoints();
        }
        gameObject.SetActive(false);
    }
}
