using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int score = 0;
    public float curPosZ, startPosZ;


    private void Start() {
        startPosZ = transform.position.z;
    }
    private void Update() {
        CalculateScore();
    }
    private void CalculateScore(){
        curPosZ = transform.position.z;
        score = (int)((curPosZ - startPosZ) * 5f);
    }
}
