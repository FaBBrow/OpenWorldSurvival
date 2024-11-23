using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAnimationController : MonoBehaviour
{
    [SerializeField] private Animator itemAnimator;
    [SerializeField] private AudioClip ItemSound;
    [SerializeField] private AudioSource ItemAudioSource;
    private void Awake()
    {
        itemAnimator = GetComponent<Animator>();
    }

    private void Start()
    {
        ItemAudioSource = GetComponent<AudioSource>();
        ItemAudioSource.clip = ItemSound;
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
    public void selectedTreeDamage(){
        SelectionManager.instance.treeDamage();
    }

    public void PlayAudio()
    {
        ItemAudioSource.Play();
    }
    
    
}
