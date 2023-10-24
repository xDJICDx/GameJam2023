using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class Snailmove : MonoBehaviour
{
    public GameObject Snail;
    private Vector2 XZPosition;
    private float xPos;
    private float yPos;
    public Rigidbody2D rigidbody;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float Velocity = 1f;

    // Start is called before the first frame update
    void Start()
    {
        minX = -4f;
        maxX = 4f;
        minY = -4f;
        maxY = 4f;
        newLocation();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x == xPos && transform.position.y == yPos)
        {
            newLocation();
        }
        XZPosition = new Vector2(transform.position.x, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(xPos,yPos), Velocity * Time.deltaTime);

    }
    
    void newLocation()
    {

        xPos = Random.Range(minX, maxX);
        yPos = Random.Range(minY, maxY);
    }
}
