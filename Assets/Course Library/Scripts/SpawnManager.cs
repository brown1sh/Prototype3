using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;

    private PlayerController playerControllerScript;

    Vector3 spawnPos = new Vector3(25, 0, 0);

    private float delayTime = 2;
    private float repeatRate = 2;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>(); // set to reference of playerController script.

        InvokeRepeating("SpawnObstacle", delayTime, repeatRate); // keep undertaking the code in SpawnObstacles over a set time
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        // if the game is not over
        if (playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation); // create an obstacle
        }
    }
}
