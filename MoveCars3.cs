using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCars3 : MonoBehaviour {

    public float speed;
    private LevelManager levelManager;
    public float distToCar;
    void Start () {
        
        levelManager = FindObjectOfType<LevelManager>();
    }
	
	
	void Update () {
        float distance = Mathf.Abs(Camera.main.transform.position.x - transform.position.x);
        if (distance < distToCar)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
       

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Pigeon")
        {
            Debug.Log("coll");  
            levelManager.RespawnPlayer();
        }
    }
}
