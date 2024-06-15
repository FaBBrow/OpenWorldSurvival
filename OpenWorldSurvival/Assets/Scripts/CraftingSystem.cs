using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CraftingSystem : MonoBehaviour
{
    [SerializeField] GameObject CraftingSystemScreenUI;
    public static CraftingSystem instance;
    [SerializeField] List<GameObject> craftingSlotSlist;
    private bool isopen=false;
    [SerializeField] GameObject toolsScreenUI;
    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.T) && !isopen)
        {
            CraftingSystemScreenUI.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            isopen =true;
        }
        else if (Input.GetKeyUp(KeyCode.T) && isopen)
        {
            CraftingSystemScreenUI.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            isopen = false;
        }
    }
    public void updateAllUI()
    {
        foreach(GameObject slot in craftingSlotSlist)
        {
            slot.GetComponent<CraftingSlot>().UpdateUI();
        }
    }
    public void openTools()
    {
       
        toolsScreenUI.SetActive(true);
    }
    public void goBack()
    {
        toolsScreenUI.SetActive(false);
    }
    
}
