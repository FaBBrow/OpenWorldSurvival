using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    [SerializeField] private bool consumable;
    [SerializeField] private int foodValue;
    [SerializeField] private int drinkValue;
    [SerializeField] private int healthValue;
    [SerializeField] private string itemName;
    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right && consumable)
        {
            PlayerStat.instance.Drink += drinkValue;
            PlayerStat.instance.Food += foodValue;
            PlayerStat.instance.Health += healthValue;
            InventorySystem.instance.deleteFromInventory(gameObject,1);
            Takenİnfo.instance.onitemConsumed(gameObject,itemName);
        }

        if (eventData.button == PointerEventData.InputButton.Middle)
        {
            InventorySystem.instance.deleteFromInventory(gameObject,1);
            Takenİnfo.instance.onitemDeleted(gameObject,itemName);
        }
       
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        
    }
}
