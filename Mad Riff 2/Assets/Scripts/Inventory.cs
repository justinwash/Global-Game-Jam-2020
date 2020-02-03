using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject inventory;
    private bool inventoryEnabled;
    private int allSlots;
    private int enabledSlots;
    public List<GameObject> slots = new List<GameObject>();
    public GameObject SlotPrfab;
    public GameObject slotHolder;
    public List<string> items = new List<string>();
    private AudioSource audio;
    public AudioClip getItem;

    void Start()
    {
        allSlots = 10;

        for (int i = 0; i < 6; i++)
        {
            GameObject slot = Instantiate(SlotPrfab, transform);
            slot.AddComponent<Slot>();
            Slot mySlot = slot.GetComponent<Slot>();
            mySlot.empty = true;
            mySlot.item = null;
            slots.Add(slot);
        }

        audio = GetComponent<AudioSource>();
        //for (int i = 0; i < allSlots; i++)
        //{
        //    slot[i] = slotHolder.transform.GetChild(i).gameObject;
        //    if (slot[i].GetComponent<Slot>().item == null)
        //    {
        //        slot[i].GetComponent<Slot>().empty = true;
        //    }
        //}
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) inventoryEnabled = !inventoryEnabled;

        if (inventoryEnabled == true)
        {
            inventory.SetActive(true);
            ShowItems();
        }
        else
        {
            inventory.SetActive(false);
        }
    }

    private void ShowItems()
    {
        int itemCount = 0;
        foreach (GameObject itemSlot in slots)
        {
            Slot thisSlot = itemSlot.GetComponent<Slot>();
            if (!thisSlot.empty)
            {
                Image ItemHolder = slotHolder.transform.GetChild(itemCount).GetChild(0).GetComponent<Image>();
                ItemHolder.sprite = thisSlot.icon;
                thisSlot.slotIconGo = ItemHolder;
                itemCount++;
            }

        }
    }

    //private bool HasItems()
    //{
    //    bool hasItems = false;
    //    foreach(GameObject itemSlot in slots)
    //    {
    //        Slot thisSlot = itemSlot.GetComponent<Slot>();
    //        if (!thisSlot.empty)
    //        {
    //            hasItems = true;
    //        }
    //    }
    //    return hasItems;
    //}
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            GameObject itemPickedUp = other.gameObject;
            Item item = itemPickedUp.GetComponent<Item>();


            AddItem(itemPickedUp, item.ID, item.type, item.description, item.icon);
        }
    }

    public bool HasItem(string itemName)
    {
        return items.Contains(itemName);
    }

    public void TakeItem(string itemName)
    {
        foreach(GameObject slot in slots)
        {
            Slot thisSlot = slot.GetComponent<Slot>();
            if (!thisSlot.empty)
            {
                if (thisSlot.type.Equals(itemName))
                {
                    thisSlot.empty = true;
                    thisSlot.type = "";
                    thisSlot.description = "";
                    thisSlot.item = null;
                }
            }
        }
        items.Remove(itemName);
    }

    void AddItem(GameObject itemObject, int itemID, string itemType, string itemDescription, Sprite itemIcon)
    {
        foreach (GameObject slot in slots)
        {
            if (slot.GetComponent<Slot>().empty)
            {
                itemObject.GetComponent<Item>().Pickup();
                itemObject.GetComponent<Item>().pickedUp = true;
                slot.GetComponent<Slot>().item = itemObject;
                slot.GetComponent<Slot>().icon = itemIcon;
                slot.GetComponent<Slot>().type = itemType;
                slot.GetComponent<Slot>().ID = itemID;
                slot.GetComponent<Slot>().description = itemDescription;

                itemObject.transform.parent = slot.transform;
                itemObject.SetActive(false);
                items.Add(itemType);
                slot.GetComponent<Slot>().empty = false;
                audio.PlayOneShot(getItem);
                
            }
            return;

        }
    }
}

