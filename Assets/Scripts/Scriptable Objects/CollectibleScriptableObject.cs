using UnityEngine;

[CreateAssetMenu(fileName = "CollectibleScriptableObject", menuName = "CollectibleScriptableObjects")]
public class CollectibleScriptableObject : ScriptableObject
{


    public Transform _collectibleBody;
    public CollectibleType _collectibleType;
    public int _value;
    public string _name;
    public string _description;

    
}
public enum CollectibleType
{
    Diamond,
    Gold
}
