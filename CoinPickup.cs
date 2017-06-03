using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinPickup : MonoBehaviour
{
    public int scoreToAdd;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            string soortCoin = this.name;

            switch (soortCoin)
            {
                case "BraboCoin":
                    ScoreManager.AddPoints(1, "braboCoin");
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

            // Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
}
