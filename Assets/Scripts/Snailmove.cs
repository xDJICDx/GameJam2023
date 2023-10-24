using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class Snailmove : MonoBehaviour
{
    public GameObject Player;
    private float xPos;
    private float yPos;
    public Rigidbody2D rigidbody;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float Velocity = 1f;
    public float range = 0.2f;
    public bool snailGettingChased = false;
    public float ChaseRanege = 1f;
    public bool FirstLocation = false;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        Velocity = 1f;
        minX = -4.7f;
        maxX = 4.8f;
        minY = -3f;
        maxY = 3f;

    }

    // Update is called once per frame
    void Update()
    {
        if (!snailGettingChased)
        {
            if(!FirstLocation || 
                transform.position.x > xPos - range && transform.position.x < xPos + range &&
                transform.position.y > yPos - range && transform.position.y < yPos + range) 
            {
                newLocation();
                FirstLocation = true;
            }
            seeekLocation();
        }

        if(Player.transform.position.x - range > transform.position.x && 
           Player.transform.position.x + range < transform.position.x &&
           Player.transform.position.y - range > transform.position.y &&
           Player.transform.position.y + range < transform.position.y) 
        {
            Debug.Log("close to player");
        }
        else
        {
            Debug.lo
        }

    }
    
    void seeekLocation()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(xPos, yPos), Velocity * Time.deltaTime);
        var direction = transform.position - new Vector3(xPos, yPos, 0);
        transform.up = direction * -1;
    }
    
    void newLocation()
    {
        xPos = Random.Range(minX, maxX);
        yPos = Random.Range(minY, maxY);
    }
}
