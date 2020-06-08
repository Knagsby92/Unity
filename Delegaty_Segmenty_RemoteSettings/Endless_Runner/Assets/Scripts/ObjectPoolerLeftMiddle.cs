using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolerLeftMiddle : MonoBehaviour
{
    public List<GameObject> pooledObjectsLeftMiddle;
    public GameObject objectToPoolLeftMiddle;
    public int amountToPool;
    public static ObjectPoolerLeftMiddle Instance;

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        pooledObjectsLeftMiddle = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject objnew = (GameObject)Instantiate(objectToPoolLeftMiddle);
            GameObject objnew1 = (GameObject)Instantiate(objectToPoolLeftMiddle);
            GameObject objnew2 = (GameObject)Instantiate(objectToPoolLeftMiddle);
            objnew.SetActive(false);
            objnew1.SetActive(false);
            objnew2.SetActive(false);
            pooledObjectsLeftMiddle.Add(objnew);
            pooledObjectsLeftMiddle.Add(objnew1);
            pooledObjectsLeftMiddle.Add(objnew2);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public GameObject GetPooledObjectLeftMiddle()
    {
        //1
        for (int i = 0; i < pooledObjectsLeftMiddle.Count; i++)
        {
            //2
            if (!pooledObjectsLeftMiddle[i].activeInHierarchy)
            {
                return pooledObjectsLeftMiddle[i];
            }
        }
        //3   
        return null;
    }
}
