using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slots : MonoBehaviour,IPointerEnterHandler, IPointerDownHandler {

    //Variables
    public bool empty;
    public Texture slotTexture;
    public Texture itemTexture;
    public GameObject item;

    GameObject player;


    //FUNctions
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        //Change Texture
        if (item)
        {
            itemTexture = item.GetComponent<Item>().itemTexture;

            this.GetComponent<RawImage>().texture = itemTexture;
            empty = false;
        }
        else
        {
            this.GetComponent<RawImage>().texture = slotTexture;
            empty = true;
        }
    }

    public void OnPointerDown (PointerEventData eventData)
    {
        if (item)
        {
            item.SetActive(true);
            Player.weaponEquipped = true;
        }
    }

    public void OnPointerEnter (PointerEventData eventData)
    {

    }

}
