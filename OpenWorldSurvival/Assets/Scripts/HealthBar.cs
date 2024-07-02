using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI HealthText;

    private void Update()
    {
        UpdateHealthBar();
    }


    public void UpdateHealthBar()
    {
        slider.value = PlayerStat.instance.Health / PlayerStat.instance.MaxHealth;
        HealthText.text = PlayerStat.instance.Health.ToString("0");
    }
}
