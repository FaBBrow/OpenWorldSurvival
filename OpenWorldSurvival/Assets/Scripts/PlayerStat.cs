using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    
    public static PlayerStat instance;
    [SerializeField] private float maxHealth;
    [SerializeField] private float _health;
    [SerializeField] private float maxFood;
    [SerializeField] private float _food;
    [SerializeField] private float _drink;
    [SerializeField] private float maxDrink;
    public float Health
    {
        get => _health;
        set => _health = value;
    }

    public float MaxHealth
    {
        get => maxHealth;
        set => maxHealth = value;
    }

    public float MaxFood
    {
        get => maxFood;
        set => maxFood = value;
    }

    public float Food
    {
        get => _food;
        set => _food = value;
    }

    public float Drink
    {
        get => _drink;
        set => _drink = value;
    }

    public float MaxDrink
    {
        get => maxDrink;
        set => maxDrink = value;
    }

    private void Start()
    {
        instance = this;
        _health = 100f;
        maxHealth = 100f;
        _food = 100f;
        maxFood = 100f;
        _drink = 100f;
        maxDrink = 100f;
    }
    
}
