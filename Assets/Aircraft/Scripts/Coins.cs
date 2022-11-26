using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public Score score;
    [SerializeField]private float rotateDegreesPerSecond;
    public GameObject particlesAll;

    private void Update() {
        TurnCoins();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "plane")
        {
            score.numOfCoins++;
            Explode();
            Destroy(this.gameObject);
        }
    }
    private void Explode(){
        GameObject particle = Instantiate(particlesAll, transform.position, new Quaternion(220f,0f,0f,0f));
        particle.GetComponent<ParticleSystem>().Play();
    }
    

    private void TurnCoins(){
        transform.Rotate(new Vector3(0, rotateDegreesPerSecond, 0) * Time.deltaTime);
    }
}
