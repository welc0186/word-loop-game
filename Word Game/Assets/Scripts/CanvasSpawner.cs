using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSpawner : MonoBehaviour
{
    
    public GameObject Spawn(GameObject prefab)
    {
        GameObject spawned = Instantiate(prefab, this.transform);
        return spawned;
    }

}
