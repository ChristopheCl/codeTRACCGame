using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
