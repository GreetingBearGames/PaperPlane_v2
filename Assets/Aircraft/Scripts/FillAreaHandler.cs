using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FillAreaHandler : MonoBehaviour
{
    [SerializeField] private Slider fuelBar;
    [SerializeField] private Sprite greenBar, orangeBar, redBar;

    void Update()
    {
        if (fuelBar.value >= 0.7f)
        {
            GetComponent<Image>().sprite = greenBar;
            fuelBar.GetComponent<Animator>().SetBool("fuelLoaded", true);
        }
        else if (fuelBar.value >= 0.35 && fuelBar.value < 0.7f)
        {
            GetComponent<Image>().sprite = orangeBar;
            fuelBar.GetComponent<Animator>().SetBool("fuelLoaded", true);
        }
        else if (fuelBar.value > 0f && fuelBar.value < 0.35f)
        {
            GetComponent<Image>().sprite = redBar;
            fuelBar.GetComponent<Animator>().SetBool("fuelLoaded", false);
            fuelBar.GetComponent<Animator>().Play("FuelLow_UI");
        }
        else if (fuelBar.value <= 0f)
        {
            GetComponent<Image>().sprite = redBar;
            fuelBar.GetComponent<Animator>().SetBool("fuelLoaded", false);
            fuelBar.GetComponent<Animator>().Play("FuelEmpty_UI");
        }
    }
}
