using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 15f;

    private PlayerController playerControllerScript;

    private float leftBound = -15f;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>(); // set reference to playerController script
    }

    // Update is called once per frame
    void Update()
    {
        // if the game isn't over
        if(playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed); // move gameobject left
        }
        // if obstacle gameobject goes off screen
        if(gameObject.transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject); // destroy it
        }
    }
}
