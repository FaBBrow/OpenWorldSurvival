using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    public static Action<GameObject, string> OnItemAdded;
    public static Action<GameObject> OnUIChange;
    public static InventorySystem instance;
    public GameObject inventoryScreenUI;
    public bool isOpen;
    public List<GameObject> slotList;
    public List<GameObject> itemList;
    private GameObject itemToAdd;
    private GameObject whatSlotToEquip;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
            instance = this;

    }

    private void Start()
    {
        isOpen = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isOpen)
        {
            inventoryScreenUI.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            isOpen = true;
        }
        else if (Input.GetKeyDown(KeyCode.E) && isOpen)
        {
            inventoryScreenUI.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            isOpen = false;
        }
    }


    public void addToInventory(GameObject inventoyrobject, string takenitem)
    {
        whatSlotToEquip = findNextEmptySlot();

        itemToAdd = Instantiate(inventoyrobject, whatSlotToEquip.transform.position,
            whatSlotToEquip.transform.rotation);
        itemToAdd.transform.SetParent(whatSlotToEquip.transform);
        itemList.Add(itemToAdd);
        OnItemAdded?.Invoke(inventoyrobject, takenitem);
        OnUIChange?.Invoke(inventoyrobject);
        
    }


    public void deleteFromInventory(GameObject deleteItem, int value)
    {
        for (var i = itemList.Count - 1; i >= 0; i--)
            if (itemList[i].GetComponent<Image>().sprite == deleteItem.GetComponent<Image>().sprite)
            {
                value--;

                var itemToRemove = itemList[i];
                itemList.RemoveAt(i);
                OnUIChange?.Invoke(deleteItem);
                Destroy(itemToRemove);

                if (value == 0) break;
            }


        
    }


    public bool checkIfFull()
    {
        foreach (var slot in slotList)
            if (slot.transform.childCount > 0)
            {
            }
            else
            {
                return false;
            }

        return true;
    }

    public GameObject findNextEmptySlot()
    {
        foreach (var slot in slotList)
            if (slot.transform.childCount <= 0)
                return slot;
        return new GameObject();
    }
}