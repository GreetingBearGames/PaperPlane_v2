using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTextureSlide : MonoBehaviour
{
    private Material textureMaterial;
    private float offset;
    [SerializeField] public float scrollSpeed;


    void Start()
    {
        textureMaterial = GetComponent<Renderer>().material;
    }


    void Update()
    {
        offset = Mathf.Repeat(Time.time * scrollSpeed, 1);
        textureMaterial.SetTextureOffset("_BaseMap", new Vector2(0f, -offset));

        //HizArttirma();   //Arka planın da gitgide hızlanmasını istiyorsan fonksiyon oluştur 
    }
}
