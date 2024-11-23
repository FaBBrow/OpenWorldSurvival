using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private GameObject selected;
    private void OnTriggerEnter(Collider other)
    {
        selected = other.gameObject;
        if (selected.GetComponent<InteractableObject>())
        {
            Debug.Log("sa");
            selected.GetComponent<InteractableObject>().playerInRange = true;
        }
        if (selected.GetComponent<ChoppableTree>())
        {
            selected.GetComponent<ChoppableTree>().playerInRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        selected = null;
        if (other.GetComponent<InteractableObject>())
        {
            Debug.Log("as");
            other.GetComponent<InteractableObject>().playerInRange = false;
        }

        if (other.GetComponent<ChoppableTree>())
        {
            other.GetComponent<ChoppableTree>().playerInRange = false;
        }
       
    }

    private void OnTriggerStay(Collider other)
    {
        other.GetComponent<InteractableObject>().playerInRange = true;
    }
}
