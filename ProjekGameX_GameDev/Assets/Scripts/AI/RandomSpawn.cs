using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    float minDistance = 40.0f;
    float maxDistance = 60.0f;
    public Transform playerTransform;

    float maxTime = 5f;
    float timer;


    void Start()
    {
        timer = maxTime;

    }

    public void RandomSpawnNearPlayer(float distanceMin, float distanceMax)
    {
        float distance = Random.Range(minDistance, maxDistance);
        float angle = Random.Range(-Mathf.PI, Mathf.PI);
        Vector3 spawnValues = new Vector3(60, 0, 60);

        Vector3 spawnPosition = playerTransform.position;
        spawnPosition += new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * distance;
        spawnPosition.x = Mathf.Clamp(spawnPosition.x, -spawnValues.x, spawnValues.x);
        spawnPosition.y = spawnValues.y;
        spawnPosition.z = Mathf.Clamp(spawnPosition.z, -spawnValues.z, spawnValues.z);
        this.transform.position = spawnPosition;
    }
}
