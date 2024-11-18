using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionSpawnFish : MonoBehaviour
{

    public CollectionCount collectionCount;
    public List<GameObject> spawnList;
    public List<GameObject> spawnedFish;
    public GameObject water;

    private void Start()
    {
        //SpawnAllFish();
    }

    private void OnEnable()
    {
        Invoke("SpawnAllFish", 0.1f);
    }

    public void SpawnAllFish()
    {
        //SpawnFish(3);
        int i = 0;
        int x = 0;
        foreach (GameObject fish in spawnList)
        {
            x = collectionCount.GetFish(i);
            Debug.Log("Fishid " + fish.name + " Has " + x + " Fish in collection");
            
            for (int a = 0; a < x; a++)
            {
                //Debug.Log("Spawning fish " + i);
                SpawnFish(fish);
            }
            i++;
        }
        Debug.Log("Done");
    }

    /*public void SpawnFish(int fishID)
    {

        //Debug.Log("Spawning fish " + spawnList[fishID].name);
        float spawnXLocation = Random.Range(-12, -2);
        float spawnYLocation = Random.Range(-2, 1);
        float spawnZLocation = Random.Range(-2, 3);


        spawnedFish.Add(Instantiate(spawnList[fishID], new Vector3(spawnXLocation, spawnYLocation, spawnZLocation), spawnList[fishID].transform.rotation, this.transform));
    }*/

    public void SpawnFish(GameObject fishID)
    {

        //Debug.Log("Spawning fish " + fishID.name);
        float spawnXLocation = Random.Range(-12, -2);
        float spawnYLocation = Random.Range(-10, 0);
        float spawnZLocation = Random.Range(-2, 3);

        GameObject hold = Instantiate(fishID, new Vector3(spawnXLocation, spawnYLocation, spawnZLocation), fishID.transform.rotation, this.transform);
        hold.GetComponent<MoveFishCollection>().water = water;
        spawnedFish.Add(hold);

        
    }

    public void Close()
    {
        foreach (GameObject fish in spawnedFish)
        {
            Destroy(fish);
        }
        spawnedFish.Clear();
    }
}
