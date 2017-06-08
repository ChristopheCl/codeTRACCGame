using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region UITLEG SCRIPT
/* zet wolk inactief wanneer deze niet meet in beeld is in de game*/
#endregion

public class CloudDestroyer : MonoBehaviour
{
    public GameObject cloudDestructionPoint;

	void Start ()
    {
        cloudDestructionPoint = GameObject.Find("CloudDestructionPoint");
	}
	
	void Update ()
    {
		if(transform.position.x < cloudDestructionPoint.transform.position.x)
        {
            gameObject.SetActive(false);
        }
	}
}
