using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Hardness : byte { VERYSOFT, SOFT, NORMAL, HARD, VERYHARD, INDESTRUCT }

[CreateAssetMenu(fileName = "New Block Property", menuName = "Block")]
public class BlockProperty : ScriptableObject
{
    [Header("Info")]
    public Sprite texture;
    public List<Hardness> hardness;

    [Header("Description")]
    public float HP;
    public List<GameObject> objectToDrop;
}
