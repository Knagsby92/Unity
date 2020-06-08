using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRight : MonoBehaviour
{

    [SerializeField] private GameObject Spawner;
   
    public void SpawnCoin()
    {
        GameObject Coin = ObjectPooler.Instance.GetPooledObject();
        if (Coin != null)
        {
            Coin.transform.position = Spawner.transform.position + new Vector3(0, 0, 5);
            Coin.transform.rotation = Spawner.transform.rotation;
            Coin.SetActive(true);
        }
        GameObject Coin1 = ObjectPooler.Instance.GetPooledObject();
        if (Coin1 != null)
        {
            Coin1.transform.position = Spawner.transform.position + new Vector3(0, 0, 8);
            Coin1.transform.rotation = Spawner.transform.rotation;
            Coin1.SetActive(true);
        }
        GameObject Cube = ObjectPooler.Instance.GetPooledObject();
        if (Cube != null)
        {
            Cube.transform.position = Spawner.transform.position + new Vector3(0, 0, 11);
            Cube.transform.rotation = Spawner.transform.rotation;
            Cube.SetActive(true);
        }
        
    }

    private void Start()
    {
        InvokeRepeating("SpawnerCoins", 7f, 4f);
    }

    public void SpawnerCoins()
    {
        
        SpawnCoin();
       
    }
    
}
