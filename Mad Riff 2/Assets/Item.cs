using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item : MonoBehaviour
{
    public int ID;
    public string description;
    public string type;
    public Sprite icon;
    public bool pickedUp;
    public bool equipped;

    public void Update()
    {
        if (equipped)
        {
            //
        }
    }

    public void ItemUsage()
    {
        //weapon
        if(type=="weapon")
        {
            equipped = true;
        }
        //health
        //beverage
    }

    public void Pickup()
    {
        spotLight myLight = GetComponent<spotLight>();
        if(myLight != null)
        {
            Destroy(myLight);
        }
    }
}