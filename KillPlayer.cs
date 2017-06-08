using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region UITLEG SCRIPT
/* respawned player naar begin van het spel */
#endregion

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
            AudioManager.instance.PlaySound("Crash", transform.position);
        }
    }
}
