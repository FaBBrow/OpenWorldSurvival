using System.Collections.Generic;
using UnityEngine;

public class CraftingSystem : MonoBehaviour
{
    public static CraftingSystem instance;
    [SerializeField] private GameObject CraftingSystemScreenUI;
    [SerializeField] private List<GameObject> craftingSlotSlist;
    [SerializeField] private GameObject toolsScreenUI;
    private bool isopen;

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
            isopen = true;
        }
        else if (Input.GetKeyUp(KeyCode.T) && isopen)
        {
            CraftingSystemScreenUI.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            isopen = false;
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