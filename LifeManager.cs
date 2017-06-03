using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    protected static int lifeCounter;
    public int startingLives;
    protected Text text;

    public PlayerController player;
    public GameObject gameOverScreen;
   // public string levelToLoadAfterDead;
    public float waitAfterGameOver;

    private GameObject[] coins;

    LevelManager levelManager;

    //herstart
    private CameraFollow camera;
    private SpawnCars spawnCarsScript;

    public Transform cloudGenerator;
    private Vector3 cloudStartPoint;

    private Vector3 playerStartPoint;

    public GameObject DeathScreen;

    CloudDestroyer[] cloudList;

    void Start()
    {
        camera = FindObjectOfType<CameraFollow>();
        spawnCarsScript = FindObjectOfType<SpawnCars>();
        lifeCounter = PlayerPrefs.GetInt("PlayerCurrentLives");        
        lifeCounter = startingLives;
        text = GetComponent<Text>();
        player = FindObjectOfType<PlayerController>();
        //coins = GetComponent<GameObject>.tag

        cloudStartPoint = cloudGenerator.position;
        playerStartPoint = player.transform.position;
    }

    void Update()
    {
        if (lifeCounter <= 0)
        {
            gameOverScreen.SetActive(true);
            Reset();
            //Debug.Log("DEEEEAAAD + lives " + lifeCounter);
        }

        text.text = "lives: x " + lifeCounter;
    }

    public void GiveLife()
    {
        lifeCounter++;
        PlayerPrefs.SetInt("PlayerCurrentLives", lifeCounter);
    }

    public static void TakeLife()
    {
        lifeCounter--;
        PlayerPrefs.SetInt("PlayerCurrentLives", lifeCounter);
    }

    public static void ResetLife()
    {
        lifeCounter = 0;
        //lifeCounter = startingLives;
        PlayerPrefs.SetInt("PlayerCurrentLives", lifeCounter);
    }


    public void Reset()
    {
        player.gameObject.SetActive(false);
        camera.isFollowing = false;        

        player.runSpeed = 7f;
        player.animationWalkSpeed = 1f;
        spawnCarsScript.RespawnCars();

        cloudList = FindObjectsOfType<CloudDestroyer>();
        for (int i = 0; i < cloudList.Length; i++)
        {
            cloudList[i].gameObject.SetActive(false);
        }

        player.transform.position = playerStartPoint;
        cloudGenerator.position = cloudStartPoint;

        PlayerPrefs.DeleteKey("Building");
        ScoreManager.ResetScore();
        ResetLife();
    }
}
