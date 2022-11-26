using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingTrailEffect : MonoBehaviour
{
    [SerializeField] private TrailRenderer[] wingTrailEffects;
    [SerializeField] private float trailThickness;


    void Start()
    {

    }

    void Update()
    {
        WingTrailActivate(trailThickness);
    }

    private void WingTrailActivate(float trailThickness)
    {
        for (int i = 0; i < wingTrailEffects.Length; i++)
        {
            wingTrailEffects[i].startWidth = Mathf.Lerp(wingTrailEffects[i].startWidth, trailThickness, Time.deltaTime * 10f);
        }
    }
}
