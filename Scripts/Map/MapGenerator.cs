using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [Header("Array for map fragments")]
    public GameObject[] mapFragments; // Array of map fragments

    [Header("Array for spawn points")]
    public Transform[] spawnPoints; // Array of spawn points for map fragments

    [Header("Map Object Locations")]
    public Transform[] mapObjectLocations;

    [Header("Map Objects Generation")]
    public GameObject[] mapObjects; // Parent object for map fragments

    [Header("Store")]
    public GameObject[] store; // Store object

    private LoadingScreen loadingScreen; // Loading screen object

    private bool shopSpawned = false;

    private int maxLoadProgress;


    // Start is called before the first frame update
    void Start()
    {
        loadingScreen = GameObject.Find("LoadingScreen").GetComponent<LoadingScreen>(); // Get the loading screen object
        maxLoadProgress = spawnPoints.Length + mapObjectLocations.Length;
        loadingScreen.SetMaxLoad(maxLoadProgress);
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

        for(int i = 0; i < mapObjectLocations.Length; i++)
        {
            int randomObjectSpawnPointIndex;
            do
            {
                randomObjectSpawnPointIndex = Random.Range(0, mapObjectLocations.Length);
            }while (usedObjectSpawnsPoints.Contains(randomObjectSpawnPointIndex));

            usedObjectSpawnsPoints.Add(randomObjectSpawnPointIndex);

            if(shopSpawned){
                Instantiate(mapObjects[Random.Range(0, mapObjects.Length)], mapObjectLocations[randomObjectSpawnPointIndex]);
                loadingScreen.AddLoadProgress();
                yield return new WaitForSeconds(0.1f);
            }
            else
            {
                StartCoroutine(GenerateStore(randomObjectSpawnPointIndex));
                loadingScreen.AddLoadProgress();
                yield return new WaitForSeconds(0.1f);
            }
            loadingScreen.AddLoadProgress();
            yield return new WaitForSeconds(0.1f);
            
        }
    }

    IEnumerator GenerateStore(int spawnpoint)
    {
        Instantiate(store[0], mapObjectLocations[spawnpoint]);
        shopSpawned = true;
        yield return new WaitForSeconds(0.1f);
    }
}

