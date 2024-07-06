using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EquipSystem : MonoBehaviour
{
    [SerializeField] private List<GameObject> quickSlotList;
    [SerializeField] private List<TextMeshProUGUI> numberList;
    public int selectedNumber = -1;
    public GameObject selectedItem;
    [SerializeField] private GameObject HandHolder;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectQuickSlot(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectQuickSlot(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectQuickSlot(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            selectQuickSlot(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            selectQuickSlot(4);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            selectQuickSlot(5);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            selectQuickSlot(6);
        }
    }

    public void selectQuickSlot(int number)
    {
        for (int i = 0; i < numberList.Count; i++)
        {
            if (number==i)
            {
                numberList[i].color=Color.white;
                selectedNumber = i;
                selectItem(i);
            }
            else
            {
                numberList[i].color=Color.gray;
            }
        }
    }

    public void selectItem(int number)
    {
        if (selectedItem != null)
        {
            selectedItem.GetComponent<InventoryItem>().isSelected = false;
            if (HandHolder.transform.childCount > 0)
            {
                Destroy(HandHolder.transform.GetChild(0).gameObject);
            }
            
        }
        if (quickSlotList[number].transform.childCount!=0)
        {
            selectedItem= quickSlotList[number].transform.GetChild(0).gameObject;
            selectedItem.GetComponent<InventoryItem>().isSelected = true;
            GetModel(selectedItem);
        }
        
    }

    public void GetModel(GameObject selecteditem)
    {
        GameObject selectedModel = selecteditem.GetComponent<InventoryItem>().GameModel;
        InventoryItem modelınventoryıtem = selecteditem.GetComponent< InventoryItem>();
        GameObject itemModel = Instantiate(selectedModel, HandHolder.transform.position, Quaternion.Euler(modelınventoryıtem.rotation));
        itemModel.transform.SetParent(HandHolder.transform);
        itemModel.transform.localPosition = modelınventoryıtem.modelposition;

    }
}
    