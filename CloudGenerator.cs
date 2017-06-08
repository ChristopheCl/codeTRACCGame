using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region UITLEG SCRIPT
/* er worden wolken gegeneert op random hoogte en diepte
 * er wordt gebruik gemaakt van empty gameobject in de game > daar worden wolken gespawned */
#endregion

public class CloudGenerator : MonoBehaviour
{
    //public GameObject[] theClouds;
    public GameObject theCloud;
    public Transform generationPoint;
    public float distanceBetween;

    private float cloudWidth;

    public float distanceBetweenMin;
    public float distanceBetweenMax;

    private int cloudSelector;
    private float[] cloudWidths;

    public ObjectPooler[] theObjectPools;

    private float minHeight, minDepth;
    public Transform maxHeightPoint, maxDepthPoint;
    private float maxHeight, maxDepth;
    public float maxHeightChange, maxDepthChange;
    private float heightChange, DepthChange;

    void Start ()
    {
        //cloudWidth = theCloud.GetComponent<Renderer>().bounds.size.x;
        cloudWidths = new float[theObjectPools.Length];

        for (int i = 0; i < theObjectPools.Length; i++)
        {
            cloudWidths[i] = theObjectPools[i].pooledObject.GetComponent<Renderer>().bounds.size.x;
        }

        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;

        minDepth = transform.position.z;
        maxDepth = maxDepthPoint.position.z;
    }
	
	void Update ()
    {
		if(transform.position.x < generationPoint.position.x)
        {
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);
            cloudSelector = Random.Range(0, theObjectPools.Length);

            heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);
            DepthChange = transform.position.z + Random.RandomRange(maxDepthChange, -maxDepthChange);

            if(heightChange > maxHeight)
            {
                heightChange = maxHeight;
            }
            else if(heightChange < minHeight)
            {
                heightChange = minHeight;
            }

            if (DepthChange > maxDepth)
            {
                DepthChange = maxDepth;
            }
            else if (DepthChange < minDepth)
            {
                DepthChange = minDepth;
            }

            //transform.position = new Vector3(transform.position.x + (cloudWidths[cloudSelector] / 2) + distanceBetween, heightChange, transform.position.z);
            transform.position = new Vector3(transform.position.x + (cloudWidths[cloudSelector] / 2) + distanceBetween, heightChange, DepthChange);
            //Instantiate(/*theCloud*/ theClouds[cloudSelector], transform.position, transform.rotation);

            GameObject newCloud = theObjectPools[cloudSelector].GetPooledObject();
            newCloud.transform.position = transform.position;
            newCloud.transform.rotation = transform.rotation;
            newCloud.SetActive(true);

            transform.position = new Vector3(transform.position.x + (cloudWidths[cloudSelector] / 2), transform.position.y, transform.position.z);
        }
	}
}
