using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {

    private LevelManager levelManager;

	void Start ()
    {
        levelManager = FindObjectOfType<LevelManager>();
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            levelManager.currentCheckpoint = gameObject;
           // Debug.Log("Activated Checkpoint" + transform.position);
            //Wanneer je een nieuw checkpoint in je scene zet en je "gebruikt" deze dan wordt deze geactiveerd en de pos. wordt weergegeven.
        }
    }
}
