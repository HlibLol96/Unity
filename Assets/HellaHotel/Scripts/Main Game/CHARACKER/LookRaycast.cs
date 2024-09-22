using System;
using HellaHotel.Scripts.Main_Game.MVP.Models.Data.Interfaces;
using UnityEngine;

public class LookRaycast : MonoBehaviour
{
    private Eat _eat;
    private RaycastHit _raycastHit;
    [SerializeField] int distance;
    [SerializeField] Transform rightHand;
    [SerializeField] Transform pcPos;
    [SerializeField] GameObject player;

    private void Start()
    {
        _eat = transform.parent.GetComponent<Eat>();
    }

    void Update()
    {
        Look();
    }

    private void Look()
    {
        
        var direction  = transform.rotation * Vector3.forward;

        Physics.Raycast(transform.position, direction, out _raycastHit, distance);
        Debug.DrawRay(transform.position,direction * distance,Color.cyan);
        if (Input.GetKeyDown(KeyCode.E) && _raycastHit.collider.GetComponent<ICanBeUsed>() != null)
        {
            _eat.Food(_raycastHit.collider.GetComponent<IRecoveryHp>()?.RecoveryHp,
            _raycastHit.collider.GetComponent<IRecoveryHunger>()?.RecoveryHunger,
            _raycastHit.collider.GetComponent<IRecoveryThirst>()?.RecoveryThirst);
            _raycastHit.collider.GetComponent<ICanBeUsed>().Interaction();
        }
        else if(Input.GetKeyDown(KeyCode.E) && _raycastHit.collider.GetComponent<IInteractive>() != null)
        {
            _raycastHit.collider.GetComponent<IInteractive>().Interact();
        }

        if (Input.GetKeyDown(KeyCode.F) && _raycastHit.collider.GetComponent<IAmTakeable>() != null
                                        && rightHand.childCount == 0)
        {
            _raycastHit.collider.GetComponent<IAmTakeable>().Take(rightHand);
        }
         if(Input.GetKeyDown(KeyCode.Q) && _raycastHit.collider.GetComponent<Computer>() != null)
        {
            Debug.Log("pc");
            _raycastHit.collider.GetComponent<Computer>().Sit(this.gameObject);
            player.gameObject.transform.GetChild(0).GetComponent<MovementScript>().Ability = false;
            


        }
        
    }
}
