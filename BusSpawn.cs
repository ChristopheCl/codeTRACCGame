using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusSpawn : MonoBehaviour {

    List<Vector3> busPosition;
    List<Quaternion> busRotation;

    Dictionary<int, string> indexWithCoin;
    Dictionary<string, GameObject> coinNames;
    public float yPosCoin = 0.04f;

    //add all bus prefabs
    [SerializeField]
    private GameObject busPrefab;

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

        //make a new list for saving the bus
        busPosition = new List<Vector3>();
        busRotation = new List<Quaternion>();
        indexWithCoin = new Dictionary<int, string>();
        coinNames = new Dictionary<string, GameObject>();
        coinNames.Add("gate15Coin", gate15CoinPrefab);
        coinNames.Add("BraboCoin", braboCoinPrefab);
        coinNames.Add("masCoin", masCoinPrefab);
        coinNames.Add("kmskaCoin", kmskaCoinPrefab);

        //add all current bus child transforms to this list
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            busPosition.Add(gameObject.transform.GetChild(i).position);
            busRotation.Add(gameObject.transform.GetChild(i).rotation);

            if (coinNames.ContainsKey(gameObject.transform.GetChild(i).GetChild(0).name))
            {
                indexWithCoin.Add(i, gameObject.transform.GetChild(i).GetChild(0).name);
            }
        }
    }


    public void RespawnBus()
    {
        
        //save the child count in a variable
        int childrenCount = gameObject.transform.childCount;
        //Debug.Log(transform.GetChild(0).gameObject);


        for (int i = 0; i < childrenCount; i++)
        {

            //destroy the current children of this gameobject
            Destroy(transform.GetChild(i).gameObject);



            //instantiate the bus, in the position of the saved list and make it child of this object
            GameObject busSpawned = Instantiate(busPrefab, busPosition[i], busRotation[i], transform);

            if (indexWithCoin.ContainsKey(i))
            {
                Vector3 pos = new Vector3(0, yPosCoin, 0);
                // pos, Quaternion.identity,
                Instantiate(coinNames[indexWithCoin[i]], busSpawned.transform);
            }
        }


    }

}
