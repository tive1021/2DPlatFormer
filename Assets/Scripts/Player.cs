using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Singleton<Player>
{
    public event Action<InputAction.CallbackContext> Move;

    protected override void Awake()
    {
        base.Awake();
    }
}
