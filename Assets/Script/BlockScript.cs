using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    [Header("Properties")]
    public BlockProperty bp;
    public SpriteRenderer sr;
    public float HP;

    private void Start()
    {
        sr.sprite = bp.texture;
        HP = bp.HP;
    }

    private void GotHit(float damage)
    {
        
    }
}
