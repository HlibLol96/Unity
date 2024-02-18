using System.Collections.Generic;
using UnityEngine;

public class AdvancedMonoBehaviour : MonoBehaviour
{
    protected List<Transform> children = new List<Transform>();
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            children.Add(transform.GetChild(i));
        }
    }
    
}
