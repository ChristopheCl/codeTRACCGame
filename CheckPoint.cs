using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region UITLEG SCRIPT
/* er zijn checkpoints bij elke gedeelte (gebouw) van het spel. 
 * wordt opgeslagen wanneer player er voorbij komt
 * player verliest een leven > wordt gespawned naar recentste checkpoint */
#endregion

public class CheckPoint : MonoBehaviour {

    private LevelManager levelManager;
   // private PlayerController playerControllerScript;

	void Start ()
    {
        levelManager = FindObjectOfType<LevelManager>();
        //playerControllerScript = FindObjectOfType<PlayerController>();
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            levelManager.currentCheckpoint = gameObject;
            //playerControllerScript.runSpeed = 
           // Debug.Log("Activated Checkpoint" + transform.position);
            //Wanneer je een nieuw checkpoint in je scene zet en je "gebruikt" deze dan wordt deze geactiveerd en de pos. wordt weergegeven.
        }


    }
}
