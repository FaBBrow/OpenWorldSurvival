using TMPro;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public static SelectionManager instance;

    public GameObject interaction_Info_UI;
    public bool onTargert;
    private TextMeshProUGUI interaction_text;
    private InteractableObject target;

    private void Start()
    {
        instance = this;
        interaction_text = interaction_Info_UI.GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selectionTransform = hit.transform;
            var interactable = selectionTransform.GetComponent<InteractableObject>();
            if (interactable && interactable.playerInRange)
            {
                target = interactable;
                target.onRaytoTake = true;
                onTargert = true;
                interaction_text.text = selectionTransform.GetComponent<InteractableObject>().GetItemName();
                interaction_Info_UI.SetActive(true);
            }
            else
            {
                if (target != null) target.onRaytoTake = false;

                onTargert = false;
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