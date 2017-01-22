using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

	public Transform goal;
	public GameObject enemy;
	private NavMeshAgent nav;

	void Start ()
	{
		if (enemy == null) {
			enemy = GameObject.Find ("Enemy");
		}
		nav = GetComponent<NavMeshAgent> ();
	}

	void Update ()
	{
		
		enemy.transform.rotation = Quaternion.Euler (90f, 0f, 0f);
		//if (Input.GetKeyDown (KeyCode.Space)) {
			setGoal ();
		//}
	}

	void setGoal ()
	{
		
		nav.SetDestination (goal.position);
	}
}
