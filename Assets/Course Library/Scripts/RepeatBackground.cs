using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position; // set startPos to the background's position upon opening the game

        repeatWidth = GetComponent<BoxCollider>().size.x / 2; // sets repeat width to half of the backgrounds size using a box collider for it's size
    }

    // Update is called once per frame
    void Update()
    {
        // if the backgrounds location reaches a certain point
        if(transform.position.x < (startPos.x - repeatWidth)) 
        {
            transform.position = startPos; // reset the background to it's start location
        }
    }
}
