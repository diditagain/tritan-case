using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{

    public static MapManager instance;
    [SerializeField] MapTileScript mapTilePrefab;
    [SerializeField] GameObject map;
    [SerializeField] int _mapLength;
    [SerializeField] int _mapHeight;
    public MapTileScript[,] mapArray;
    public List<Vector3> usedCollectiblePos = new List<Vector3>();

    private void Awake()
    {
        if (instance == null) { instance = this; }
        
    }
    public void CreateMap()
    {
        mapArray = new MapTileScript[_mapHeight, _mapLength];
        for (int row = 0; row < _mapHeight; row++)
        {
            for (int col = 0; col < _mapLength; col++)
            {
                mapArray[row, col] = Instantiate(mapTilePrefab);
                mapArray[row, col].transform.position = new Vector3(col, 0 , row);
                mapArray[row, col].transform.SetParent(map.transform);
            }
        }
    }

    /// <summary>
    /// Gets random element from mapArray and returns Vector3 position of it.
    /// </summary>
    /// <returns></returns>
    public Vector3 GetRandomPosition()
    {
        Vector3 randomPos;
        randomPos = new Vector3(Random.Range(0, _mapHeight), 0.7f, Random.Range(0, _mapLength));
        if (usedCollectiblePos.Contains(randomPos))
        {
            return GetRandomPosition();
        }
        else
        {
            usedCollectiblePos.Add(randomPos);
            return randomPos;
        }

    }

}
