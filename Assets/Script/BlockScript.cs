using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    [Header("Properties")]
    public BlockProperty bp;
    public SpriteRenderer sr;
    public float HP;

    public float force = 5;

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
        
        // items.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)));
        items.transform.position = Vector3.Lerp(transform.position, transform.position, force);

        Destroy(gameObject);
    }
}
