using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    private LevelManager levelManager;

	void Start ()
    {
        levelManager = FindObjectOfType<LevelManager>();
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Pigeon")
        {
            levelManager.RespawnPlayer();
        }
    }
}
