using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSpawnController : MonoBehaviour
{
    public GameObject collectibleObject;
    public int spawnAmount;
    public Transform[] spawnSpots;

    // Start is called before the first frame update
    void Start()
    {
        if (spawnAmount > spawnSpots.Length) 
        {
            throw new System.Exception("Spawn amount is more than spawn spots defined");
        } 
        else
        {
            Transform[] randomizedSpawnSpots = RandomizeSpawnSpots();
            
            foreach (var spot in randomizedSpawnSpots)
            {   
                GameObject collectible = Instantiate(collectibleObject, spot.position, spot.rotation);
            }
        }
    }
    
    private Transform[] RandomizeSpawnSpots()
    {
        List<Transform> resultList = new();
        List<Transform> tmpList = new();
        tmpList.AddRange(spawnSpots);

        while (resultList.Count != spawnAmount)
        {
            int index = Random.Range(0, tmpList.Count);
            resultList.Add(tmpList[index]);
            tmpList.RemoveAt(index);
        }
        return resultList.ToArray();
    }
}
