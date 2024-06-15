using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public string ItemName;
    public GameObject inventoryObject;
    public bool playerInRange;
    public bool onRaytoTake;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && playerInRange && SelectionManager.instance.onTargert && onRaytoTake)
            if (inventoryObject != null && !InventorySystem.instance.checkIfFull())
            {
                InventorySystem.instance.addToInventory(inventoryObject);
                Destroy(gameObject);
            }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) playerInRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) playerInRange = false;
    }

    public string GetItemName()
    {
        return ItemName;
    }
}