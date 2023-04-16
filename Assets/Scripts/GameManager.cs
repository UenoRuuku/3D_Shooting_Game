using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform player;
    public Transform[] waypoints;

    public static GameManager instance;

    void Awake()
    {
        instance = this;
    }
}
