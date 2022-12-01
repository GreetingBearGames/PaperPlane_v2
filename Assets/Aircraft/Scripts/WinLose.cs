using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class WinLose : MonoBehaviour
{
    [SerializeField] private NewController newController;
    public GameObject gameOverText, gameOverButton;
    public bool gameEnded, gameStarted = false;
    public float coinRate, numOfCoins, fuel, fuelConsumption;
    private float maxDistancetoFinish;


    private void Start()
    {
        coinRate = 1.0f;
        numOfCoins = 1000.0f;
        fuel = 100f;
        fuelConsumption = SceneManager.GetActiveScene().buildIndex + 1;
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
            gameEnded = true;
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameStarted = false;
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        gameStarted = false;
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
            LoseLevel();
        }

    }
    public void DecreaseFuel()
    {
        fuel -= fuelConsumption;
        FuelCheck();
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
}

