using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinLabelText;
    private Player player;

    private void Awake()
    {
        player = Player.Instance;
    }

    private void Update()
    {
        coinLabelText.text = GameManager.Instance.coinAmount.ToString();
    }
}
