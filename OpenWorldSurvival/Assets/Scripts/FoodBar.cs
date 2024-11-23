using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FoodBar : MonoBehaviour
{
 [SerializeField] private Slider _slider;
 [SerializeField] private TextMeshProUGUI FoodText;
 private bool onZero = false;

 private void Start()
 {
  StartCoroutine(ConsumeFood());
 }

 private void Update()
 {
  UpdateFoodBar();
 }

 public void UpdateFoodBar()
 {
  if (PlayerStat.instance.Food <= 0)
  {
   
   PlayerStat.instance.Food = 0;
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

 
  _slider.value = PlayerStat.instance.Food / PlayerStat.instance.MaxFood;
  FoodText.text = PlayerStat.instance.Food.ToString("0");
 }
 IEnumerator ConsumeFood()
 {
  yield return new WaitForSeconds(120f);
  PlayerStat.instance.Food -= 5f;
  UpdateFoodBar();
  StartCoroutine(ConsumeFood());
 }

 IEnumerator decreaseHealth()
 {
  onZero = true;
  yield return new WaitForSeconds(50f);
  PlayerStat.instance.Health -= 5f;
  StartCoroutine(decreaseHealth());

 }
 
}
