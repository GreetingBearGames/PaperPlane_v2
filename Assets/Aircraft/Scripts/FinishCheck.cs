using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishCheck : MonoBehaviour
{
    public WinLose winLose;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "plane")
        {
            winLose.WinLevel();
        }
    }
}
