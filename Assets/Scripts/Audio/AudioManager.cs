using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public Sound[] l_sounds;

    void Awake()
    {
        foreach (Sound s in l_sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(l_sounds, sounds => sounds.objectName == name);
        s.source.Play();
    }
}
