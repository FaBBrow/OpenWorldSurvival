using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
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
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        populateTheSlots();
    }
    private void Start()
    {
        isOpen = false;
        

    }
    public void populateTheSlots()
    {
        foreach(Transform Child in inventoryScreenUI.transform)
        {
            if (Child.CompareTag("Slot"))
            {
                slotList.Add(Child.gameObject);
            }
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&&!isOpen)
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
    public void addToInventory(GameObject inventoyrobject)
    {
        

       
       
            whatSlotToEquip = findNextEmptySlot();
            itemToAdd = Instantiate(inventoyrobject, whatSlotToEquip.transform.position, whatSlotToEquip.transform.rotation);
            itemToAdd.transform.SetParent(whatSlotToEquip.transform);
            itemList.Add(inventoyrobject);
             CraftingSystem.instance.updateAllUI();
       
    }


    public bool checkIfFull()
    {
       
        foreach(GameObject slot in slotList)
        {

            if (slot.transform.childCount >0)
            {
               

            }
            else
            {
                return false;
            }

        }
        return true;
     
    }
    public GameObject findNextEmptySlot()
    {
        foreach(GameObject slot in slotList)
        {
            if (slot.transform.childCount <= 0)
            {
                return slot;
            }
        }
        return new GameObject();
    }
}
