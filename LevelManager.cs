using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#region UITLEG SCRIPT
/* respawn code voor naar recentse checkpoint */
#endregion

public class LevelManager : MonoBehaviour
{
    //public Vector3 spawnPosition;
    public Transform spawnPosition;
    public Transform playerTransform;

    //respawn
    private CameraFollow camera;
    private PlayerController player;
    public GameObject currentCheckpoint;
    public GameObject currentChekpointChecker;
    public float respawnDelay;
    private SpawnCars spawnCarsScript;
    private BusSpawn busSpawnScript;
    private SpawnCoins spawnCoinsScript;

    public Image fillLives;

   // public GameObject CurrentCheckpoint { get { return currentCheckpoint; } }

    private void Start()
    {
        camera = FindObjectOfType<CameraFollow>();
        player = FindObjectOfType<PlayerController>();
        spawnCarsScript = FindObjectOfType<SpawnCars>();
        busSpawnScript = FindObjectOfType<BusSpawn>();
        spawnCoinsScript = FindObjectOfType<SpawnCoins>();
    }

    public void RespawnPlayer()
    {
        StartCoroutine("RespawnPlayerCo");
    }

    public IEnumerator RespawnPlayerCo()
    {
        //playerTransform.GetComponent<Renderer>().enabled = false;
        playerTransform.gameObject.SetActive(false);
        camera.isFollowing = false;

        if (currentCheckpoint == currentChekpointChecker)
        {
            player.resetSpeedToBegin();
        }
        else
        {
            player.runSpeed = player.NewSpeed;
            player.animationWalkSpeed = player.NewAnimationWalkSpeed;
        }        

        spawnCarsScript.RespawnCars();
        // Debug.Log("spawncars");
        busSpawnScript.RespawnBus();
        //coins adden
        spawnCoinsScript.RespawnCoins();


        LifeManager.TakeLife();
        fillLives.fillAmount -= 0.34f;
        //Debug.Log("Player Respawn");
        yield return new WaitForSeconds(respawnDelay);

        playerTransform.transform.position = currentCheckpoint.transform.position;
        //playerTransform.GetComponent<Renderer>().enabled = true;
        playerTransform.gameObject.SetActive(true);
        camera.isFollowing = true;
    }
}
