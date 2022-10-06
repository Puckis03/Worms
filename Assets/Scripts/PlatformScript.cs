using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    private int moveTimer;
    private bool moveUp = true;
    private bool moveForward = true;
    [SerializeField] private float speed;
    [SerializeField] private string direction;

    void Update()
    {

        moveTimer += 1;

         if (moveTimer > 600) 
        {
            if (direction == "Up")
            {
                if (moveUp == true)
                {
                    transform.position += Vector3.up * speed * Time.deltaTime;


                }
                else if (moveUp == false)
                {
                    transform.position += Vector3.down * speed * Time.deltaTime;


                }





            }
            else if (direction == "Forward")
            {
                if (moveForward == true)
                {
                    transform.position += Vector3.right * speed * Time.deltaTime;


                }
                else if (moveForward == false)
                {
                    transform.position -= Vector3.right * speed * Time.deltaTime;


                }


            }
                

        }

         if (moveTimer > 2400)
        {
            
            if (direction == "Up")
            {
                if (moveUp == true)
                {
                    moveUp = false;
                }
                else if (moveUp == false)
                {
                    moveUp = true;
                }


            }
            else if (direction == "Forward")
            {
                if (moveForward == true)
                {
                    moveForward = false;

                }
                else if (moveForward == false)
                {
                    moveForward = true;

                }


            }


            moveTimer = 0;


        }

    }
}
