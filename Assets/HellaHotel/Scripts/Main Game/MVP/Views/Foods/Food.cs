using System.Collections;
using System.Collections.Generic;
using HellaHotel.Scripts.Main_Game.MVP.Models.Data.Interfaces;
using UnityEngine;

public class Food : MonoBehaviour,IRecoveryHp,IRecoveryHunger,IRecoveryThirst
{
    void Start()
    {
        
    }
    void Update()
    {
        
    }

    public float RecoveryHp { get; set; }
    public float RecoveryHunger { get; set; }
    public float RecoveryThirst { get; set; }
}
