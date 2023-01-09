using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propeller : MonoBehaviour
{
    public int propCount;
    [SerializeField] private GameObject prop;
    private Vector3 propPos = Vector3.zero;
    [SerializeField] private Transform shipPos;
    [SerializeField] private NewController newController;
    private int turnDirection;

    void Start()
    {
        if (this.name.Contains("Left"))
        {
            turnDirection = 1;
        }
        else turnDirection = -1;
        AddProps();

    }
    private void Update()
    {
        if (newController.GetSpeed() > 0)
        {
            transform.Rotate(Vector3.forward * 3f * turnDirection);
        }
    }

    private void AddProps()
    {
        propPos = this.transform.position;
        propCount = PlayerPrefs.GetInt("PropCount", 2);

        for (int i = 0; i < propCount; i++)
        {
            var bornAngle = (360 / propCount) * i;
            var obj = Instantiate(prop, propPos, Quaternion.Euler(0, 0, bornAngle));
            obj.transform.parent = this.transform;
        }
    }
}
