using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region UITLEG SCRIPT
/* Maken van een achievement object*/
#endregion

public class Achievement : MonoBehaviour
{ 
    private bool unlocked;

    public Achievement()
    {
        unlocked = false;
    }

    public bool EarnAchievement()
    {
        if (!unlocked)
        {
            unlocked = true;
            return true;
        }
        return false;
    }
}
