using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region UITLEG SCRIPT
/* voegt wolken toe aan een lijst die uiteindelijk worden gespawned
 * worden inactief gezet wanneer buiten scherm
 * worden terug actief gezet wanneer nodig */
#endregion

public class ObjectPooler : MonoBehaviour
{
    public GameObject pooledObject;
    public int pooledAmount;

    List<GameObject> pooledObjects;

	void Start ()
    {
        pooledObjects = new List<GameObject>();

        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(pooledObject);
            obj.SetActive(false);
            pooledObjects.Add(obj);            
        }
	}
	
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if(!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        GameObject obj = (GameObject)Instantiate(pooledObject);
        obj.SetActive(false);
        pooledObjects.Add(obj);

        return obj;
    }
}
