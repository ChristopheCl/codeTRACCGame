using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AchievementManager : MonoBehaviour
{
    public GameObject[] visualAchievement;
    public Dictionary<string, Achievement> achievements = new Dictionary<string, Achievement>();

    string building = "";

    public string Building
    {
        get { return building; }

        set { building = value; }
    }

    void Start ()
    {
        CreateAchievement("Brabo");
        CreateAchievement("MAS");
        CreateAchievement("KMSKA");
        CreateAchievement("Gate15");
        //Debug.Log("BRABO = " + PlayerPrefs.GetInt("BraboCoins")  + " KMSKA = " + PlayerPrefs.GetInt("KMSKACoints") + "\nMAS = " + PlayerPrefs.GetInt("MASCoins") + " GATE15 = " + PlayerPrefs.GetInt("Gate15Coins"));

        PlayerPrefs.GetString("Building");
    }

    void Update()
    {
        BuildingWinCheck();
    }

    public void CreateAchievement(string title)
    {
        Achievement newAchievement = new Achievement();
        achievements.Add(title, newAchievement);
    }

    public void SetAchievementInfo(string categorie, GameObject achievement)
    {
            achievement.transform.SetParent(GameObject.Find(categorie).transform);
            achievement.transform.localScale = new Vector3(2, 2, 1);        
    }

    public void EarnAchievement(string title)
    {
        if (achievements[title].EarnAchievement())
        {
            switch (title)
            {
                case "Brabo":
                    AchievementInstantiate(0);
                    //building = "brabo";
                    PlayerPrefs.SetString("Building", "brabo");
                    break;
                case "MAS":
                    AchievementInstantiate(1);
                    //building = "mas";
                    PlayerPrefs.SetString("Building", "mas");
                    break;
                case "KMSKA":
                    AchievementInstantiate(2);
                    //building = "kmska";
                    PlayerPrefs.SetString("Building", "kmska");
                    break;
                case "Gate15":
                    AchievementInstantiate(3);
                    //building = "gate15";
                    PlayerPrefs.SetString("Building", "gate15");
                    break;
            }
        }
    }

    public void AchievementInstantiate(int spriteNumber)
    {
        GameObject achievement = (GameObject)Instantiate(visualAchievement[spriteNumber]);
        SetAchievementInfo("EarnCanvas", achievement);
        StartCoroutine(HideAchievement(achievement));
    }

    public IEnumerator HideAchievement(GameObject achievement)
    {
        yield return new WaitForSeconds(3);
        Destroy(achievement);
    }

    public void BuildingWinCheck()
    {
        if (PlayerPrefs.GetInt("BraboScore") >= 5)
        {
            EarnAchievement("Brabo");
            //building = "brabo";
            PlayerPrefs.SetString("Building", "brabo");
        }
        else if (PlayerPrefs.GetInt("KMSKAScore") >= 5)
        {
            EarnAchievement("KMSKA");
            //building = "kmska";
            PlayerPrefs.SetString("Building", "kmska");
        }
        else if (PlayerPrefs.GetInt("MASScore") >= 5)
        {
            EarnAchievement("MAS");
            //building = "mas";
            PlayerPrefs.SetString("Building", "mas");
        }
        else if (PlayerPrefs.GetInt("Gate15Score") >= 5)
        {
            EarnAchievement("Gate15");
            //building = "gate15";
            PlayerPrefs.SetString("Building", "gate15");
        }
        //return building;
    }

}
