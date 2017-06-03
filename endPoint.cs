using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endPoint : MonoBehaviour {


    public string nextLevel = "LevelSelector2";
    public int levelToUnlock = 2;

    //lvlSelector 2
    public string levelTag;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("test1");
        if (other.transform.tag == "Player")
        {
            WinLevel();
        }
    }

    public void WinLevel()
    {
        Debug.Log("endLevel to next level");
        PlayerPrefs.SetInt(levelTag, 1);

        Application.LoadLevel(nextLevel);
    }
}
