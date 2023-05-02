using System.Collections;
using UnityEngine.Audio;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sounds 
{
    public string Name;
    public AudioClip Clip;
    [Range(0f, 1f)]
    public float Volume;
    [Range(.1f, 3f)]
    public float Pitch;
    [HideInInspector]
    public AudioSource Source;
    [Range(0f, 1f)]
    public float SBlend;


}
