using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    //score
    private int score = 0;

    //public Vector3 spawnPosition;
    public Transform spawnPosition;
    public Transform playerTransform;

    //respawn
    private CameraFollow camera;
    private PlayerController player;
    public GameObject currentCheckpoint;
    public float respawnDelay;
    private SpawnCars spawnCarsScript;

    private void Start()
    {
        camera = FindObjectOfType<CameraFollow>();
        player = FindObjectOfType<PlayerController>();
        spawnCarsScript = FindObjectOfType<SpawnCars>();
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
        player.runSpeed = 7f;
        player.animationWalkSpeed = 1f;
        spawnCarsScript.RespawnCars();

        LifeManager.TakeLife();
        //Debug.Log("Player Respawn");
        yield return new WaitForSeconds(respawnDelay);

        playerTransform.transform.position = currentCheckpoint.transform.position;
        //playerTransform.GetComponent<Renderer>().enabled = true;
        playerTransform.gameObject.SetActive(true);
        camera.isFollowing = true;
    }
}
