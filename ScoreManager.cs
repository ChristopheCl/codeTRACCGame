using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int braboScore;
    public static int masScore;
    public static int kmskaScore;
    public static int gate15Score;
    public static Text scoreText;

    void Start ()
    {
        //score = PlayerPrefs.GetInt("CurrentPlayerScore");
        braboScore = PlayerPrefs.GetInt("BraboScore");
        masScore = PlayerPrefs.GetInt("MASScore");
        kmskaScore = PlayerPrefs.GetInt("KMSKAScore");
        gate15Score = PlayerPrefs.GetInt("Gate15Score");
        scoreText = GetComponent<Text>();
        //score = 0;      
        PlayerPrefs.SetInt("BraboScore", 0);
        PlayerPrefs.SetInt("MASScore", 0);
        PlayerPrefs.SetInt("KMSKAScore", 0);
        PlayerPrefs.SetInt("Gate15Score", 0);
        ResetScore();
	}

	void Update ()
    {
        changeScore();
        //Debug.Log("UPDATE " + score + "UPDATE TEXT " + scoreText.text);
    }

    public static void changeScore() //NOG VERANDEREN
    {
        if (braboScore < 0 || masScore < 0 || kmskaScore < 0 || gate15Score < 0)
        {
            braboScore = 0;
            masScore = 0;
            kmskaScore = 0;
            gate15Score = 0;
        }

        scoreText.text = "score: " + gate15Score; //ALLE SOORTEN SCORE TOEVOEGEN! sprite laten zien alles verzameld?
        //Debug.Log("SCORE CHANGED! + SCORE: " + score);
    }

    public static void AddPoints(int pointsToAdd, string soortCoin)
    {
        switch (soortCoin)
        {
            case "braboCoin":
                braboScore += pointsToAdd;
                PlayerPrefs.SetInt("BraboScore", braboScore);
                break;
            case "masCoin":
                masScore += pointsToAdd;
                PlayerPrefs.SetInt("MASScore", masScore);
                break;
            case "kmskaCoin":
                kmskaScore += pointsToAdd;
                PlayerPrefs.SetInt("KMSKAScore", kmskaScore);
                break;
            case "gate15Coin":
                gate15Score += pointsToAdd;
                PlayerPrefs.SetInt("Gate15Score", gate15Score);
                break;
        }        
    }

    public static void ResetScore()
    {
        //score = 0;
        braboScore = 0;
        masScore = 0;
        kmskaScore = 0;
        gate15Score = 0;
        //PlayerPrefs.SetInt("CurrentPlayerScore", score);
        PlayerPrefs.SetInt("BraboScore", braboScore);
        PlayerPrefs.SetInt("MASScore", masScore);
        PlayerPrefs.SetInt("KMSKAScore", kmskaScore);
        PlayerPrefs.SetInt("Gate15Score", gate15Score);
    }
}
