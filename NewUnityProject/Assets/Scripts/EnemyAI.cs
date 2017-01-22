using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    private GameObject goal;
	//public GameObject enemy;
	private NavMeshAgent nav;

	void Awake ()
	{
        if (goal == null) {
            goal = GameObject.FindGameObjectWithTag ("Player");
		}
		nav = GetComponent<NavMeshAgent> ();
	}

	void Update ()
	{
        gameObject.transform.rotation = Quaternion.Euler (90f, 0f, 0f);
		setGoal ();
	}

	void setGoal ()
	{           
        nav.SetDestination (goal.transform.position);
	}
}
