using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailController : MonoBehaviour
{
    public Transform startPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name=="Girl")
        {
            other.transform.position = startPoint.position;
        }
    }
}
