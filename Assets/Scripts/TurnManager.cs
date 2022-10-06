using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class TurnManager : MonoBehaviour
{
    private static TurnManager instance;
    [SerializeField] private PlayerTurn playerOne;
    [SerializeField] private PlayerTurn playerTwo;
    [SerializeField] private float timeBetweenTurns;
    [SerializeField] public int turnLength;

    private GameObject player1;
    private GameObject player2;

    
    public int currentPlayerIndex;
    private bool waitingForNextTurn;
    private float turnDelay;
    public bool endGame = false;

    private GameObject mCamera;

    private int timerTimer;
    public int timer;
    private bool freezeTimer;
 

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            currentPlayerIndex = 1;
            playerOne.SetPlayerTurn(1);
            playerTwo.SetPlayerTurn(2);

            
        }
    }

    private void Update()
    {
        if (waitingForNextTurn)
        {
            turnDelay += Time.deltaTime;
            if (turnDelay >= timeBetweenTurns)
            {
                turnDelay = 0;
                waitingForNextTurn = false;
                ChangeTurn();
            }
        }

        //Timer time
        if (freezeTimer == false)
        {
            if (endGame == false)
            {
                timerTimer += 1;

            }
            

        }
        

        if (timerTimer >= 600)
        {
            timer += 1;
            timerTimer = 0;
            Debug.Log(timer);
        }

        if (timer >= turnLength)
        {

            TriggerChangeTurn();
            freezeTimer = true;

        }

    }

    public bool IsItPlayerTurn(int index)
    {
        if (waitingForNextTurn)
        { 
            return false;
        }

        return index == currentPlayerIndex;
    }

    public static TurnManager GetInstance()
    {
        return instance;
    }

    public void TriggerChangeTurn()
    {
        waitingForNextTurn = true;
    }

    private void ChangeTurn()
    {
        if (currentPlayerIndex == 1)
        {
            player2 = GameObject.Find("Player Two");
            CharacterController getPlayer2 = player2.GetComponent<CharacterController>();
            if (getPlayer2.dead == true)
            {
                Debug.Log("He dead lol");
            }
            else
            {
                currentPlayerIndex = 2;
            }
        }
        else if (currentPlayerIndex == 2)
        {
            player1 = GameObject.Find("Player One");
            CharacterController getPlayer1 = player1.GetComponent<CharacterController>();
            if (getPlayer1.dead == true)
            {
                Debug.Log("He dead lol");
            }
            else
            {
                currentPlayerIndex = 1;
            }
            
        }
        mCamera = GameObject.Find("Main Camera");
        CameraScript cameraScript = mCamera.GetComponent<CameraScript>();
        cameraScript.currentTurn = currentPlayerIndex;
        timer = 0;
        freezeTimer = false;
    }
}
