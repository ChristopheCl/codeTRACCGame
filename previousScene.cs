using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#region UITLEG SCRIPT
/* onthoud vorige scene die open was*/
#endregion

public class previousScene : MonoBehaviour {

    static string lastScene;
    static string currentScene;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public static void ChangeScene(string sceneName)
    {
        lastScene = currentScene;
        currentScene = sceneName;
        Application.LoadLevel(currentScene);
    }

    public void LoadLastScene()
    {
        string last = lastScene;
        lastScene = currentScene;
        currentScene = last;
        Application.LoadLevel(currentScene);
    }
}
