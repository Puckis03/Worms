using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Runtime.InteropServices;

public class UIScript : MonoBehaviour
{
    private GameObject player1;
    private GameObject player2;
    private GameObject TurnManager;

    [SerializeField] private Image healthBar1;
    [SerializeField] private Image healthBar2;
    [SerializeField] private TextMeshProUGUI Timer;
    private float player1Health;
    private float player2Health;
    private float timerTime;
   

    void Update()
    {

        //Timer
        TurnManager = GameObject.Find("Turn Manager");
        TurnManager timer = TurnManager.GetComponent<TurnManager>();

        timerTime = timer.turnLength - timer.timer;

        Timer.SetText(timerTime.ToString());

        
        
        //Health bars
        player1 = GameObject.Find("Player One");
        CharacterController getHp1 = player1.GetComponent<CharacterController>();

        player1Health = getHp1.health;

        healthBar1.fillAmount = player1Health / 100;

        player2 = GameObject.Find("Player Two");
        CharacterController getHp2 = player2.GetComponent<CharacterController>();

        player2Health = getHp2.health;

        healthBar2.fillAmount = player2Health / 100;


    }
}
