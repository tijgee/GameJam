using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;

    void Awake()
    {
        //ensure there is only one game manager
        if (!instance)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        //Uncomment line below if you need sounds to persist betweeen scenes
        //DontDestroyOnLoad(gameObject);
            
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " was not found.");
            return;
        }
         
        s.source.Play();
    }

    //To play sound, first have audio manager attached to empty game object in unity:
    //add element (sounds) to gamemanager in unity view
    //add FindObjectOfType<AudioManager>().Play("sound name"); to your script
}
