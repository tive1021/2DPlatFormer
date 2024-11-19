using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    public PlayerController controller;
    public PlayerCondition condition;

    protected override void Awake()
    {
        base.Awake();
        controller = GetComponent<PlayerController>();
        condition = GetComponent<PlayerCondition>();
    }
}
