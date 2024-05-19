using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CraftingSystem : MonoBehaviour
{
    [SerializeField] GameObject CraftingSystemScreenUI;
    [SerializeField] GameObject ToolScreenUI;
    public static CraftingSystem instance;
    [SerializeField] List<GameObject> craftingSlotSlist;
    private void Awake()
    {
        instance = this;
    }
    public void updateAllUI()
    {
        foreach(GameObject slot in craftingSlotSlist)
        {
            slot.GetComponent<CraftingSlot>().UpdateUI();
        }
    }
    
}
