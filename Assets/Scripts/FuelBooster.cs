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

            StartCoroutine(PlaneSpeedUp(other.gameObject));
        }
    }

    IEnumerator PlaneSpeedUp(GameObject planeObj)
    {
        planeObj.transform.parent.GetComponent<NewController>().SetFwdSpeed(30);
        var speed = 30;
        var finalspeed = 15;
        float newSpeed;
        float elapsedTime = 0;
        float waitTime = 0.5f;

        while (elapsedTime < waitTime)
        {
            newSpeed = Mathf.Lerp(speed, finalspeed, (elapsedTime / waitTime));
            elapsedTime += Time.deltaTime;
            planeObj.transform.parent.GetComponent<NewController>().SetFwdSpeed(newSpeed);
            yield return null;
        }
    }
}
