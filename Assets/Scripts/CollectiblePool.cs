using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblePool : MonoBehaviour
{
    public static CollectiblePool instance;
    [SerializeField] List<CollectibleScriptableObject> collectibleScriptableList = new List<CollectibleScriptableObject>();
    [SerializeField] int _collectibleAmount;
    [SerializeField] CollectibleBehaviorScript collectiblePrefab;
    public List<CollectibleBehaviorScript> createdCollectibles = new List<CollectibleBehaviorScript>();

    public void Awake()
    {
        if (instance == null) { instance = this; }
    }

    public void CreateCollectiblePool()
    {
        CollectibleBehaviorScript tempCollectible;
        foreach (CollectibleScriptableObject collectibleScriptableObject in collectibleScriptableList)
        {
            for (int i = 0; i < _collectibleAmount; i++)
            {
                tempCollectible = Instantiate(collectiblePrefab);
                tempCollectible.scriptableObject = collectibleScriptableObject;
                Vector3 collectiblePosition = MapManager.instance.GetRandomPosition();
                tempCollectible.transform.position = collectiblePosition;
            }
        }
    }
}
