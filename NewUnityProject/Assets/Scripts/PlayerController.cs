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
        if (GameControl.instance.lifes > 0) {
            movePlayer();
        } else {
            rb.velocity = Vector3.zero;
        }
        
    }

    void OnCollisionEnter (Collision other)
    {
        if (other.gameObject.tag == "Enemy") {
            GameControl.instance.takeDamage ();
        }
    }

    void movePlayer()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.1f, moveVertical);
        rb.velocity = movement * speed;

        rb.position = new Vector3 (
            Mathf.Clamp(rb.position.x, boundery.xMin, boundery.xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, boundery.zMin, boundery.zMax)
        );
    }
}
