using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    //Variables
    public Texture itemTexture;
    public bool craftMaterial;










    //FUNctions
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !craftMaterial)
        {
            this.gameObject.SetActive(false);
            Player.weaponEquipped = false;
        }
    }




}
