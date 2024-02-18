using System.Collections;
using System.Collections.Generic;
using HellaHotel.Scripts.Main_Game.MVP.Models.Data.Interfaces;
using UnityEngine;

public class BaseFood : AdvancedMonoBehaviour,IRecoveryHunger,IRecoveryThirst,IRecoveryHp,ICanBeUsed,IAmTakeable
{
    [SerializeField] private float recoveryHp;
    [SerializeField] private float recoveryHunger;
    [SerializeField] private float recoveryThirst;
    private int currentState = 0;
    public float RecoveryHunger { get => recoveryHunger; set => recoveryHunger = value;}
    public float RecoveryThirst { get => recoveryThirst; set => recoveryThirst = value;}
    public float RecoveryHp { get => recoveryHp; set => recoveryHp = value;}

    public void Interaction()
    {
        if (currentState == children.Count - 1)
        {
            Destroy(gameObject);
        }
        else
        {
            children[currentState].gameObject.SetActive(false);
            currentState++;
            children[currentState].gameObject.SetActive(true);
        }
    }

    public void Take(object arg)
    {
        var place = arg as Transform;
        transform.position = Vector3.zero;
        transform.SetParent(place,false);
        GetComponent<Collider>().enabled = false;
    }
}
