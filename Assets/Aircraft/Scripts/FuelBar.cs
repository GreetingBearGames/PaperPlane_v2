using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelBar : MonoBehaviour
{
    [SerializeField] private Slider fuelBar;
    [SerializeField] private WinLose winLose;
    private float totalFuel;

    private void Awake()
    {
        totalFuel = winLose.fuel;
    }

    void Update()
    {
        float currentFuel = winLose.fuel;
        fuelBar.value = (currentFuel / totalFuel);
    }
}
