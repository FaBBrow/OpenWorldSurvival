using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAnimationController : MonoBehaviour
{
    [SerializeField] private Animator itemAnimator;

    private void Awake()
    {
        itemAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {   
            itemAnimator.SetFloat("Blend",1);
            
        }
        else
        {
            itemAnimator.SetFloat("Blend",0);
        }
    }
}
