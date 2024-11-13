using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public int coinAmount = 0;

    protected override void Awake()
    {
        base.Awake();
    }
}
