using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Spawner : MonoBehaviour
{
    public List<GameObject> tile;
    public GameObject tile1Obj;
    public Vector3 nextTileSpawn;
    public int limit = 20;
   
    private float randX;
    
  

    [SerializeField] float timeToSpawnNextTile = 2f;
    void Start()
    {
          tile = new List<GameObject>();
    nextTileSpawn.z = 48.92f;
        StartCoroutine(SpawnTile());
    }

    
    void Update()
    {
        
    }
    IEnumerator SpawnTile()
    {
       
        yield return new WaitForSeconds(timeToSpawnNextTile);
        float[] myRandoms = new float[] { -2.5f, 0f, 3.3f };
        float randX = Random.Range(-2.5f, myRandoms.Length);


        
        GameObject transform= Instantiate(tile1Obj, nextTileSpawn,Quaternion.identity );
       
        tile.Add(transform);

        nextTileSpawn.z += 48.92f;
        StartCoroutine(SpawnTile());
        CheckSpawnedCount();
    }
    void CheckSpawnedCount()
    {
        if (tile.Count > limit)
        {
            GameObject gameObjectToRemove = tile[0];
            tile.Remove(gameObjectToRemove);
            Destroy(gameObjectToRemove);
        }
    }
}
