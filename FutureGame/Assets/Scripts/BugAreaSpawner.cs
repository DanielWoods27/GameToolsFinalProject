using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugAreaSpawner : MonoBehaviour
{
    public GameObject itemToSpread;
    public int numToSpawn = 10;
    public float itemXSpread = 10;
    public float itemYSpread = 0;
    public float itenZSpread = 10;
    

    // Start is called before the first frame update
    void Start()
    {
        for (int i=0; i < numToSpawn; i++)
        {
            SpreadItem();
        }
      
    }

    void SpreadItem()
    {
        Vector3 randPosition = new Vector3(Random.Range(-itemXSpread, itemXSpread), Random.Range(-itemYSpread, itemYSpread), Random.Range(-itenZSpread, itenZSpread)) + transform.position;
        GameObject clone = Instantiate(itemToSpread, randPosition, Quaternion.identity);
    }
}
