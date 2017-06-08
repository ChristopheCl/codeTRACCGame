using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region UITLEG SCRIPT
/* volgt de player */
#endregion

public class CameraFollow : MonoBehaviour
{
    public GameObject player;

    private float deltaX;
    private float cameraY;
    private float cameraZ;
    public float deltaY;

    public bool isFollowing;    
    
	void Start ()
    {
        deltaX = Mathf.Abs(player.transform.position.x - transform.position.x);
        cameraY = transform.position.y;
        cameraZ = transform.position.z;
        isFollowing = true;
	}

    void FixedUpdate()
    {
        SetCameraPosition();
        YFollow();
    }

    void SetCameraPosition()
    {
        if(isFollowing)
        {
            transform.position = new Vector3(player.transform.position.x + deltaX, cameraY, cameraZ);
        }
    }

    void YFollow()
    {
        if(player.transform.position.y < transform.position.y - deltaY)
        {
            cameraY = player.transform.position. y + deltaY;
        }
        else if (player.transform.position.y > transform.position.y + deltaY)
        {
            cameraY = player.transform.position.y - deltaY;
        }
    }
}
