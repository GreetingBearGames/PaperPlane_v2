using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelBar : MonoBehaviour
{
    [SerializeField] private Slider fuelBar;
    [SerializeField] private WinLose winLose;


    void Update()
    {
        fuelBar.value = (winLose.fuel / winLose.totalFuel);
    }
}
