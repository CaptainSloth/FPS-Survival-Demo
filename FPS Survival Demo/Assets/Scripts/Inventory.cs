using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    //Variables
    public bool inventoryEnabled;
    public GameObject inventory;
    public GameObject itemDB;
    private Transform[] slot;
    public GameObject slotsHolder;

    //private bool PickedUp;



    //FUNctions
    public void Start()
    {
        GetAllSlots();
    }

    public void Update()
    {
        //Enable and disable Inventory
        if (Input.GetKeyDown(KeyCode.I))
            inventoryEnabled = !inventoryEnabled;

        if (inventoryEnabled)
            inventory.SetActive(true);
        else
            inventory.SetActive(false);

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            AddItem(other.gameObject);
        }
    }

    public void AddItem(GameObject item)
    {
        if (item.GetComponent<ItemPickup>().craftMaterial == false)
        {
            GameObject rootItem;
            rootItem = item.GetComponent<ItemPickup>().rootItem;

            for (int i = 0; i < 25; i++)
            {
                if (slot[i].GetComponent<Slots>().empty == false && item.gameObject.GetComponent<ItemPickup>().isPickedUp == false)
                {
                    slot[i].GetComponent<Slots>().item = rootItem;
                    item.GetComponent<ItemPickup>().isPickedUp = true;
                    Destroy(item);
                }
            }
        }
        else
        {
            for (int i = 0; i < 25; i++)
            {
                if (slot[i].GetComponent<Slots>().empty == true && item.gameObject.GetComponent<ItemPickup>().isPickedUp == false)
                {
                    slot[i].GetComponent<Slots>().item = item;
                    item.GetComponent<ItemPickup>().isPickedUp = true;
                    item.transform.parent = itemDB.transform;

                    item.GetComponent <MeshRenderer>().enabled = false;
                    Destroy(item.GetComponent<Rigidbody>());
                }
            }
        }


    }

    public void GetAllSlots()
    {
        slot = new Transform[25];
        for (int i = 0; i < 25; i++)
        {
            slot[i] = slotsHolder.transform.GetChild(i);

        }
    }
}
