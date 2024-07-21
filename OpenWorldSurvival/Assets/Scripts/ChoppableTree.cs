using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoppableTree : MonoBehaviour
{
 public bool playerInRange;
 public bool canBeChopped;
 private int _treeHealth=3;
 private GameObject treechoppable;

 private void Start()
 {
  treechoppable = gameObject.transform.GetChild(0).gameObject;
 }

 public int TreeHealth
 {
  get => _treeHealth;
  set => _treeHealth = value;
 }

 private void Update()
 {
  
   if (TreeHealth==0)
   {
    treechoppable.transform.SetParent(transform.root);
    treechoppable.gameObject.SetActive(true);
    Destroy(gameObject);
   }
  
 }
 

}
