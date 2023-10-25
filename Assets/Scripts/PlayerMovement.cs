using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;

    public float PlayerX = 0f;
    public float PlayerY = 0f;

    public float PlayerSpeed = 2f;
    public float ExtraSpeed = 1f;

    public float rebirth;

    private void Start()
    {
        rebirth = 0f;
    }


    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector2(PlayerX, PlayerY);

        if (Input.GetKey(KeyCode.W) && transform.position.y < 3)
        {
            PlayerY += PlayerSpeed * ExtraSpeed * Time.deltaTime;
            animator.SetFloat("speed", 1f);
            if (rebirth == 1)
            {
                animator.Play("ruru");
            }
        }

        if (Input.GetKey(KeyCode.S) && transform.position.y> -3)
        {
            PlayerY -= PlayerSpeed * ExtraSpeed * Time.deltaTime;
            animator.SetFloat("speed", 1f);
            if (rebirth == 1)
            {
                animator.Play("ruru");
            }
        }

        if (Input.GetKey(KeyCode.A) && transform.position.x > -5.7f)
        {
            PlayerX -= PlayerSpeed * ExtraSpeed * Time.deltaTime;
            animator.SetFloat("speed", 1f);
            transform.rotation = new quaternion(0f, 180f, 0f ,0f);
            if (rebirth == 1)
            {
                animator.Play("ruru");
            }
        }

        if (Input.GetKey(KeyCode.D) && transform.position.x < 5.8f)
        {
            PlayerX += PlayerSpeed * ExtraSpeed * Time.deltaTime;
            animator.SetFloat("speed", 1f);
            transform.rotation = new quaternion(0f, 0f, 0f, 0f);
            if (rebirth == 1)
            {
                animator.Play("ruru");
            }
        }

        if(!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            animator.SetFloat("speed", 0f);
            if (rebirth == 1)
            {
                animator.Play("aqu");
            }
        }

        if ( Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D) || 
            Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S) || 
            Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A) || 
            Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
        {
            PlayerSpeed = 1.2f;
        }
        else
        {
            PlayerSpeed = 2f;
        }
    }
}
