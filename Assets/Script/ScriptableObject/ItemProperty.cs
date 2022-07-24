using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Property", menuName = "Item")]
public class ItemProperty : ScriptableObject
{
    [Header("Info")]
    public Sprite texture;
    public string itemName;
    public string description;
}
