using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGPlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    Vector2 movement;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void GetInput()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
    }
    void Animate()
    {
        if (movement.magnitude > 0)
        {
            anim.SetFloat("X", movement.x);
            anim.SetFloat("Y", movement.y);
            anim.SetFloat("Velocity", movement.magnitude);
        }
    }
    // Update is called once per frame
    void Update()
    {
        GetInput();
        Animate();
    }
}
