using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorusSuccesfulPass : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "plane")
        {
            this.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
        }
    }
}
