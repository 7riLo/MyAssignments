/*
 * Levi Wyant
 * Prototype3
 * Moves background to give the player the illusion the background is always moving
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPosition;
    private float repeatWidth;

    // Start is called before the first frame update
    void Start()
    {
        //save the starting position of the background to a vector3 variable
        startPosition = transform.position;

        //set the repeatWidth to half of the width of the background using BoxCollider
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        //if background is farther to the left than repeat width, reset to start position
        if(transform.position.x < startPosition.x - repeatWidth)
        {
            transform.position = startPosition;
        }
    }
}
