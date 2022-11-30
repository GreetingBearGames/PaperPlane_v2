using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenuButtons : MonoBehaviour
{
    public WinLose winLose;
    public Button fuelButton, incomeButton;
    public int menuValue;
    [SerializeField] private Sprite deactiveIncomeImg, deactiveFuelImg;
    [SerializeField] private Sprite activeIncomeImg, activeFuelImg;
    ColorBlock newColorBlockFuel, newColorBlockIncome;
    
    private void Awake() {
        ColorBlock newColorBlockFuel = fuelButton.colors;
        ColorBlock newColorBlockIncome = incomeButton.colors;
    }
    private void Update() {
        if(!winLose.gameStarted){
            fuelButton.enabled = true;
            incomeButton.enabled = true;
        }
        else{
            fuelButton.enabled = true;
            incomeButton.enabled = true;
        }
        if(winLose.numOfCoins < menuValue){
            fuelButton.GetComponent<Image>().sprite = deactiveFuelImg;
            incomeButton.GetComponent<Image>().sprite = deactiveIncomeImg;
            fuelButton.enabled = false;
            incomeButton.enabled = false;
        }
        else{
            fuelButton.GetComponent<Image>().sprite = activeFuelImg;
            incomeButton.GetComponent<Image>().sprite = activeIncomeImg;
            fuelButton.enabled = true;
            incomeButton.enabled = true;
        }
    }

    public void IncomeUpgrade(){
        winLose.numOfCoins -= menuValue;
        winLose.coinRate *= 1.25f;
    }

    public void FuelUpgrade(){
        winLose.numOfCoins -= menuValue;
        winLose.fuel += 25f;
    }
}
