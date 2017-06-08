using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#region UITLEG SCRIPT
/* houd punten bij
 * voegt punt toe wanneer men een bepaalde coin verzameld (verschillende coins voor elk gebouw) */
#endregion

public class ScoreManager : MonoBehaviour
{
    public static int braboScore;
    public static int masScore;
    public static int kmskaScore;
    public static int gate15Score;
   //public static Text scoreText;
    public Image[] imgScore;
    public Sprite[] spriteScore;

    void Start()
    {
        braboScore = PlayerPrefs.GetInt("BraboScore");
        masScore = PlayerPrefs.GetInt("MASScore");
        kmskaScore = PlayerPrefs.GetInt("KMSKAScore");
        gate15Score = PlayerPrefs.GetInt("Gate15Score");
       // scoreText = GetComponent<Text>();

        PlayerPrefs.SetInt("BraboScore", 0);
        PlayerPrefs.SetInt("MASScore", 0);
        PlayerPrefs.SetInt("KMSKAScore", 0);
        PlayerPrefs.SetInt("Gate15Score", 0);
        ResetScore();
    }

    void Update()
    {
        changeScore();
        checkScore();
        //Debug.Log("UPDATE " + score + "UPDATE TEXT " + scoreText.text);
    }

    public void checkScore()
    {
        if (braboScore >= 5)
        {
            imgScore[0].sprite = spriteScore[0];
        }
        if (gate15Score >= 5)
        {
            imgScore[3].sprite = spriteScore[3];
        }
        if (masScore >= 5)
        {
            imgScore[1].sprite = spriteScore[1];
        }
        if (kmskaScore >= 5)
        {
            imgScore[2].sprite = spriteScore[2];
        }
    }

    public static void changeScore()
    {
        if (braboScore < 0 || masScore < 0 || kmskaScore < 0 || gate15Score < 0)
        {
            braboScore = 0;
            masScore = 0;
            kmskaScore = 0;
            gate15Score = 0;
        }
    }

    public static void AddPoints(int pointsToAdd, string soortCoin)
    {
        switch (soortCoin)
        {
            case "BraboCoin":
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
        braboScore = 0;
        masScore = 0;
        kmskaScore = 0;
        gate15Score = 0;

        PlayerPrefs.SetInt("BraboScore", braboScore);
        PlayerPrefs.SetInt("MASScore", masScore);
        PlayerPrefs.SetInt("KMSKAScore", kmskaScore);
        PlayerPrefs.SetInt("Gate15Score", gate15Score);

       // PlayerPrefs.DeleteKey("Building");

        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");

        for (int i = 0; i < coins.Length; i++)
        {
            coins[i].SetActive(true);
        }
    }
}
