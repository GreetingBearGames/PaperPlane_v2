using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinText : MonoBehaviour
{ 
    [SerializeField] private WinLose winLose;
    [SerializeField] private TextMeshProUGUI Text;

    private void Update() {
        Text.text = winLose.numOfCoins.ToString();
    }
}
