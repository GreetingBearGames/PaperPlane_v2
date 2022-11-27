using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public WinLose winLose;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "plane")
        {
            winLose.LoseLevel();
        }
    }
}
