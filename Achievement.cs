using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Achievement
{
    private string name;
    private string description;
    private bool unlocked;
    private int points;
    private int spriteIndex;
    //private GameObject achievementRef;

    public Achievement()
    {
        unlocked = false;
    }

    public bool EarnAchievement()
    {
        if(!unlocked)
        {
            //achievementRef.GetComponent<Image>().sprite = AchievementManager.Instance.unlockedSprite;
            unlocked = true;
            return true;
        }
        return false;
    }

}
