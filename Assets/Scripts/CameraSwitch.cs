using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera startCam;
    [SerializeField] private CinemachineVirtualCamera gameCam;
    public static CameraSwitch instance;


    void Awake()
    {
        instance = this;
    }

    public void ChangeCameraFunct()
    {
        if (startCam.Priority >= gameCam.Priority)
        {
            StartCoroutine(ChangeCamera());
        }
    }


    IEnumerator ChangeCamera()
    {
        yield return new WaitForSeconds(0.01f);
        gameCam.Priority = startCam.Priority + 1;
    }
}
