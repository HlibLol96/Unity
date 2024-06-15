using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Open : MonoBehaviour,IInteractive
{
    
    private Vector3 closedPosition;
    private Vector3 openPosition;
    private bool appear = true;

    private void Start()
    {
        closedPosition = transform.localEulerAngles;
        openPosition = new Vector3(closedPosition.x, closedPosition.y +90, closedPosition.z);
    }

    

    public void Opener()
    {
        transform.DOLocalRotate(openPosition,1);
    }

    public void Close()
    {
        transform.DOLocalRotate(closedPosition,1);
    }

    private void OnTriggerEnter(Collider other)
    {
        Opener();
    }
    public void Interact()
    {
        Close();
    }
}
