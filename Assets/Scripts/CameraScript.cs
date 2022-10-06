using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private GameObject player1;
    private GameObject player2;
    public int currentTurn;

   
   

     void Start()
    {
        currentTurn = 1;
        player1 = GameObject.Find("Player One");
        player2 = GameObject.Find("Player Two");
       
    }



    private void Update()
    {
        

        if (currentTurn == 1)
        {
            transform.position = new Vector3(player1.transform.position.x, player1.transform.position.y + 5, player1.transform.position.z - 6);
            transform.LookAt(player1.transform.position);
        }
        else if (currentTurn == 2)
        {

            transform.position = new Vector3(player2.transform.position.x, player2.transform.position.y + 5, player2.transform.position.z-6);
            transform.LookAt(player2.transform.position);

        }
        
    }

}
