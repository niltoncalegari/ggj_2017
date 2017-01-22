using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotScript : MonoBehaviour {

    public float speed;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.velocity = transform.forward * speed;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy") {
            Destroy (other.gameObject);
            Destroy (gameObject);
        }

        if (other.gameObject.tag == "Border") {
            Destroy (gameObject);
        }
    }

}
