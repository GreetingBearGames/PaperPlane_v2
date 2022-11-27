using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextLevelText : MonoBehaviour
{
    public Text txt;

    private void Awake() {
        var currentLevel = SceneManager.GetActiveScene().buildIndex + 2;
        txt.text = currentLevel.ToString();
    }
}
