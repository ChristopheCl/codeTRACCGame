using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementUnlock : MonoBehaviour
{
    public GameObject[] buidingsLocked;
    public GameObject[] buidingsUnlocked;

    private AchievementManager achievementManager;

    private int[] scores;

    private void Start()
    {
        //Debug.Log("dgzezgf gezufhhh  " + scores[2] + scores[3]);
        //scores[0] = (int)PlayerPrefs.GetInt("BraboScore");
        //scores[1] = (int)PlayerPrefs.GetInt("KMSKAScore");
        //scores[2] = (int)PlayerPrefs.GetInt("MASScore");
        //scores[3] = (int)PlayerPrefs.GetInt("Gate15Score");
    }

    void Update ()
    {
       AchievementUnlocked();
	}

    private void AchievementUnlocked()
    {
        //if (scores[0] >= 5 || scores[1] >= 5 || scores[2] >= 5 || scores[3] >= 5)
        //{
            //switch (achievementManager.Building)
            switch (PlayerPrefs.GetString("Building"))
            {
                case "brabo":
                    buidingsLocked[0].SetActive(false);
                    buidingsUnlocked[0].SetActive(true);
                    break;
                case "kmska":
                    buidingsLocked[1].SetActive(false);
                    buidingsUnlocked[1].SetActive(true);
                    break;
                case "mas":
                    buidingsLocked[2].SetActive(false);
                    buidingsUnlocked[2].SetActive(true);
                    break;
                case "gate15":
                    buidingsLocked[3].SetActive(false);
                    buidingsUnlocked[3].SetActive(true);
                    break;
            }
        //}
    }
}
