using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BezienswaardigheidUitleg : MonoBehaviour
{
    public GameObject uitlegPrefab;
    public Sprite[] buildingSprites;
    public Text bezienswaardigheidInfo;

    private string building;
    private Text titel;
    private Image bezienswaardigheidImage;


    void Start ()
    {
       building = this.name;
       titel = uitlegPrefab.transform.GetChild(4).GetComponentInChildren<Text>();
       bezienswaardigheidImage = uitlegPrefab.transform.GetChild(1).GetComponent<Image>();
    }
	
    public void ShowBuildingStory()
    {
        uitlegPrefab.gameObject.SetActive(true);

        if(titel == null || bezienswaardigheidImage == null || bezienswaardigheidInfo == null)
        {
            Debug.Log("Maak titel object aan!");
        }
        else
        {
            switch (building)
            {
                case "Brabo":
                    titel.text = "Brabo - Grote Markt";
                    bezienswaardigheidImage.sprite = buildingSprites[0];
                    bezienswaardigheidInfo.text = "Brabo Info";
                    break;
                case "KMSKA":
                    titel.text = "KMSKA";
                    bezienswaardigheidImage.sprite = buildingSprites[1];
                    bezienswaardigheidInfo.text = "KMSKA Info";
                    break;
                case "MAS":
                    titel.text = "Museum aan de Stroom";
                    bezienswaardigheidImage.sprite = buildingSprites[2];
                    bezienswaardigheidInfo.text = "MAS Info";
                    break;
                case "Gate15":
                    titel.text = "Gate15";
                    bezienswaardigheidImage.sprite = buildingSprites[3];
                    bezienswaardigheidInfo.text = "Gate15 Info";
                    break;

                default:
                    Debug.Log("Check waarden!");
                    break;
            }
        }       
    }

    public void CloseBuildingStory()
    {
        uitlegPrefab.gameObject.SetActive(false);
    }   
}
