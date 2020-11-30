using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour
{
    private float minX, maxX;

    void Start()
    {
        SetMinAndMax();
    }

    // this script restricts the player to go out of the screen
    void Update()
    {
        if(transform.position.x < minX) // not allowing the player to move more left than minX
        {
            Vector3 temp = transform.position;
            temp.x = minX + 0.1f;
            transform.position = temp;
        }

        if (transform.position.x > maxX)    // not allowing the player to move more right than maxX
        {
            Vector3 temp = transform.position;
            temp.x = maxX - 0.1f;
            transform.position = temp;
        }
    }

    // setting the minX and maxX variables
    void SetMinAndMax()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        maxX = bounds.x - 0.5f;
        minX = -bounds.x + 0.5f;
    }
}
