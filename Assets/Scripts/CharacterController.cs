using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class CharacterController : MonoBehaviour
{
    [SerializeField] public PlayerTurn playerTurn;
    [SerializeField] private Rigidbody characterBody;
    [SerializeField] private float speed = 10f;
    [SerializeField] public int health;
    [SerializeField] private Vector3 shrinkSpeed;
    [SerializeField] public int jumpHeight;

    public bool dead;
    private int teleportLocation;


    void Update()
    {
        if (playerTurn.IsPlayerTurn())
        {
            if (Input.GetAxis("Horizontal") != 0)
            {
                
              transform.Translate(Vector3.right * speed * Time.deltaTime * Input.GetAxis("Horizontal"), Space.World);
            
            }

            if (Input.GetAxis("Vertical") != 0)
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime * Input.GetAxis("Vertical"), Space.World);
                
            }

            if (Input.GetKeyDown(KeyCode.Space) && IsTouchingFloor())
            {
                Jump();
            }


            Rotation();

            


            

        }

        if (dead == true)
        {
            if (transform.localScale.y > 0)
            {
                transform.localScale -= shrinkSpeed;


            }


           
        }

        if (transform.position.y < -10)
        {
            health -= 30;

            transform.position = new Vector3(22, 6, 20);

        }

        
        

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Bounce Gel")
        {
            jumpHeight = 900;

        }
        else if (collision.gameObject.name == "Teleporter")
        {
            teleportLocation = Random.Range(0, 5);

            if (teleportLocation <= 1)
            {
                transform.position = new Vector3(7, 0, 14);

            }
            else if (teleportLocation <= 2)
            {
                transform.position = new Vector3(34, 0, 15);

            }
            else if (teleportLocation <=3)
            {
                transform.position = new Vector3(34, 0,25);

            }
            else if (teleportLocation <= 4)
            {
                transform.position = new Vector3(7, 0, 25);
            }
            else if (teleportLocation <= 5)
            {
                transform.position = new Vector3(22, 6, 20);
            }

        }
    }
    

    private void OnCollisionExit(Collision collision)   
    {
        if (collision.gameObject.name == "Bounce Gel")
        {
            jumpHeight = 300;
        }
    }





    private void Rotation()
    {
        Ray rayFromMouse = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane planeAtPlayer = new Plane(Vector3.up, transform.position);
        if (planeAtPlayer.Raycast(rayFromMouse, out float distanceToHit))
        {
            Vector3 hitPosition = rayFromMouse.GetPoint(distanceToHit);
            transform.LookAt(hitPosition);
        }

    }




    private void Jump()
    {
        //characterBody.velocity = Vector3.up * 10f;
        characterBody.AddForce(Vector3.up * jumpHeight);
    }

    private bool IsTouchingFloor()
    {
        RaycastHit hit;
        // Parameters:
        // - The center from where we shoot
        // - Radius of the sphere
        // - Direction of the sphere
        // - hit parameter
        // - Distance the sphere
        bool result =  Physics.SphereCast(transform.position, 0.15f, -transform.up, out hit, 1f);
        return result;
    }
}
