using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        MapManager.instance.CreateMap();
        CollectiblePool.instance.CreateCollectiblePool();
    }


}
