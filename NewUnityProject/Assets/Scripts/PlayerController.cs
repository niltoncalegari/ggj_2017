using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Boundery
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

	public Sprite FullLife;
	public Sprite MidLife;
	public Sprite LowLife;
	public Sprite Vazio;
	public Text ButtonText;
	public float speed = 4f;
    public Boundery boundery;
	public GameObject lifebar;
    public float fireRate = 0.5f;
    public GameObject shot;
    public Transform shotSpawnU;
    public Transform shotSpawnD;
    public Transform shotSpawnL;
    public Transform shotSpawnR;

    private float nextFire = 0.0f;
    private Animator anim;
    private Rigidbody rb;

    void Start () {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator> ();
    }
    void FixedUpdate () {
        if (GameControl.instance.lifes > 0) {
            movePlayer();
        } else {
			GameControl.instance.DiePlayer (ButtonText);
			transform.position = new Vector3 (0f, 0.2f, 0f);
			Respawn ();
        }

    }
	public void Respawn(){
		GameControl.instance.getLife (3);
		UptadeSprite ();
	}

    void OnCollisionEnter (Collision other)
    {
        if (other.gameObject.tag == "Enemy") {
            GameControl.instance.takeDamage ();
			UptadeSprite ();
		}
    }
	void UptadeSprite(){
		if (GameControl.instance.lifes == 3) {
			lifebar.gameObject.GetComponent<Image> ().sprite = FullLife;
		} else if (GameControl.instance.lifes == 2) {
			lifebar.gameObject.GetComponent<Image> ().sprite = MidLife;
		} else if (GameControl.instance.lifes == 1) {
			lifebar.gameObject.GetComponent<Image> ().sprite = LowLife;
		} else if (GameControl.instance.lifes == 0) {
			lifebar.gameObject.GetComponent<Image> ().sprite = Vazio;
		}
	} 
    void movePlayer()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        anim.SetFloat("moveX", moveHorizontal);
        anim.SetFloat("moveY", moveVertical);

        Vector3 movement = new Vector3 (moveHorizontal, 0.1f, moveVertical);
        rb.velocity = movement * speed;

        rb.position = new Vector3 (
            Mathf.Clamp(rb.position.x, boundery.xMin, boundery.xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, boundery.zMin, boundery.zMax)
        );

        if (Input.GetKey(KeyCode.LeftArrow) && Time.time > nextFire) {
            nextFire = Time.time + fireRate;
            Instantiate (shot, shotSpawnL.position, shotSpawnL.rotation);
        }

        if (Input.GetKey(KeyCode.RightArrow) && Time.time > nextFire) {
            nextFire = Time.time + fireRate;
            Instantiate (shot, shotSpawnR.position, shotSpawnR.rotation);
        }

        if (Input.GetKey(KeyCode.UpArrow) && Time.time > nextFire) {
            nextFire = Time.time + fireRate;
            Instantiate (shot, shotSpawnU.position, shotSpawnU.rotation);
        }

        if (Input.GetKey(KeyCode.DownArrow) && Time.time > nextFire) {
            nextFire = Time.time + fireRate;
            Instantiate (shot, shotSpawnD.position, shotSpawnD.rotation);
        }

    }
}
