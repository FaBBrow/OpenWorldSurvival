using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    public static SelectionManager instance;

    public GameObject interaction_Info_UI;
    TextMeshProUGUI interaction_text;
    public bool onTargert = false;
    InteractableObject target;

    private void Start()
    {
        instance = this;
        interaction_text = interaction_Info_UI.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selectionTransform = hit.transform;
             InteractableObject interactable= selectionTransform.GetComponent<InteractableObject>();
            if (interactable&&interactable.playerInRange)
            {
                target = interactable;
                target.onRaytoTake = true;
                onTargert = true;
                interaction_text.text = selectionTransform.GetComponent<InteractableObject>().GetItemName().ToString();
                interaction_Info_UI.SetActive(true);
            }
            else
            {
                if (target != null)
                {
                    target.onRaytoTake = false;
                }
                
                onTargert=false;
                interaction_Info_UI.SetActive(false);
            }

        }
        else
        {
            onTargert = false;
            interaction_Info_UI.SetActive(false);
        }
    }
}
