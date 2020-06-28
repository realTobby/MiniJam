using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreSpawner : MonoBehaviour
{

    public GameObject moveable;

    [SerializeField]
    public bool canSpawn = true;

    public GameObject lastSpawnedOre;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canSpawn == true)
        {
            lastSpawnedOre = null;
            canSpawn = false;
            lastSpawnedOre = Instantiate(moveable, this.transform.position, Quaternion.identity);
            lastSpawnedOre.gameObject.transform.parent = this.gameObject.transform;
            Debug.Log("spawned a new ore");
        }

        if(lastSpawnedOre != null)
        {
            if (lastSpawnedOre.GetComponent<Moveable>().isPickedUp == true)
            {
                canSpawn = true;
                Debug.Log("the last ore was picked up");
            }
        }
        
        
    }
}
