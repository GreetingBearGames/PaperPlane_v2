using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgressBar : MonoBehaviour
{
    [SerializeField] private Slider levelProgressBar;
    [SerializeField] private GameObject finishLine;
    private float maxDistancetoFinish;
    [SerializeField] private NewController newController;
    private void Awake()
    {
        maxDistancetoFinish = finishLine.transform.position.z - newController.transform.position.z;
    }

    void Update()
        {
            //if (isGameActive)
            //{
                float distance = finishLine.transform.position.z - newController.transform.position.z;
                levelProgressBar.value = 1 - (distance / maxDistancetoFinish);
            //}
        }
}
