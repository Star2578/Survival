using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [Header("Properties")]
    public BlockProperty bp;
    public SpriteRenderer sr;
    public float HP;

    [Header("Drop item")]
    public float speed = 5;

    private void Start()
    {
        sr.sprite = bp.texture;
        HP = bp.HP;
    }

    private void GotHit(float damage)
    {
        HP -= damage;

        if (HP <= 0)
        {
            HP = 0;
            Destroyed();
        }
    }

    private void Destroyed()
    {
        var items = Instantiate(bp.objectToDrop[0], transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
