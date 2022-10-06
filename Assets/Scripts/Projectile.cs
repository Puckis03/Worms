using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody projectileBody;
    [SerializeField] private GameObject damageIndicatorPrefab;
    [SerializeField] private int projectileDamage = 20;
    private GameObject player1;
    private GameObject player2;
    private GameObject TurnManager;
    private int player1HP;
    private int player2HP;
   

    
    void Update()
    {
        player1 = GameObject.Find("Player One");
        CharacterController getHp1 = player1.GetComponent<CharacterController>();
        player1HP = getHp1.health;
        player2 = GameObject.Find("Player Two");
        CharacterController getHp2 = player2.GetComponent<CharacterController>();
        player2HP = getHp2.health;
    }
    public void Initialize()
    {

        Ray rayFromMouse = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane planeAtPlayer = new Plane(Vector3.up, transform.position);
        if (planeAtPlayer.Raycast(rayFromMouse, out float distanceToHit))
        {
            Vector3 hitPosition = rayFromMouse.GetPoint(distanceToHit);
            transform.LookAt(hitPosition);
            projectileBody.AddForce(transform.forward * 700f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject damageIndicator = Instantiate(damageIndicatorPrefab);
        damageIndicator.transform.position = collision.GetContact(0).point;

        TurnManager = GameObject.Find("Turn Manager");
        TurnManager turnManager = TurnManager.GetComponent<TurnManager>();

        if (collision.gameObject.name == "Player One")
        {
            player1 = GameObject.Find("Player One");
            CharacterController getHp1 = player1.GetComponent<CharacterController>();

            getHp1.health -= projectileDamage;

            if (getHp1.health <= 0)
            {
                getHp1.dead = true;

                turnManager.endGame = true;

            }
        }
        else if (collision.gameObject.name == "Player Two")
        {
            player2 = GameObject.Find("Player Two");
            CharacterController getHp2 = player2.GetComponent<CharacterController>();

            getHp2.health -= projectileDamage;

            if (getHp2.health <= 0)
            {
                getHp2.dead = true;

                turnManager.endGame = true;

            }
        }



        Destroy(this.gameObject);
    }
}
