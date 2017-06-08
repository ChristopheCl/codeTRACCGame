using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#region UITLEG SCRIPT
/* timer in het spel, houd bij hoe lang je erover doet om het spel uit te spelen */
#endregion

public class GameTimer : MonoBehaviour
{
    public Text timerText;
    private float secondsCount;
    private int minuteCount;
    //private int hourCount;

    void Update()
    {
        if(EndPoint.Ended == false)
        {
            UpdateTimerUI();
        }     
    }

    public void UpdateTimerUI()
    {
        //set timer UI
        secondsCount += Time.deltaTime;
        timerText.text = /*hourCount + "h:" + */minuteCount + "m:" + (int)secondsCount + "s";
        if (secondsCount >= 60)
        {
            minuteCount++;
            secondsCount = 0;
        }
        else if (minuteCount >= 60)
        {
            //hourCount++;
            minuteCount = 0;
        }
    }
}
