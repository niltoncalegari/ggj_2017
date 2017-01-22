using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {

    public Transform goal;
       
    void Start ()
    {
        
    }

    void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            setGoal();
        }
    }

    void setGoal()
    {
        gameObject.GetComponent<NavMeshAgent> ().SetDestination(goal.position);
    }
}
