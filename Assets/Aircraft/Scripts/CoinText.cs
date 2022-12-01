using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinText : MonoBehaviour
{
    [SerializeField] private WinLose winLose;
    [SerializeField] private TextMeshProUGUI Text;
    private int coinAmount;

    private void Update()
    {
        coinAmount = (int)winLose.numOfCoins;
        Text.text = coinAmount.ToString();
    }
}
