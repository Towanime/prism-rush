using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summon : MonoBehaviour {
    public PlayerInput input;
    public GameObject prefab;
    private GameObject[] spawnPoints;

    void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("Spawn");
    }
    
    public void SummonEnemy()
    {
        int index = Random.Range(0, spawnPoints.Length - 1);
        spawnPoints[index].GetComponent<Spawner>().Spawn(prefab);
    }

}
