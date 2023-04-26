using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class fileright : MonoBehaviour
{
    public float flickr = 0.5f;
    public float eachSec = 3.0f;
    public float randomSpeed = 1.0f;

    private float time;
    private float startLight;
    private float startFallof;
    private Light2D fal�;



    private void Start()
    {
        fal� = GetComponent<Light2D>();
        startLight = fal�.intensity;
        startFallof = fal�.falloffIntensity;
    }

    private void Update()
    {
        time += Time.deltaTime * (1 - UnityEngine.Random.Range(-randomSpeed, randomSpeed)) * Mathf.PI;
        fal�.intensity = startLight + MathF.Sin(time * eachSec) * flickr;

        fal�.falloffIntensity = startFallof + MathF.Sin(time * eachSec) * flickr;
    }


    
}
