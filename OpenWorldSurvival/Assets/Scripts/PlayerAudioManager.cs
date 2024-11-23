using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioManager : MonoBehaviour
{
   public static PlayerAudioManager instance;
   [SerializeField] private AudioSource PlayerAudio;
   private AudioClip takenAudio;

   private void Start()
   {
      instance = this;
   }

   public void TakeAudioClip(AudioClip audioClip)
   {
      takenAudio = audioClip;
      PlayerAudio.clip = takenAudio;
      PlayAudioClip();
   }

   public void PlayAudioClip()
   {
      if (!PlayerAudio.isPlaying)
      {
         PlayerAudio.Play();
      }
      
   }
   
   
}
