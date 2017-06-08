using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#region UITLEG SCRIPT
/* bepaalt naar welke level je gaat wanneer je op een knop klikt */
#endregion

public class GoToLevel : MonoBehaviour
{

    public string goToLevel;
    public GameObject bezienswaardigheden;
    public GameObject pigeonTalkObj;
    public GameObject endscreen;

    private previousScene previousScene;

    public void GoToALevel()
    {
        if (goToLevel == "level3")
        {
            ScoreManager.ResetScore();
            previousScene.ChangeScene(goToLevel);            
        }
        else if(goToLevel == "Main Menu")
        {
            previousScene.ChangeScene(goToLevel);
            GameObject[] unlocked = GameObject.FindGameObjectsWithTag("unlocked");
            GameObject[] locked = GameObject.FindGameObjectsWithTag("locked");

            for (int i = 0; i < unlocked.Length; i++)
            {
                unlocked[i].SetActive(false);
            }

            for (int i = 0; i < locked.Length; i++)
            {
                unlocked[i].SetActive(true);
            }
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
        if(pigeonTalkObj.active == false)
        {
            pigeonTalkObj.SetActive(true);
        }
        
    }

    public void bezienswaardighedenOff()
    {
        bezienswaardigheden.SetActive(false);
        if (pigeonTalkObj.active == true)
        {
            pigeonTalkObj.SetActive(false);
        }
    }
}
