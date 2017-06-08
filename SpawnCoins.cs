using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoins : MonoBehaviour {

    List<Vector3> coinsPosition;
    List<Quaternion> coinsRotation;
    
    Dictionary<string, GameObject> coinNames;

    List<string> coinName;
    

    [SerializeField]
    private GameObject gate15CoinPrefab;

    [SerializeField]
    private GameObject braboCoinPrefab;

    [SerializeField]
    private GameObject masCoinPrefab;

    [SerializeField]
    private GameObject kmskaCoinPrefab;

    void Start()
    {
        //make a new list for saving the cars
        coinsPosition = new List<Vector3>();
        coinsRotation = new List<Quaternion>();
        
        coinNames = new Dictionary<string, GameObject>();
        coinNames.Add("gate15Coin", gate15CoinPrefab);
        coinNames.Add("BraboCoin", braboCoinPrefab);
        coinNames.Add("masCoin", masCoinPrefab);
        coinNames.Add("kmskaCoin", kmskaCoinPrefab);


        coinName = new List<string>();
        //coins spawner
        //dictionary name/prefab object
        //list name 
        //list invullen in for lus (zie cars) 
        //list.add(child object name) 
        //save position + rotation

        //spawne
        //string name = list[i];
        //--> gameobject prefabToSpawn = dictionary[name]
        //--> instantiate --> under coins parent




        //add all current car child transforms to this list
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            coinsPosition.Add(gameObject.transform.GetChild(i).position);
            coinsRotation.Add(gameObject.transform.GetChild(i).rotation);
            //Debug.Log(gameObject.transform.GetChild(i).GetChild(0).name);
            coinName.Add(gameObject.transform.GetChild(i).name);
            
        }

    }



    public void RespawnCoins()
    {
        Debug.Log("respawnCoins");
        
        //save the child count in a variable
        int childrenCount = gameObject.transform.childCount;
        //Debug.Log(transform.GetChild(0).gameObject);


        for (int i = 0; i < childrenCount; i++)
        {

            //destroy the current children of this gameobject
            Destroy(transform.GetChild(i).gameObject);
            string name = coinName[i];
            GameObject prefabToSpawn = coinNames[name];
            Debug.Log(prefabToSpawn.name);
            Instantiate(prefabToSpawn, coinsPosition[i], coinsRotation[i], transform);

        }


    }
}
