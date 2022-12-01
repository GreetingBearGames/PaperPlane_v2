using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public WinLose winLose;
    [SerializeField] private AudioSource impactSound;
    private bool istriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!istriggered & other.transform.tag == "plane")
        {
            impactSound.Play();
            winLose.LoseLevel();
            istriggered = true;
        }
    }
}
