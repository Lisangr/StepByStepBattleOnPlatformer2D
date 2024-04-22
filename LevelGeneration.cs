using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public GameObject groundTilePrefab; // ������ ��������� �����
    public GameObject floatingTilePrefab; // ������ ����� �������� � �������
    public int mapWidth = 20; // ������ �����
    public int mapHeight = 10; // ������ �����
    public float groundLevel = 0f; // ������� �����
    public float floatingHeight = 3f; // ������ ������� ������
    public int minFloatingGroupSize = 3; // ����������� ������ ������ ������� ������
    public int maxFloatingGroupSize = 10; // ������������ ������ ������ ������� ������
    public int holeScatterRange = 15; // ������� ����� � �����
    public int minHoleWidth = 1; // ����������� ������ �����
    public int maxHoleWidth = 3; // ������������ ������ �����

    private void Start()
    {
        GenerateMap();
    }
    void GenerateMap()
    {
        // ��������� �����
        for (int x = 0; x < mapWidth; x++)
        {
            Instantiate(groundTilePrefab, new Vector3(x, groundLevel, 0), Quaternion.identity);
        }

        // ��������� ������� ������
        for (int x = 0; x < mapWidth; x += Random.Range(minFloatingGroupSize, maxFloatingGroupSize))
        {
            for (int y = 1; y < mapHeight; y += Random.Range(minFloatingGroupSize, maxFloatingGroupSize))
            {
                Instantiate(floatingTilePrefab, new Vector3(x, groundLevel + floatingHeight + y, 0), Quaternion.identity);
            }
        }

        // ��������� ����� � �����
        for (int i = 0; i < mapWidth / holeScatterRange; i++)
        {
            int holeX = Random.Range(i * holeScatterRange, (i + 1) * holeScatterRange);
            int holeWidth = Random.Range(minHoleWidth, maxHoleWidth + 1);
            for (int x = holeX; x < Mathf.Min(holeX + holeWidth, mapWidth); x++)
            {
                Destroy(Instantiate(groundTilePrefab, new Vector3(x, groundLevel, 0), Quaternion.identity), 0.01f);
            }
        }
    }
    /*
    void GenerateMap()
    {
        // ��������� �����
        for (int x = 0; x < mapWidth; x++)
        {
            Instantiate(groundTilePrefab, new Vector3(x, groundLevel, 0), Quaternion.identity);
        }

        // ��������� ������� ������
        for (int x = 0; x < mapWidth;)
        {
            int groupSize = Random.Range(minFloatingGroupSize, maxFloatingGroupSize + 1);
            for (int i = 0; i < groupSize && x < mapWidth; i++)
            {
                for (int y = 1; y < mapHeight; y += Random.Range(2, 4))
                {
                    Instantiate(floatingTilePrefab, new Vector3(x, groundLevel + floatingHeight + y, 0), Quaternion.identity);
                }
                x++;
            }
        }

        // ��������� ����� � �����
        for (int i = 0; i < mapWidth / holeScatterRange; i++)
        {
            int holeX = Random.Range(i * holeScatterRange, (i + 1) * holeScatterRange);
            int holeWidth = Random.Range(minHoleWidth, maxHoleWidth + 1);
            for (int x = holeX; x < Mathf.Min(holeX + holeWidth, mapWidth); x++)
            {
                Destroy(Instantiate(groundTilePrefab, new Vector3(x, groundLevel, 0), Quaternion.identity), 0.01f);
            }
        }
    }*/
}

    /*void GenerateMap()
    {
        landMap = new int[mapWidth, mapHeight];

        // ���������� ������� ���������� ��������� �����
        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                landMap[x, y] = Random.Range(0, landObjects.Length);
            }
        }

        // �������� � ����������� ����� � �����
        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                int count = CountAdjacentLandObjects(x, y);

                if (count > 2)
                {
                    // ������ ������ �������� �� ������ ���� ����� ��� ���������� ������ ������
                    landMap[x, y] = Random.Range(0, landObjects.Length);
                }
            }
        }

        // �������� ����� ����� � Unity
        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                int landType = landMap[x, y];
                GameObject landObject = landObjects[landType];

                // �������� ������� ����� � ������� (x, y)
                Instantiate(landObject, new Vector3(x, 0, y), Quaternion.identity);
            }
        }
    }

    int CountAdjacentLandObjects(int x, int y)
    {
        int count = 0;

        for (int i = x - 1; i <= x + 1; i++)
        {
            for (int j = y - 1; j <= y + 1; j++)
            {
                if (i >= 0 && i < mapWidth && j >= 0 && j < mapHeight && (i != x || j != y))
                {
                    if (landMap[i, j] < landObjects.Length)
                    {
                        count++;
                    }
                }
            }
        }

        return count;
    }*/
    /*
    void GenerateMap()
    {
        landMap = new int[mapWidth, mapHeight, mapLevels];

        // ���������� ������� ���������� ��������� �����
        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                for (int z = 0; z < mapLevels; z++)
                {
                    landMap[x, y, z] = Random.Range(0, landObjects.Length);
                }
            }
        }

        // �������� �����
        for (int x = 0; x < mapWidth; x += holeFrequency)
        {
            for (int y = 0; y < mapHeight; y += holeFrequency)
            {
                for (int z = 0; z < mapLevels; z++)
                {
                    if (Random.Range(0, 2) == 0) // ��������� ������� � �������� �����
                    {
                        int holeLength = Random.Range(minHoleLength, maxHoleLength + 1);

                        for (int i = 0; i < holeLength; i++)
                        {
                            if (x + i < mapWidth && y + i < mapHeight)
                            {
                                landMap[x + i, y + i, z] = -1; // ���������� -1 ��� ����������� �����
                            }
                        }
                    }
                }
            }
        }
        
        // �������� � ����������� ����� � �����
        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                for (int z = 0; z < mapLevels; z++)
                {
                    int count = CountAdjacentLandObjects(x, y, z);

                    if (count > 1 || landMap[x, y, z] == -1)
                    {
                        // ������ ������ �������� �� ������ ���� ����� ��� ���������� ������ ������
                        landMap[x, y, z] = Random.Range(0, landObjects.Length);
                    }
                }
            }
        }
        
        // �������� ����� ����� � Unity
        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                for (int z = 0; z < mapLevels; z++)
                {
                    int landType = landMap[x, y, z];

                    if (landType != -1) // ���������� ����� ��� �������� �������� �����
                    {
                        GameObject landObject = landObjects[landType];

                        // �������� ������� ����� � ������� (x, z * floorSpacing, y) ��� ����� ������� � ������ � ���������� ����� �������
                        Instantiate(landObject, new Vector3(x, z * floorSpacing, y), Quaternion.identity);
                    }
                }
            }
        }
    }

    int CountAdjacentLandObjects(int x, int y, int z)
    {
        int count = 0;

        for (int i = x - 1; i <= x + 1; i++)
        {
            for (int j = y - 1; j <= y + 1; j++)
            {
                for (int k = z - 1; k <= z + 1; k++)
                {
                    if (i >= 0 && i < mapWidth && j >= 0 && j < mapHeight && k >= 0 && k < mapLevels && (i != x || j != y || k != z))
                    {
                        if (landMap[i, j, k] < landObjects.Length)
                        {
                            count++;
                        }
                    }
                }
            }
        }

        return count;
    }
}*/
