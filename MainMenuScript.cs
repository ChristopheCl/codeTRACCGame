using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {

    public string levelToLoad = "LevelSelector";
    public string level1Tag;

	// Use this for initialization
	public void Play () {
        PlayerPrefs.SetInt(level1Tag, 1);
        //SceneManager.LoadScene(levelToLoad);
        Application.LoadLevel(levelToLoad);
        
	}
	
	// Update is called once per frame
	public void Quit ()
    {
        Application.Quit();	
	}
}
