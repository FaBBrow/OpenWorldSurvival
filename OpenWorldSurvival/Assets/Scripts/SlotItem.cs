using UnityEngine;
using UnityEngine.EventSystems;

public class SlotItem : MonoBehaviour, IDropHandler
{
    
    public GameObject item
    {
        get
        {
            if (transform.childCount > 0) return transform.GetChild(0).gameObject;
            return null;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (!item)
        {
            DragDrop.itemBeingDragged.transform.SetParent(transform);
            DragDrop.itemBeingDragged.transform.localPosition = new Vector2(0, 0);
            
        }
    }
}