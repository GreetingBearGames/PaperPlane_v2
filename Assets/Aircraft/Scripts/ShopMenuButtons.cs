using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopMenuButtons : MonoBehaviour
{
    public WinLose winLose;
    public Button fuelButton, incomeButton;
    [SerializeField] private Sprite deactiveIncomeImg, deactiveFuelImg;
    [SerializeField] private Sprite activeIncomeImg, activeFuelImg;
    [SerializeField] private AudioSource buttonSound;
    private TextMeshProUGUI fuelButtonAmount, incomeButtonAmount, fuelButtonLvl, incomeButtonLvl;


    private void Awake()
    {
        ColorBlock newColorBlockFuel = fuelButton.colors;
        ColorBlock newColorBlockIncome = incomeButton.colors;
    }


    private void Start()
    {
        fuelButtonAmount = fuelButton.gameObject.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        incomeButtonAmount = incomeButton.gameObject.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        fuelButtonLvl = fuelButton.gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        incomeButtonLvl = incomeButton.gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>();

        fuelButtonLvl.text = PlayerPrefs.GetInt("fuelUpgLvl", 1).ToString();
        incomeButtonLvl.text = PlayerPrefs.GetInt("incomeUpgLvl", 1).ToString();
        fuelButtonAmount.text = (int.Parse(fuelButtonLvl.text) * 20).ToString();
        incomeButtonAmount.text = (int.Parse(incomeButtonLvl.text) * 20).ToString();

    }
    private void Update()
    {
        if (!winLose.gameStarted)
        {
            fuelButton.gameObject.SetActive(true);
            incomeButton.gameObject.SetActive(true);
        }
        else
        {
            fuelButton.gameObject.SetActive(false);
            incomeButton.gameObject.SetActive(false);
        }

        if (winLose.numOfCoins < int.Parse(incomeButtonAmount.text))
        {
            incomeButton.GetComponent<Image>().sprite = deactiveIncomeImg;
            incomeButton.enabled = false;
        }
        else
        {
            incomeButton.GetComponent<Image>().sprite = activeIncomeImg;
            incomeButton.enabled = true;
        }
        if (winLose.numOfCoins < int.Parse(fuelButtonAmount.text))
        {
            fuelButton.GetComponent<Image>().sprite = deactiveFuelImg;
            fuelButton.enabled = false;
        }
        else
        {
            fuelButton.GetComponent<Image>().sprite = activeFuelImg;
            fuelButton.enabled = true;
        }
    }

    public void IncomeUpgrade()
    {
        winLose.numOfCoins -= int.Parse(incomeButtonAmount.text);
        winLose.coinRate *= 1.25f;
        buttonSound.Play();
        PlayerPrefs.SetInt("incomeUpgLvl", PlayerPrefs.GetInt("incomeUpgLvl", 1) + 1);
        incomeButtonLvl.text = PlayerPrefs.GetInt("incomeUpgLvl", 1).ToString();
        incomeButtonAmount.text = (int.Parse(incomeButtonLvl.text) * 20).ToString();
    }

    public void FuelUpgrade()
    {
        winLose.numOfCoins -= int.Parse(fuelButtonAmount.text);
        winLose.fuel += 14f;
        buttonSound.Play();
        PlayerPrefs.SetInt("fuelUpgLvl", PlayerPrefs.GetInt("fuelUpgLvl", 1) + 1);
        fuelButtonLvl.text = PlayerPrefs.GetInt("fuelUpgLvl", 1).ToString();
        fuelButtonAmount.text = (int.Parse(fuelButtonLvl.text) * 20).ToString();
        PlayerPrefs.SetInt("PropCount", PlayerPrefs.GetInt("PropCount", 2) + 1);
    }
}
