using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour
{
    [SerializeField] GameObject sitPosition;
    void Start()
    {
        
    }
    void Update()
    {
        

    }
    public void Sit(GameObject sitObject)
    {
        Cursor.lockState = CursorLockMode.None;
        //sitObject.transform.position = 
        sitObject.transform.SetParent(sitPosition.transform);
        sitObject.transform.localPosition = new Vector3(0, 0, 0);
        sitObject.transform.localRotation = Quaternion.identity; 
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
    }    
}

