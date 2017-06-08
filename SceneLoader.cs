using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#region UITLEG SCRIPT
/* laadscherm voordat men spel kan spelen*/
#endregion

public class SceneLoader : MonoBehaviour
{
    private bool loadScene = false;

    [SerializeField]
    private int scene;
    [SerializeField]
    private Text loadingText;

    void Update()
    {
        if (loadScene == false)
        {
            loadScene = true;
            loadingText.text = "Laden...";
            StartCoroutine(LoadNewScene());
        }

        if (loadScene == true)
        {
            loadingText.color = new Color(loadingText.color.r, loadingText.color.g, loadingText.color.b, Mathf.PingPong(Time.time, 1));
        }
    }

    IEnumerator LoadNewScene()
    {
        yield return new WaitForSeconds(3);
        AsyncOperation async = Application.LoadLevelAsync(scene);
        ScoreManager.ResetScore();
        PlayerPrefs.DeleteKey("Building");

        while (!async.isDone)
        {
            yield return null;
        }
    }

}
