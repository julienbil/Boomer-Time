using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class StreetGenerator : MonoBehaviour
{

    public GameObject[] differentTiles;

    public int[] pourcentageTiles;

    public float startX, startY, xSize, ySize;

    public int[,] mapData;
    public GameObject[,] map;

    private void Start()
    {
        mapData = new int[(int)xSize, (int)ySize];
        map = new GameObject[(int)xSize, (int)ySize];

        GeneratePos();
        GenerateMap();
        DisplayMap();
    }

    private void DisplayMap()
    {
        map[0, 0].transform.position = transform.position + new Vector3(startX, startY, 0);

        float actualX = startX, actualY = 0;

        for (int i = 0; i < map.GetLength(0) - 1; i++)
        {
            actualX += map[i, 0].transform.localScale.x;
            actualY = startY;
            for (int j = 0; j < map.GetLength(1) - 1; j++)
            {
                actualY += map[i, j].transform.localScale.y;
                map[i, j].transform.position = transform.position + new Vector3(actualX / 1.57f, -actualY / 1.57f, 37);
            }
        }

    }

    private void GeneratePos()
    {
        for (int i = 0; i < mapData.GetLength(0) - 1; i++)
        {
            for (int j = 0; j < mapData.GetLength(1) - 1; j++)
            {
                int randomType = Random.Range(1, 100);
                int pourActuel = 0;
                int fixedPour = pourcentageTiles[0];
                for (int k = 0; k < pourcentageTiles.Length; k++)
                {
                    if (randomType >= pourActuel && randomType < fixedPour)
                    {
                        mapData[i, j] = k;
                    }
                    Debug.Log(randomType);
                    Debug.Log(pourActuel);
                    pourActuel += pourcentageTiles[k];
                    if (fixedPour < 100)
                    {
                        fixedPour += pourcentageTiles[k + 1];
                    }
                }
            }
        }
    }

    private void GenerateMap()
    {
        for (int i = 0; i < mapData.GetLength(0) - 1; i++)
        {
            for (int j = 0; j < mapData.GetLength(1) - 1; j++)
            {

                map[i, j] = Instantiate(differentTiles[mapData[i, j]]);
            }
        }
    }
    /*
    public GameObject[] differentTiles;
    
    public int[] pourcentageTiles;

    public float startX, startY, xSize, ySize;

    public int[,] mapData;
    public GameObject[,] map;

    private void Start()
    {
        mapData = new int[(int)xSize, (int)ySize];
        map = new GameObject[(int)xSize,(int)ySize];

        GeneratePos();
        GenerateMap();
        DisplayMap();
    }

    private void DisplayMap()
    {
        map[0,0].transform.position = transform.position + new Vector3(startX, startY, 0);

        float actualX=startX, actualY=0;

        for (int i = 0; i < map.GetLength(1)-1; i++)
        {
            actualX += map[i,0].transform.localScale.x;
            actualY = startY;
            for (int j = 0; j < map.GetLength(0)-1; j++)
            {
                actualY += map[j,i].transform.localScale.y;
                map[j,i].transform.position = transform.position + new Vector3(actualX/1.57f, -actualY / 1.57f, 37);
            }
        }

    }

    private void GeneratePos()
    {
        for (int i=0; i<mapData.GetLength(1)-1; i++)
        {
            for (int j = 0; j < mapData.GetLength(0)-1; j++)
            {
                int randomType = Random.Range(1, 100);
                int pourActuel = 0;
                int fixedPour = pourcentageTiles[0];
                for (int k=0; k<pourcentageTiles.Length; k++)
                {
                    if(randomType>= pourActuel && randomType < fixedPour)
                    {
                        mapData[j,i] = k;
                    }
                    Debug.Log(randomType);
                    Debug.Log(pourActuel);
                    pourActuel += pourcentageTiles[k];
                    if (fixedPour < 100)
                    {
                        fixedPour += pourcentageTiles[k+1];
                    }
                }
            }
        }
    }

    private void GenerateMap()
    {
        for (int i = 0; i < mapData.GetLength(1)-1; i++)
        {
            for (int j = 0; j < mapData.GetLength(0)-1; j++)
            {
                
                map[j,i] = Instantiate(differentTiles[mapData[j,i]]);
            }
        }
    }
    */
}