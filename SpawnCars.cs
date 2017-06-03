using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCars : MonoBehaviour
{
    List<Vector3> carsPosition;
    List<Quaternion> carsRotation;

    //add all car prefabs
    [SerializeField]
    private GameObject carPrefab1;

    [SerializeField]
    private GameObject carPrefab2;

    [SerializeField]
    private GameObject carPrefab3;

    void Start()
    {

        //make a new list for saving the cars
        carsPosition = new List<Vector3>();
        carsRotation = new List<Quaternion>();

        //add all current car child transforms to this list
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            carsPosition.Add(gameObject.transform.GetChild(i).position);
            carsRotation.Add(gameObject.transform.GetChild(i).rotation);
        }

        //for testing purposes, to be called from the pigeon's kill
        RespawnCars();
    }



    public void RespawnCars()
    {
        //save the child count in a variable
        int childrenCount = gameObject.transform.childCount;
        Debug.Log(transform.GetChild(0).gameObject);

        
        for (int i = 0; i < childrenCount; i++)
        {
            
            //destroy the current children of this gameobject
            Destroy(transform.GetChild(i).gameObject);

            //get a random car to spawn
            GameObject carToSpawn = GetRandomCar();

            //instantiate the random car, in the position of the saved list and make it child of this object
            Instantiate(carToSpawn, carsPosition[i], carsRotation[i], transform);
        }


    }

    public GameObject GetRandomCar()
    {
        int rndNumber = Random.Range(1, 4);
       // Debug.Log(rndNumber);
        GameObject randomCar;

        switch (rndNumber)
        {
            case 1:
                randomCar = carPrefab1;
                break;

            case 2:
                randomCar = carPrefab2;
                break;

            case 3:
                randomCar = carPrefab3;
                break;
            default:
                randomCar = carPrefab1;
                break;
        }
        //get random car prefab and return it
        return randomCar;
    }
}
