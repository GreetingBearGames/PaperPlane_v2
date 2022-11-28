using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    [SerializeField] GameObject playerObj;
    private List<GameObject> cloudList = new List<GameObject>();


    void Start()
    {
        SpecifyLocation();
    }


    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, playerObj.transform.position.z);
    }


    private void SpecifyLocation()
    {
        foreach (GameObject cloudObj in GameObject.FindGameObjectsWithTag("cloud"))
        {

            cloudList.Add(cloudObj);
            cloudObj.transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
            var startPos = cloudObj.transform.position;
            cloudObj.transform.position = new Vector3(Random.Range(startPos.x - 10f, startPos.x + 10f),
                                                    Random.Range(startPos.y + 0f, startPos.y + 2f),
                                                    Random.Range(startPos.z - 10f, startPos.z + 10f));
        }
    }
}
