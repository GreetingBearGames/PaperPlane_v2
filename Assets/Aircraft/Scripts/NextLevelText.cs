using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class NextLevelText : MonoBehaviour
{
    public TextMeshProUGUI currentLevelText;
    private void Awake()
    {
        var currentLevel = PlayerPrefs.GetInt("SavedLevel", 1) + 1;
        currentLevelText.text = currentLevel.ToString();
        TinySauce.OnGameStarted(SceneManager.GetActiveScene().name);

    }
}
