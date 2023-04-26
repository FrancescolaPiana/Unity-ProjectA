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
    private Light2D falò;



    private void Start()
    {
        falò = GetComponent<Light2D>();
        startLight = falò.intensity;
        startFallof = falò.falloffIntensity;
    }

    private void Update()
    {
        time += Time.deltaTime * (1 - UnityEngine.Random.Range(-randomSpeed, randomSpeed)) * Mathf.PI;
        falò.intensity = startLight + MathF.Sin(time * eachSec) * flickr;

        falò.falloffIntensity = startFallof + MathF.Sin(time * eachSec) * flickr;
    }


    
}
