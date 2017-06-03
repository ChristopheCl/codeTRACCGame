using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToLevel : MonoBehaviour {

    public string goToLevel;
    public GameObject bezienswaardigheden;

    private previousScene previousScene;

    private void Start()
    {
        //bezienswaardigheden = GameObject.Find("bezienswaardighedenTest");
    }

    public void GoToALevel()
    {
        if(goToLevel == "level3")
        {
            previousScene.ChangeScene(goToLevel);
            ScoreManager.ResetScore();
        }
        else if (this.name == "Terug")
        {
            previousScene.LoadLastScene();
        }
        else
        {
            previousScene.ChangeScene(goToLevel);
        }       
    }

    public void Quit()
    {
        PlayerPrefs.DeleteKey("Building");
        Application.Quit();       
    }

    public void bezienswaardighedenOn()
    {
        bezienswaardigheden.SetActive(true);
    }

    public void bezienswaardighedenOff()
    {
        bezienswaardigheden.SetActive(false);
    }

}
