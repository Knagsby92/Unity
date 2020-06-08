using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoinsLeft : MonoBehaviour
{
    [SerializeField] private GameObject Spawner;
    
    public void SpawnOnlyCoinsLeft()
    {
        GameObject Coin2 = ObjectPoolerLeftMiddle.Instance.GetPooledObjectLeftMiddle();
        if (Coin2 != null)
        {
            Coin2.transform.position = Spawner.transform.position + new Vector3(0, 0, 5);
            Coin2.transform.rotation = Spawner.transform.rotation;
            Coin2.SetActive(true);
        }
        GameObject Coin3 = ObjectPoolerLeftMiddle.Instance.GetPooledObjectLeftMiddle();
        if (Coin3 != null)
        {
            Coin3.transform.position = Spawner.transform.position + new Vector3(0, 0, 8);
            Coin3.transform.rotation = Spawner.transform.rotation;
            Coin3.SetActive(true);
        }
        GameObject Coin4 = ObjectPoolerLeftMiddle.Instance.GetPooledObjectLeftMiddle();
        if (Coin4 != null)
        {
            Coin4.transform.position = Spawner.transform.position + new Vector3(0, 0, 11);
            Coin4.transform.rotation = Spawner.transform.rotation;
            Coin4.SetActive(true);
        }
        
    }

    private void Start()
    {
       InvokeRepeating("SpawnLeft", 3f,5f);
    }

   public void SpawnLeft()
    {
        
        SpawnOnlyCoinsLeft();

    }
}
