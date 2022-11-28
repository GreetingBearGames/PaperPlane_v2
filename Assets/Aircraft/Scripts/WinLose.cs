using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class WinLose : MonoBehaviour
{
    [SerializeField] private NewController newController;
    public GameObject gameOverText,gameOverButton;
    private bool gameEnded;
    public void WinLevel(){
        if(!gameEnded){
            newController.SetFwdSpeed(0);
            GameObject.FindWithTag("plane").GetComponent<Animator>().Play("WinPlane");
            GameObject.FindWithTag("confettis").transform.GetChild(0).transform.gameObject.SetActive(true);
            GameObject.FindWithTag("confettis").transform.GetChild(1).transform.gameObject.SetActive(true);
            gameEnded = true;
        }   
    }

    public void LoseLevel(){
        if(!gameEnded){
            newController.SetFwdSpeed(0);
            gameOverText.GetComponent<TextMeshProUGUI>().enabled = true;
            gameOverButton.SetActive(true);
            gameEnded = true;
        }   
    }

    public void RestartLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
}

