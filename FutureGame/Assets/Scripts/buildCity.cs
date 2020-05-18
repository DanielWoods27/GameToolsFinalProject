using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildCity : MonoBehaviour
{
    public GameObject[] buildings;
    public GameObject xStreets;
    public GameObject zStreets;
    public GameObject crossroad;
    public int mapWidth = 20;
    public int mapHeight = 20;
    int[,] mapgrid;
    int buildingSpacing = 3;

    // Start is called before the first frame update
    void Start()
    {
        mapgrid = new int[mapWidth, mapHeight];
        
        for(int h =0; h < mapHeight; h++)
        {
            for(int w = 0; w < mapWidth; w++)
            {
                mapgrid[w, h] = (int)(Mathf.PerlinNoise(w / 10.0f, h / 10.0f) * 10);
            }
        }
        //buildStreets
        int x = 0;
        for(int n = 0; n < 50; n++)
        {
            for(int h =0; h < mapHeight; h++)
            {
                mapgrid[x, h] = -1;
            }
            x += Random.Range(3, 3);
            if (x >= mapWidth) break;
        }

        int z = 0;
        for(int n=0; n < 10; n++)
        {
            for (int w = 0; w < mapWidth; w++)
            {
                if (mapgrid[w, z] == -1)
                    mapgrid[w, z] = -3;
                else
                    mapgrid[w, z] = -2;
            }
            z += Random.Range(5, 20);
            if (z >= mapHeight) break;
        }

        //Genrate City
        for(int h =0; h < mapHeight; h++)
        {
            for(int w = 0; w < mapWidth; w++)
            {
                int result = mapgrid[w, h];
                Vector3 pos = new Vector3(w * buildingSpacing, 0, h * buildingSpacing);
                if (result < -2)
                    Instantiate(crossroad, pos, crossroad.transform.rotation);
               else if (result < -1)
                    Instantiate(xStreets, pos, xStreets.transform.rotation);
                else if (result < 0)
                    Instantiate(zStreets, pos, zStreets.transform.rotation);
                else if (result < 1)
                    Instantiate(buildings[0],pos,Quaternion.identity);
                else if (result < 2)
                    Instantiate(buildings[1], pos, Quaternion.identity);
                else if (result < 4)
                    Instantiate(buildings[2], pos, Quaternion.identity);
                else if (result < 6)
                    Instantiate(buildings[3], pos, Quaternion.identity);
                else if (result < 7)
                    Instantiate(buildings[4], pos, Quaternion.identity);
                else if (result < 10)
                    Instantiate(buildings[5], pos, Quaternion.identity);
            }
        }
    }
}

   
