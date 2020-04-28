using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
   
    public GameObject objectToSpawn;

    void Start()
    {
      
        InvokeRepeating("SpawnObject", 0f, 4f);
    }
   
    void SpawnObject()
    {
        Instantiate(objectToSpawn, new Vector3(-10.0f, 30f, 0), Quaternion.identity);
    }
}
