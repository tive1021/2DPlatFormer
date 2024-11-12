using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : DestroySingleton<Player>
{
    public int coinAmount = 0;

    protected override void Awake()
    {
        base.Awake();
    }
}
