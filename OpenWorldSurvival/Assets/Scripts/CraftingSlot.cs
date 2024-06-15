using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CraftingSlot : MonoBehaviour
{
    [SerializeField] private GameObject craftItem;
    [SerializeField] private List<TextMeshProUGUI> requirementsTextUI;
    [SerializeField] private GameObject craftButtonUI;
    [SerializeField] private List<GameObject> requirementsItems;
    [SerializeField] private List<string> texts;
    [SerializeField] private List<int> values;

    private void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        var itemcounter = 0;
        for (var i = 0; i < requirementsTextUI.Count; i++)
        {
            var requirevalue = takeRequire(requirementsItems[i]);


            requirementsTextUI[i].text = $"{values[i]} {texts[i]} [{requirevalue}]";
            if (requirevalue == values[i]) itemcounter++;
        }

        if (itemcounter == requirementsTextUI.Count)
            craftButtonUI.SetActive(true);
        else
            craftButtonUI.SetActive(false);
    }

    public void Craft()
    {
        if (!InventorySystem.instance.checkIfFull())
        {
            for (var i = 0; i < requirementsItems.Count; i++)
                InventorySystem.instance.deleteFromInventory(requirementsItems[i], values[i]);

            InventorySystem.instance.addToInventory(craftItem);
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