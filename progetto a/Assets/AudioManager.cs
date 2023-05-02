using System.Collections;
using UnityEngine.Audio;
using System.Collections.Generic;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sounds[] Sounds;
    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sounds S in Sounds)
        {
            S.Source = gameObject.AddComponent<AudioSource>();
            S.Source.clip = S.Clip;
            S.Source.spatialBlend = S.SBlend;
            S.Source.volume = S.Volume;
            S.Source.pitch = S.Pitch;

        }
    }

    public void Play(string Name)
    {
       Sounds s = Array.Find(Sounds, Sound => Sound.Name == Name);
        s.Source.Play();
    }

}
