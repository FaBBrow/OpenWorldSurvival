using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public string ItemName;

    public bool playerInRange;
    public bool onRaytoTake=false;
    public string GetItemName()
    {
        return ItemName;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && playerInRange&&SelectionManager.instance.onTargert&&onRaytoTake)
        {
            Debug.Log("item added in inventory");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
