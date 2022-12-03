using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class WinLose : MonoBehaviour
{
    [SerializeField] private NewController newController;
    [SerializeField] private AudioSource WinSound;
    [SerializeField] private AudioSource buttonSound;
    public GameObject gameOverText, gameOverButton;
    public bool gameEnded, gameStarted = false;
    public float coinRate, numOfCoins, fuel, fuelConsumption, totalFuel;
    private float maxDistancetoFinish;


    private void Start()
    {
        coinRate = 1.0f;
        numOfCoins = 1000.0f;
        fuel = 100f;
        fuelConsumption = 1;
        totalFuel = fuel;
        StartCoroutine("DoCheck");
    }


    public void WinLevel()
    {
        if (!gameEnded)
        {
            newController.SetFwdSpeed(0);
            GameObject.FindWithTag("plane").GetComponent<Animator>().Play("WinPlane");
            GameObject.FindWithTag("confettis").transform.GetChild(0).transform.gameObject.SetActive(true);
            GameObject.FindWithTag("confettis").transform.GetChild(1).transform.gameObject.SetActive(true);
            GameObject.FindWithTag("confettis").transform.GetChild(2).transform.gameObject.SetActive(true);
            WinSound.Play();
            gameEnded = true;
            StartCoroutine(NextLevel());
        }
    }

    public void LoseLevel()
    {
        if (!gameEnded)
        {
            newController.SetFwdSpeed(0);
            gameOverText.GetComponent<TextMeshProUGUI>().enabled = true;
            gameOverButton.SetActive(true);
            gameEnded = true;
        }
    }

    public void RestartLevel()
    {
        buttonSound.Play();
        StartCoroutine("RestartLevelWait");
    }

    public bool IsFuelFinished()
    {
        if (fuel <= 0)
        {
            return true;
        }
        return false;
    }
    public void FuelCheck()
    {
        if (IsFuelFinished())
        {
            GameObject.FindWithTag("plane").GetComponent<Animator>().Play("FuelEmpty");
            LoseLevel();
        }

    }
    public void DecreaseFuel()
    {
        fuel -= fuelConsumption;
        FuelCheck();
    }

    public void IncreaseFuel(float fuelBoosterAmount)
    {
        fuel += fuelBoosterAmount;
        if (fuel > totalFuel)
        {
            fuel = totalFuel;
        }
    }

    IEnumerator DoCheck()
    {
        for (; ; )
        {
            if (!gameEnded && newController.GetSpeed() > 0)
            {
                gameStarted = true;
                DecreaseFuel();
            }

            yield return new WaitForSeconds(.1f);
        }
    }

    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        gameStarted = false;
    }

    IEnumerator RestartLevelWait()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameStarted = false;
    }
}

