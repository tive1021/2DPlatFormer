using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [HideInInspector]
    public int coinAmount = 0;    

    protected override void Awake()
    {
        base.Awake();
    }    
}
