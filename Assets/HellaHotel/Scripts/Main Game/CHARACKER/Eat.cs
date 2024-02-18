 using System;
using System.Collections;
using System.Collections.Generic;
using HellaHotel.Scripts.Main_Game.MVP.Models.Data.Interfaces;
using UnityEngine;

public class Eat : MonoBehaviour
{
    public void Food(float? hp,float? hunger,float? thirst )
    {
        PlayerInfo.Instance.Hp += hp == null ? 0 : hp.Value;
        PlayerInfo.Instance.Thirst += thirst == null ? 0 :thirst.Value;
        PlayerInfo.Instance.Hunger += hunger == null ? 0 : hunger.Value;
        if (PlayerInfo.Instance.Hunger > 100)
        {
            PlayerInfo.Instance.Hunger = 100;
        }
        if (PlayerInfo.Instance.Hp > 100)
        {
            PlayerInfo.Instance.Hp = 100;
        }
        if (PlayerInfo.Instance.Thirst > 100)
        {
            PlayerInfo.Instance.Thirst = 100;
        }
        Debug.Log($"thirst {(thirst == null ? 0 :thirst.Value)}  " +
                  $"hunger {(hunger == null ? 0 : hunger.Value)} " +
                  $" hp {(hp == null ? 0 : hp.Value)}");
    }

    void Start()
    {
        
    }
    void Update()
    {
        
    }
    
}
