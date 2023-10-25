using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class Snailmove : MonoBehaviour
{
    public ShopMechenics shopMechenics;
    public SnailSpawner spawner;
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
    public float ChaseRange = 2f;
    public bool FirstLocation = false;

    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("SnailSpawner").GetComponentInChildren<SnailSpawner>();
        shopMechenics = GameObject.FindGameObjectWithTag("ShopMechanics").GetComponentInChildren<ShopMechenics>();
        Player = GameObject.FindWithTag("Player");
        Velocity = 1f;
        minX = -4.7f;
        maxX = 4.8f;
        minY = -3f;
        maxY = 3f;
        transform.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

    }

    // Update is called once per frame
    void Update()
    {

        if(transform.position.x < -1f && transform.position.y > 3f) 
        {
            shopMechenics.SnailCaught();
            spawner.CurrentEntityCount--;
            Destroy(gameObject);
        }


        if (!snailGettingChased)
        {
            if(!FirstLocation || 
                transform.position.x > xPos - range && transform.position.x < xPos + range &&
                transform.position.y > yPos - range && transform.position.y < yPos + range) 
            {
                newLocation();
                FirstLocation = true;
            }
            seekLocation();
        }

        if(Player.transform.position.x > transform.position.x - ChaseRange && 
           Player.transform.position.x < transform.position.x + ChaseRange &&
           Player.transform.position.y > transform.position.y - ChaseRange &&
           Player.transform.position.y < transform.position.y + ChaseRange)
        {
            snailGettingChased = true;
            FirstLocation = false; 

            xPos = transform.position.x + (Player.transform.position.x - transform.position.x) * -1;
            yPos = transform.position.y + (Player.transform.position.y - transform.position.y) * -1;

            seekLocation();

        }
        else
        {
            snailGettingChased = false;
        }

    }
    
    void seekLocation()
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
