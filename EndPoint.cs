using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#region UITLEG SCRIPT
/* stop camera aan het einde van het spel en laat endscreen zien met de info zien (gespeelde tijd + verzamelde coins) */
#endregion

public class EndPoint : MonoBehaviour
{
    private CameraFollow cameraScript;
    private static bool ended;

    public Text braboText, masText, kmskaText, gate15Text, tijdText, timerText;
    public GameObject endScreen;

    public static bool Ended { get { return ended; } set { ended = value; } }

    private void Awake()
    {
        Ended = false;
    }

    void Start ()
    {
        cameraScript = Camera.main.GetComponent<CameraFollow>();
    }
	
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Ended = true;
            cameraScript.isFollowing = false;
            endScreen.SetActive(true);
            showResults();
        }
    }

    private void showResults()
    {
        braboText.text = PlayerPrefs.GetInt("BraboScore").ToString() +"/5";
        masText.text = PlayerPrefs.GetInt("MASScore").ToString() + "/5";
        kmskaText.text = PlayerPrefs.GetInt("KMSKAScore").ToString() +"/5";
        gate15Text.text = PlayerPrefs.GetInt("Gate15Score").ToString() + "/5";
        tijdText.text = timerText.text;
    }
}
