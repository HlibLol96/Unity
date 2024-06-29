using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using Random = System.Random;


public class Generate : MonoBehaviour
{
  
  [SerializeField]  private Test environments; 
  private List<Transform> spawns = new List<Transform>();
  private void Awake()
  {
    Random rnd = new Random();
    for (int i = 0; i < gameObject.transform.childCount; i++)
    {
      spawns.Add(gameObject.transform.GetChild(i));
    }

    foreach (var variableSpawn in spawns)
    {
      Instantiate(environments.list[rnd.Next(0,environments.list.Count)], variableSpawn);
    }
  }
}
