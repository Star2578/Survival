using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject overlayTile;
    public GameObject overlayContainer;
    public GameObject objectContainer;

    private void Awake()
    {
        instance = this;
    }
}
