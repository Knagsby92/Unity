using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{   
    public float movementSpeed = 5f;
    public float speedfactor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.forward * Time.deltaTime * movementSpeed;
        movementSpeed += Time.timeSinceLevelLoad / speedfactor;
    }
}
