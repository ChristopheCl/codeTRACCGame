using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheat : MonoBehaviour
{

    public GameObject[] buidingsLocked;
    public GameObject[] buidingsUnlocked;

    public void buildingUnlock()
    {
        buidingsLocked[0].SetActive(false);
        buidingsUnlocked[0].SetActive(true);
        buidingsLocked[1].SetActive(false);
        buidingsUnlocked[1].SetActive(true);
        buidingsLocked[2].SetActive(false);
        buidingsUnlocked[2].SetActive(true);
        buidingsLocked[3].SetActive(false);
        buidingsUnlocked[3].SetActive(true);

        //Debug.Log("BRABO = " + PlayerPrefs.GetInt("BraboScore") + " MAS = " + PlayerPrefs.GetInt("MASScore") + " KMSKA = " + PlayerPrefs.GetInt("KMSKAScore") + " GATE15 = " + PlayerPrefs.GetInt("Gate15Score"));
    }
}
