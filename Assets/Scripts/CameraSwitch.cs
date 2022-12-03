using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera startCam;
    [SerializeField] private CinemachineVirtualCamera gameCam;
    [SerializeField] private CinemachineVirtualCamera finishCam;
    public static CameraSwitch instance;


    void Awake()
    {
        instance = this;
    }

    public void ChangeStartCamera()
    {
        if (startCam.Priority >= gameCam.Priority)
        {
            StartCoroutine(ChangeCamera1());
        }
    }

    public void ChangeFinishCamera()
    {
        StartCoroutine(ChangeCamera2());
    }


    IEnumerator ChangeCamera1()
    {
        yield return new WaitForSeconds(0.01f);
        gameCam.Priority = startCam.Priority + 1;
    }

    IEnumerator ChangeCamera2()
    {
        yield return new WaitForSeconds(0.01f);
        finishCam.Priority = gameCam.Priority + 1;
    }
}
