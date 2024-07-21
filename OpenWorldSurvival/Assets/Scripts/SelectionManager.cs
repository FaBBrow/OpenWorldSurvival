using TMPro;
using UnityEngine;
using DG.Tweening;

public class SelectionManager : MonoBehaviour
{
    public static SelectionManager instance;

    public GameObject interaction_Info_UI;
    public bool onTargert;
    private TextMeshProUGUI interaction_text;
    private InteractableObject target;
    public GameObject selectedTree;

    private void Start()
    {
        instance = this;
        interaction_text = interaction_Info_UI.GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit,5))
        {
            var selectionTransform = hit.transform;
            var interactable = selectionTransform.GetComponent<InteractableObject>();
            var chopableTree = selectionTransform.GetComponent<ChoppableTree>();

            if (chopableTree )
            {
                chopableTree.canBeChopped = true;
                selectedTree = chopableTree.gameObject;
                onTargert = true;
            }
            else
            {
                if (selectedTree != null)
                {
                    selectedTree.gameObject.GetComponent<ChoppableTree>().canBeChopped = false;
                    selectedTree = null;
                    
                }

                {
                    onTargert = false;
                }
            }
            
            if (interactable )
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

    public void treeDamage()
    {
        if (selectedTree)
        {
            selectedTree.GetComponent<ChoppableTree>().TreeHealth -= 1;
            selectedTree.transform.DOShakePosition(0.1f, .05f, 1);
        }
        
    }
}