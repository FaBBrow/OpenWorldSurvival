using System;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public string ItemName;
    public GameObject inventoryObject;
    public bool playerInRange;
    public bool onRaytoTake;
    [SerializeField] private AudioClip TakeItemSound;
    private GameObject player;
   

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && SelectionManager.instance.onTargert && onRaytoTake)
            if (inventoryObject != null && !InventorySystem.instance.checkIfFull(1))
            {
               InventorySystem.instance.addToInventory(inventoryObject, ItemName );
                Destroy(gameObject);
                PlayerAudioManager.instance.TakeAudioClip(TakeItemSound);
            }
    }

   

    public string GetItemName()
    {
        return ItemName;
    }
}