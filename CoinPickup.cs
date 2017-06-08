using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#region UITLEG SCRIPT
/* er zijn verschillende coins voor elk gedeelte in het spel (gebouw)
 * elke coin verzameling unlocked een gebouw in bezienswaardigheden menu (zie bezienswaardigheden menu en achievement unlock script)
 * wanneer player in aanraking komt met de coin wordt er een punt bij geteld */
#endregion

public class CoinPickup : MonoBehaviour
{    
    public int scoreToAdd;
   
    void Update()
    {
        transform.Rotate(0, 50 * Time.deltaTime, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            string soortCoin = this.name;

            switch (soortCoin)
            {
                case "BraboCoin":
                    ScoreManager.AddPoints(1, "BraboCoin");
                    //Debug.Log("Score BRABO + 1 SCORE IS " + PlayerPrefs.GetInt("BraboScore"));
                    break;
                case "kmskaCoin":
                    ScoreManager.AddPoints(1, "kmskaCoin");
                    //Debug.Log("Score MUSEUM + 1 SCORE IS " + PlayerPrefs.GetInt("KMSKAScore"));
                    break;
                case "masCoin":
                    ScoreManager.AddPoints(1, "masCoin");
                    //Debug.Log("Score MAS + 1 SCORE IS " + PlayerPrefs.GetInt("MASScore"));
                    break;
                case "gate15Coin":
                    ScoreManager.AddPoints(1, "gate15Coin");
                    //Debug.Log("Score GATE15 + 1 SCORE IS " + PlayerPrefs.GetInt("Gate15Score"));
                    break;
            }

            AudioManager.instance.PlaySound("Collect", transform.position);
            // Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
}
