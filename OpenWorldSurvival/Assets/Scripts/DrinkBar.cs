using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DrinkBar : MonoBehaviour
{

    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI DrinkText;
    private bool onZero;

    private void Start()
    {
        StartCoroutine(ConsumeDrink());
    }


    void Update()
    {
        UpdateDrinkBar();
    }

    IEnumerator ConsumeDrink()
    {
        yield return new WaitForSeconds(120f);
        PlayerStat.instance.Drink -= 5f;
        UpdateDrinkBar();
        StartCoroutine(ConsumeDrink());
    }
    public void UpdateDrinkBar()
    {
        if (PlayerStat.instance.Drink <= 0)
        {
   
            PlayerStat.instance.Drink= 0;
            if (!onZero)
            {
                StartCoroutine(decreaseHealth());
            }

   
        }
        else
        {
            onZero = false;
            StopCoroutine(decreaseHealth());
        }
        _slider.value = PlayerStat.instance.Drink / PlayerStat.instance.MaxDrink;
        DrinkText.text = PlayerStat.instance.Drink.ToString("0");
    }
    IEnumerator decreaseHealth()
    {
        onZero = true;
        yield return new WaitForSeconds(50f);
        PlayerStat.instance.Health -= 5f;
        StartCoroutine(decreaseHealth());

    }
    
}
