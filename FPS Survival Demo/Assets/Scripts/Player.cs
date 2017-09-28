using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    //Variables
    public float maxhunger, maxthirst, maxhealth;
    private float hunger, thirst, health;

    public float hungerIncrease, thirstIncrease;

    private bool triggeringTree;
    private GameObject tree;

    public static bool weaponEquipped;


    //functions
    void Start()
    {
        health = maxhealth;
    }

    void Update()
    {
        //thirst and hunger
        HungerAndThirst();

        //player health management
        if (health <= 0)
            Die();

        // print(hunger + " " + thirst);

        //Chop a motherfucking tree
        if(triggeringTree == true && weaponEquipped)
        {
            //ATTACK TEH TREES!!!
            if (Input.GetMouseButtonDown(0))
            {
                if(tree)
                    tree.GetComponent<Tree>().currentHealth -= 25;
            }
        }
    }


    public void HungerAndThirst()
    {
        hunger += hungerIncrease * Time.deltaTime;
        thirst += thirstIncrease * Time.deltaTime;

        if (hunger >=maxhunger)
        {
            Die();
        }

        if (thirst >= maxthirst)
        {
            Die();
        }
    }

    public void Die()
    {
        print("Player is DED!");
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Tree")
        {
            triggeringTree = true;
            tree = other.gameObject;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Tree")
        {
            triggeringTree = false;
            tree = other.gameObject;
        }
    }

}
