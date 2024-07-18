using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class CraftingSlot : MonoBehaviour
{
    [SerializeField] private string craftingItemText;
    [SerializeField] private GameObject craftItem;
    [SerializeField] private List<TextMeshProUGUI> requirementsTextUI;
    [SerializeField] private GameObject craftButtonUI;
    [SerializeField] private List<GameObject> requirementsItems;
    [SerializeField] private List<string> texts;
    [SerializeField] private List<int> values;
    [SerializeField] private int numberOfCreate;

    private void Start()
    {
        UpdateUI();
        InventorySystem.OnUIChange += checkUIChangeAvailable;
    }


    public void UpdateUI()
    {
        
        var itemcounter = 0;
        for (var i = 0; i < requirementsTextUI.Count; i++)
        {
            var requirevalue = takeRequire(requirementsItems[i]);


            requirementsTextUI[i].text = $"{values[i]} {texts[i]} [{requirevalue}]";
            if (requirevalue >= values[i]) itemcounter++;
        }

        if (itemcounter == requirementsTextUI.Count)
            craftButtonUI.SetActive(true);
        else
            craftButtonUI.SetActive(false);
    }
    public void checkUIChangeAvailable(GameObject a)
    {
        int index = 0;
        foreach (var VARIABLE in requirementsItems)
        {
            if (VARIABLE == a) index++;
        }
        if (index == 0) return;
        else
        {
            UpdateUI();
        }
    }

    public void Craft()
    {
        if (!InventorySystem.instance.checkIfFull(numberOfCreate))
        {
            for (var i = 0; i < requirementsItems.Count; i++)
                InventorySystem.instance.deleteFromInventory(requirementsItems[i], values[i]);

            
            for (int i = 0; i < numberOfCreate; i++)
            {
                InventorySystem.instance.addToInventory(craftItem,craftingItemText);
            }
        }
    }


    public int takeRequire(GameObject require)
    {
        var counter = 0;
        if (InventorySystem.instance.itemList == null) return 0;
        for (var i = 0; i < InventorySystem.instance.itemList.Count; i++)
            if (InventorySystem.instance.itemList[i].GetComponent<Image>().sprite ==
                require.gameObject.GetComponent<Image>().sprite)
                counter++;
        return counter;
    }
}