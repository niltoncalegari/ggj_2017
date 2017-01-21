using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundery
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

    public float speed = 4f;
    public Boundery boundery;

    private Rigidbody rb;

    void Start () {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate () {
        
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.1f, moveVertical);
        //Debug.Log(movement);
        rb.velocity = movement * speed;

        rb.position = new Vector3 (
            Mathf.Clamp(rb.position.x, boundery.xMin, boundery.xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, boundery.zMin, boundery.zMax)
        );

        //rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -tilt);
    }
}
