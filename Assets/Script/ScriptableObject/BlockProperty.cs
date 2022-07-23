using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Block Property", menuName = "Block")]
public class BlockProperty : ScriptableObject
{
    public float HP;
    public List<GameObject> objectToDrop;
    public Sprite texture;
}
