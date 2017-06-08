using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#region UITLEG SCRIPT
/* het maken van een achievement (in dictionary)
 * deze weergeven in het spel wanneer genoeg punten verzameld 
 * en melding weergeven waneer men deze gewonnen heeft*/
#endregion

public class AchievementManager : MonoBehaviour
{
    public GameObject[] visualAchievement;
    public Dictionary<string, Achievement> achievements = new Dictionary<string, Achievement>();
    public GameObject[] buildingsLocked;
    public GameObject[] buildingsUnlocked;

    private void Awake()
    {
        CreateAchievement("BraboAchievement");
        CreateAchievement("MASAchievement");
        CreateAchievement("KMSKAAchievement");
        CreateAchievement("Gate15Achievement");
    }

    //void Start()
    //{
    //    CreateAchievement("MarktAchievement");
    //    CreateAchievement("MASAchievement");
    //    CreateAchievement("KMSKAAchievement");
    //    CreateAchievement("Gate15Achievement");

    //    // PlayerPrefs.GetString("Building");
    //}

    private void FixedUpdate()
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
        achievement.transform.localScale = new Vector3(2.5f, 2.5f, 1);
    }

    public void EarnAchievement(string title)
    {
        if (achievements[title].EarnAchievement())
        {
            switch (title)
            {
                case "MASAchievement":
                    AchievementInstantiate(1);
                    break;
                case "KMSKAAchievement":
                    AchievementInstantiate(2);
                    break;
                case "Gate15Achievement":
                    AchievementInstantiate(3);
                    break;
                case "BraboAchievement":
                    AchievementInstantiate(0);
                    break;
            }
        }
    }

    public void AchievementInstantiate(int spriteNumber)
    {
        GameObject achievement = (GameObject)Instantiate(visualAchievement[spriteNumber]);
        SetAchievementInfo("EarnCanvas", achievement);
        StartCoroutine(HideAchievement(achievement));
        Debug.Log("ACHIEVEMENT BORN!!!!" + achievement);
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
            EarnAchievement("BraboAchievement");
            buildingsLocked[0].SetActive(false);
            buildingsUnlocked[0].SetActive(true);
        }
        else if (PlayerPrefs.GetInt("KMSKAScore") >= 5)
        {
            EarnAchievement("KMSKAAchievement");
            buildingsLocked[1].SetActive(false);
            buildingsUnlocked[1].SetActive(true);
        }
        else if (PlayerPrefs.GetInt("MASScore") >= 5)
        {
            EarnAchievement("MASAchievement");
            buildingsLocked[2].SetActive(false);
            buildingsUnlocked[2].SetActive(true);
        }
        else if (PlayerPrefs.GetInt("Gate15Score") >= 5)
        {
            EarnAchievement("Gate15Achievement");
            buildingsLocked[3].SetActive(false);
            buildingsUnlocked[3].SetActive(true);
        }
    }

}
