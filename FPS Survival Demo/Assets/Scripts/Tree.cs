using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour {

    //variables
    public int treeHealth;
    public int currentHealth;

    public int dropAmount;
    public GameObject[] dropTable;

    private bool itemsDropped;



    //FUNcations
    public void Start()
    {
        currentHealth = treeHealth;
    }

    public void Update()
    {
        if (currentHealth <= 0)
        {
            for (int i = 0; i < dropAmount; i++)
            {
                Instantiate(dropTable[i].transform, this.transform.position, Quaternion.identity);
                if (i == (dropAmount - 1))
                    itemsDropped = true;
            }
        }

        if (itemsDropped == true)
            Destroy(this.gameObject);
    }



}
