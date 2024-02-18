using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;


public class RoomGenerate : MonoBehaviour
{
    [SerializeField]  private Test environments; 
    private List<Transform> spawns = new List<Transform>();
    [SerializeField] private GameObject StartRoom;

    void Start()
    {
        Random rnd = new Random();
        var children = transform.GetChild(0).GetChild(0).GetComponent<SpawnPosition>();
        spawns.Add(children.transform);
        Debug.Log($"children:{children}");
        
      
        
        foreach (var variableSpawn in spawns)
        {
            Instantiate(environments.list[rnd.Next(0,environments.list.Count)], variableSpawn);
        }
    }

    void Update()
    {
        var children  = transform.GetComponentsInChildren<SpawnPosition>();
        Debug.Log(children.Length);
    }
}
