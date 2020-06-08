using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    private List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public GameObject objectToPool1;
    public GameObject objectToPool2;
    public int amountToPool;
    public static ObjectPooler Instance;

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = (GameObject)Instantiate(objectToPool);
            GameObject obj2 = (GameObject)Instantiate(objectToPool1);
            GameObject obj3 = (GameObject)Instantiate(objectToPool2);
            obj.SetActive(false);
            obj2.SetActive(false);
            obj3.SetActive(false);
            pooledObjects.Add(obj);
            pooledObjects.Add(obj2);
            pooledObjects.Add(obj3);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject GetPooledObject()
    {
        //1
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            //2
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        //3   
        return null;
    }
}
