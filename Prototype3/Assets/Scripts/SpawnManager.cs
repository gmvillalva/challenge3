using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPosition = new Vector3(20, 0, 0);
    private float startDelay = 2;
    private float repeat = 2;
    private playerControl playerControlScript;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeat);
        playerControlScript = GameObject.Find("Player").GetComponent<playerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        if (playerControlScript.gameOver == false)
        {
            Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation);
        }
        
    }
}
