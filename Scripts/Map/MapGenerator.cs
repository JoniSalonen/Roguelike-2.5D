using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [Header("Array for map fragments")]
    public GameObject[] mapFragments; // Array of map fragments

    [Header("Array for map fragment spawn points")]
    public Transform[] spawnPoints; // Array of spawn points for map fragments

    [Header("Map Object Locations")]
    public Transform[] mapObjectLocations;

    [Header("Shop locations")]
    public Transform[] shopLocations;

    [Header("Map Objects Generation")]
    public GameObject[] mapObjects; // Parent object for map fragments

    [Header("Map Rare Objects Generation")]
    public GameObject[] rareObjects; // Parent object for rare objects

    [Header("Store")]
    public GameObject[] store; // Store object

    private LoadingScreen loadingScreen; // Loading screen object

    private int maxLoadProgress;

    private int maxRareObjects;

    private bool rareSpawned = false;


    // Start is called before the first frame update
    void Start()
    {
        loadingScreen = GameObject.Find("LoadingScreen").GetComponent<LoadingScreen>(); // Get the loading screen object
        maxLoadProgress = spawnPoints.Length + mapObjectLocations.Length;
        loadingScreen.SetMaxLoad(maxLoadProgress);
        int storeLocation = Random.Range(0, shopLocations.Length);
        StartCoroutine(GenerateStore(storeLocation));
        RareObjectsChance();
        StartCoroutine(GenerateMap());
        StartCoroutine(GenerateMapObjects());
    }

    IEnumerator GenerateMap()
    {
        List<int> usedMapFramgentSpawnPoints = new List<int>(); // List to keep track of used spawn points

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            int randomSpawnPointIndex;
            do
            {
                randomSpawnPointIndex = Random.Range(0, spawnPoints.Length); // Generate a random spawn point index
            } while (usedMapFramgentSpawnPoints.Contains(randomSpawnPointIndex)); // Check if the spawn point has already been used

            usedMapFramgentSpawnPoints.Add(randomSpawnPointIndex); // Add the spawn point index to the used spawn points list

            Instantiate(mapFragments[Random.Range(0, mapFragments.Length)], spawnPoints[randomSpawnPointIndex]);
            loadingScreen.AddLoadProgress();
            yield return new WaitForSeconds(0f);
        }
    }

    IEnumerator GenerateMapObjects()
    {
        List<int> usedObjectSpawnsPoints = new List<int>();

        for (int i = 0; i < mapObjectLocations.Length; i++)
        {
            int randomObjectSpawnPointIndex;
            do
            {
                randomObjectSpawnPointIndex = Random.Range(0, mapObjectLocations.Length);
            } while (usedObjectSpawnsPoints.Contains(randomObjectSpawnPointIndex));

            usedObjectSpawnsPoints.Add(randomObjectSpawnPointIndex);

            
            if (rareSpawned)
            {
                Instantiate(mapObjects[Random.Range(0, mapObjects.Length)], mapObjectLocations[randomObjectSpawnPointIndex]);
                loadingScreen.AddLoadProgress();
                yield return new WaitForSeconds(0.1f);
            }
            else
            {
                StartCoroutine(GenerateRareObjects(randomObjectSpawnPointIndex));
                yield return new WaitForSeconds(0.1f);
            }

            loadingScreen.AddLoadProgress();
            yield return new WaitForSeconds(0.1f);

        }
    }
    

    IEnumerator GenerateStore(int spawnpoint)
    {
        Instantiate(store[0], shopLocations[spawnpoint]);
        loadingScreen.AddLoadProgress();
        yield return new WaitForSeconds(0.1f);
    }

    IEnumerator GenerateRareObjects(int spawnpoint)
    {
        if (maxRareObjects == 0)
        {
            rareSpawned = true;
            yield return new WaitForSeconds(0.1f);
        }
        else
        {
            Instantiate(rareObjects[Random.Range(0, rareObjects.Length)], mapObjectLocations[spawnpoint]);
            loadingScreen.AddLoadProgress();
            yield return new WaitForSeconds(0.1f);
            maxRareObjects--;
        } 
    }

    private void RareObjectsChance() 
    {
        int objectChance = Random.Range(0, 100);
        if (objectChance < 15)
        {
            maxRareObjects = Random.Range(0, (mapObjectLocations.Length / 5));
            rareSpawned = false;
            Debug.Log("Spawning rare objects!! :" + maxRareObjects);
        }
        else
        {
            maxRareObjects = 0;
            rareSpawned = true;
        }
        

    }
}

