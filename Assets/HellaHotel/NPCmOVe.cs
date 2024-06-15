using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using DG.Tweening;
using UnityEngine;

public class NPCmOVe : MonoBehaviour
{
    private Vector3 startPosition;
    private Vector3 finishPosition;
    private System.Random random = new System.Random();
    private List<GameObject> points = new List<GameObject>();
    [SerializeField] private GameObject player;

    void Start()
    {
        points = GameObject.FindGameObjectsWithTag("POINT").ToList();
        startPosition = transform.position;
        //if (points.getco)
        {
            
        }
        finishPosition = new Vector3(startPosition.x+random.Next(1,10),startPosition.y, 
            startPosition.z+random.Next(1,11));
        
    }
    
    // Update is called once per frame
    void Update()
    {
        //Debug.Log($"nextdouble  {random.NextDouble()}");
        //transform.DOMove(finishPosition, 1);
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, 
            finishPosition, 10* Time.deltaTime);
        startPosition = finishPosition;
        finishPosition = new Vector3(startPosition.x+random.Next(-1,2),startPosition.y, startPosition.z+random.Next(-1,2));
        if (Vector3.Distance(player.transform.position,transform.position)<= 10)
        {
            
            Debug.Log(" Player!");
        }

        //if (finishPosition.x >= 10 || finishPosition.x <= -10)
        //{
       //     finishPosition = new Vector3(finishPosition.x - 1, finishPosition.y, finishPosition.z);
       // }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ground")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);
        }
    }

    private void OnTriggerExit(Collider other)
    { 
        while (true)
        {
            Debug.Log("exit");
            transform.position = new Vector3(transform.position.x, transform.position.y -1, transform.position.z);
        }
        
    
    }
}
