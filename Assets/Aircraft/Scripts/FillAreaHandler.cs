using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FillAreaHandler : MonoBehaviour
{
    [SerializeField] private Slider fuelBar;
    [SerializeField] private Sprite greenBar, orangeBar, redBar;

    void Update(){
        if(fuelBar.value >= 0.7f){
            GetComponent<Image>().sprite = greenBar;
        }
        else if(fuelBar.value >= 0.35 && fuelBar.value < 0.7f){
            GetComponent<Image>().sprite = orangeBar;
        }
        else if(fuelBar.value < 0.35f){
            GetComponent<Image>().sprite = redBar;
        }
    }
}
