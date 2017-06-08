using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#region UITLEG SCRIPT
/* informatie weeergeven van het gebouw dat je hebt gewonnen */
#endregion

public class BezienswaardigheidUitleg : MonoBehaviour
{
    public GameObject uitlegPrefab;
    public Sprite[] buildingSprites;
    public Text bezienswaardigheidInfo;

    private string building;
    private Text titel;
    private Image bezienswaardigheidImage;

   // private Animator anim;
    public GameObject pigeonTalkObj;



    void Start ()
    {
       building = this.name;
       titel = uitlegPrefab.transform.GetChild(4).GetComponentInChildren<Text>();
       bezienswaardigheidImage = uitlegPrefab.transform.GetChild(1).GetComponent<Image>();
     //  anim = pigeonTalkObj.GetComponent<Animator>();
      
    }
	
    public void ShowBuildingStory()
    {
        //bool talking = false;
        uitlegPrefab.gameObject.SetActive(true);
       
        if (titel == null || bezienswaardigheidImage == null || bezienswaardigheidInfo == null)
        {
            Debug.Log("Maak titel object aan!");
        }
        else
        {
           // talking = true;
            switch (building)
            {
                case "Brabo unlocked":
                    titel.text = "Brabo - Grote Markt";
                    bezienswaardigheidImage.sprite = buildingSprites[0];
                    bezienswaardigheidInfo.text = "\nOp één van de bekendste plaatsen in het oude stadscentrum, bevindt zich een pareltje onder al het erfgoed van de stad. \n\nHet Brabofontein. De romeinse soldaat is misschien wel dé trots van de stad. Hij werpt een reuzenhand in een rivier en vormt zo meteen de naam van de stad.";
                    break;
                case "KMSKA unlocked":
                    titel.text = "KMSKA";
                    bezienswaardigheidImage.sprite = buildingSprites[1];
                    bezienswaardigheidInfo.text = "\nKunst heeft geen uitleg nodig, kunst raakt. Nog nooit was een museum zo intrigerend.  Voor alle die het Koninklijke museum voor schone kunsten betreden, aanschouwen de rijkdommen die ons mooie stadje aan kunst bezit. ";
                    break;
                case "MAS unlocked":
                    titel.text = "Museum aan de Stroom";
                    bezienswaardigheidImage.sprite = buildingSprites[2];
                    bezienswaardigheidInfo.text = "\nWat krijgt men als men een project opstart met de intentie (met als doel ) een stad in de verf te zetten en meer mensen aan te trekken? \n\nLaat ons het zeggen, het MAS.Een adembenemend gebouw gelegen aan het eilandje in Antwerpen.Het is meer dan een museum, het is een pakhuis op een prachtig paviljoen dat vraagt om bezocht te worden.Betreed helemaal gratis het wandelboulevard tot aan de tiende verdieping, en aanschouw het prachtige uitzicht van het eilandje, de stroom en de skyline van Antwerpen.";
                    break;
                case "Gate15 unlocked":
                    titel.text = "Gate15";
                    bezienswaardigheidImage.sprite = buildingSprites[3];
                    bezienswaardigheidInfo.text = "\nEen absolute must en een regelrechte nummer 1 op iedere student zijn of haar to do lijstje, is een bezoek aan Gate15.\n\nDit gloednieuwe centrum verrijkt onze stad en haar studenten met informatie over o.a het levendige studentenleven, varia aan studentenkoten en projecten, en misschien nog wel het belangrijkste, talloze ervaringen en ondersteuning.\n\nOok bijna afgestudeerden hebben baat aan een bezoekje aan Gate15. Adream helpt afgestudeerden namelijk met de volgende stap in hun leven.\n\nGate15 is dus dé perfecte plaats om als student een fantastische start te maken in deze grote mooie stad.";
                    break;

                default:
                    Debug.Log("Check waarden!");
                    break;
            }

            //anim.SetBool("isTalking", talking);
            ////anim.Play("");

        }
    }

    public void CloseBuildingStory()
    {
        uitlegPrefab.gameObject.SetActive(false);
    }   
}
