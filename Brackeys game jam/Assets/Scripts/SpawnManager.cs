using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject platformPrefab;
    public float zSpawn =0;
    public float platformLength = 15f;
    public Transform player;
    public int numberOfPlatformOnScene = 5;

    List<GameObject> activePlatform = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < numberOfPlatformOnScene; i++)
        {
            SpawnPlatform();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(player.position.z - 20 > zSpawn -( numberOfPlatformOnScene * platformLength))
        {
            SpawnPlatform();
            DeletePlatform();
        }
    }

    void SpawnPlatform()
    {
        GameObject go =  Instantiate(platformPrefab, transform.forward * zSpawn, Quaternion.identity);
        activePlatform.Add(go);
        zSpawn += platformLength;
    }
    void DeletePlatform()
    {
        Destroy(activePlatform[0]);
        activePlatform.RemoveAt(0);
    }
}
