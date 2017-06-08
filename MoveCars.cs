using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCars : MonoBehaviour {

    public float speed;
    public float distToCar;
	
	// Update is called once per frame
	void Update () {
        float distance = Mathf.Abs(Camera.main.transform.position.x - transform.position.x);
        if (distance < distToCar)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
    }
}
