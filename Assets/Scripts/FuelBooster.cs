using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelBooster : MonoBehaviour
{
    [SerializeField] WinLose winLose;
    [SerializeField] float fuelIncreaseRate = 0.3f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "plane")
        {
            winLose.IncreaseFuel(winLose.totalFuel * fuelIncreaseRate);
        }
    }
}
