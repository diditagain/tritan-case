using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleBehaviorScript : MonoBehaviour
{
    public CollectibleScriptableObject scriptableObject;
    public string collectibleName;
    public string description;
    Transform collectibleBody;
    CollectibleType collectibleType;


    private void Start()
    {
        collectibleName = scriptableObject.name;
        description = scriptableObject._description;
        collectibleBody = Instantiate(scriptableObject._collectibleBody);
        collectibleBody.SetParent(this.transform);
        collectibleBody.localPosition = Vector3.zero;
        collectibleType = scriptableObject._collectibleType;
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collision Detected");
        if (other.gameObject.GetComponent<MovementController>() != null)
        {
            Debug.Log("PlayerCollision");
            UIManager.instance.CollectibleAcquired(collectibleType);
            transform.position = MapManager.instance.GetRandomPosition();
        }
    }
}
