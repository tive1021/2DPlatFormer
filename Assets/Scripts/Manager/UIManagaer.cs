using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManagaer : MonoBehaviour
{
    [SerializeField] GameObject HealthLabel;

    [SerializeField] TextMeshProUGUI coinLabelText;

    private void Update()
    {
        coinLabelText.text = GameManager.Instance.coinAmount.ToString();
    }
}
