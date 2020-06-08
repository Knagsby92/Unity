using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Cube : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] public float movementSpeed = 5f;
    [SerializeField] float speedfactor = 3000f;
    [SerializeField] float rotationSpeed = 2.5f;
   
    [SerializeField] float jumpHeight;
    bool jump;
    [SerializeField] LayerMask Ground;
    float moveHorizontal;
    float moveVertical;
    float mouseHorizontal;
    bool isGrounded;
    Coroutine jumpingCorutine;
    Coroutine changingTrackCorutine;

    [SerializeField] TouchInput tInput;
    private Vector3 startPos;

    public int track = 0;
    [SerializeField] float trackDistance = 2f;
    [SerializeField] float slideSpeed = 2f;
    [SerializeField] private float jumpAcceleration;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;
    }

    private void Update()
    { 
        jump = tInput.DoubleTap;

        if (tInput.SwipeRight)
            moveHorizontal = 1;
        else if (tInput.SwipeLeft)
            moveHorizontal = -1;
        else
            moveHorizontal = 0;

     
        if (Physics.Raycast(transform.position, Vector3.down, 0.6f))
        {
            if (jump && jumpingCorutine == null)
            {
                jumpingCorutine = StartCoroutine(Jump());
            }
        }
        else if (jumpingCorutine == null)
        {
            jumpingCorutine = StartCoroutine(Fall());
        }

        if (moveHorizontal > 0.2)
        {
            if (changingTrackCorutine == null)
            {
                changingTrackCorutine = StartCoroutine(ChangeTrack(1));
            }
        }

        if (moveHorizontal < -0.2)
        {
            if (changingTrackCorutine == null)
            {
                changingTrackCorutine = StartCoroutine(ChangeTrack(-1));
            }
        }

        
        SpeedIncrease();
    }

    public void SpeedIncrease()
    {
        movementSpeed += Time.timeSinceLevelLoad / speedfactor;
    }

    IEnumerator Jump()
    {
        Vector3 startPos = transform.position;
        while (transform.position.y < startPos.y + jumpHeight)
        {
            transform.Translate(Vector3.up * jumpAcceleration * Time.fixedDeltaTime * Time.fixedDeltaTime);
            yield return null;
        }
        jumpingCorutine = null;
    }

    IEnumerator Fall()
    {
        Vector3 startPos = transform.position;
        while (!Physics.Raycast(transform.position, Vector3.down, 0.6f))
        {
            transform.Translate(-Vector3.up * jumpAcceleration * Time.fixedDeltaTime * Time.fixedDeltaTime);
            yield return null;
        }
        jumpingCorutine = null;
    }

    IEnumerator ChangeTrack(int value)
    {
        if (track + value > 1 || track + value < -1)
        {
            changingTrackCorutine = null;
            yield break;
        }

        track += value;
        Vector3 startPos = transform.position;

        while (Mathf.Abs(transform.position.x - (startPos.x + 1 * trackDistance * value)) > 0.1f)
        {
            transform.Translate(Vector3.right * slideSpeed * value * Time.fixedDeltaTime);
            yield return null;
        }
        changingTrackCorutine = null;
    }
}
