using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CraftingSlot : MonoBehaviour
{
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
        int itemcounter=0;
        for (int i = 0; i < requirementsTextUI.Count; i++)
        {
            
            int requirevalue = takeRequire(requirementsItems[i]);

           
            requirementsTextUI[i].text = $"{values[i]} {texts[i]} [{requirevalue}]";
            if (requirevalue == values[i])
            {
               itemcounter++;
            }
        }
        if (itemcounter == requirementsTextUI.Count)
        {
            craftButtonUI.SetActive(true);
        }

    }
    public int takeRequire(GameObject require)
    {
         int counter = 0;
        foreach(GameObject items in InventorySystem.instance.itemList)
        {
            if(items.name == require.name)
            {
                counter++;
            }
        }
        return counter;
    }
}
