using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public GameObject item;
    public int ID;
    public string type;
    public string description;
    public bool empty;
    public Image slotIconGo;
    public Sprite icon;

    void Start()
    {
        slotIconGo = GetComponent<Image>();
    }

    public void UpdateSlot()
    {
        slotIconGo.sprite = icon;
    }

    public void UseItem()
    {

    }
}
