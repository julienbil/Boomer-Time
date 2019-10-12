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

    public float timer;

    private float positionX;

    private int[,] tempMapData;
    private GameObject[,] tempMap;

    private void Start()
    {
        mapData = new int[(int)xSize, (int)ySize];
        map = new GameObject[(int)xSize, (int)ySize];
        tempMapData = new int[(int)xSize, (int)ySize];
        tempMap = new GameObject[(int)xSize, (int)ySize];

        GeneratePos();
        GenerateMap();
        DisplayMap();
        StartCoroutine(ActivateOnTimer());
    }

    private IEnumerator ActivateOnTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(timer);
            UpdateStreet();
        }
    }

    void UpdateStreet()
    {
        CopyArray();
        DestroyUseless();
        CreateNewTiles();
        ReplaceArrays();
    }

    void ReplaceArrays()
    {
        for (int i = 0; i < mapData.GetLength(0) - 1; i++)
        {
            for (int j = 0; j < mapData.GetLength(1) - 1; j++)
            {
                map[i, j] = tempMap[i, j];
                mapData[i, j] = tempMapData[i, j];
            }
        }
    }

    void CreateNewTiles()
    {
        for (int i = 0; i < tempMapData.GetLength(1) - 1; i++)
        {
            int randomType = Random.Range(1, 100);
            int pourActuel = 0;
            int fixedPour = pourcentageTiles[0];
            for (int k = 0; k < pourcentageTiles.Length; k++)
            {
                if (randomType >= pourActuel && randomType < fixedPour)
                {
                    tempMapData[tempMapData.GetLength(0)-1, i] = k;
                }
                pourActuel += pourcentageTiles[k];
                if (fixedPour < 100)
                {
                    fixedPour += pourcentageTiles[k + 1];
                }
            }
        }

        float actualY = startY;
        for (int i = 0; i < tempMap.GetLength(1) - 1; i++)
        {
            //actualY += map[i, 0].transform.localScale.y;
            actualY += 2;
            tempMap[tempMap.GetLength(0)-1, i] = Instantiate(differentTiles[tempMapData[tempMapData.GetLength(0)-1, i]]);
            tempMap[tempMap.GetLength(0) - 1, i].transform.position = transform.position + new Vector3(positionX / 1.57f, -actualY / 1.57f, 37);
        }
        positionX += map[0, 0].transform.localScale.x;
        Debug.Log(positionX);
    }

    void DestroyUseless()
    {
        for (int i = 0; i < mapData.GetLength(1) - 1; i++)
        {
            Destroy(map[0, i]);
        }
    }

    void CopyArray()
    {
        for (int i = 0; i < mapData.GetLength(0) - 2; i++)
        {
            for (int j = 0; j < mapData.GetLength(1) - 1; j++)
            {
                tempMap[i, j] = map[i+1, j];
                tempMapData[i, j] = mapData[i + 1, j];
            }
        }
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
        positionX = actualX;
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
}