using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("Properties")]
    public ItemProperty ip;
    public SpriteRenderer sr;

    private void Start()
    {
        sr.sprite = ip.texture;
    }
}
