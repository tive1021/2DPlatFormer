using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.coinAmount++;
        if(GameManager.Instance.coinAmount >= 100)
        {
            Player.Instance.condition.Heal();
            GameManager.Instance.coinAmount -= 100;
        }
        Destroy(gameObject);
    }
}
