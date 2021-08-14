using UnityEngine.Audio;
using UnityEngine;
using System;

public class AvocadoAudioManager : MonoBehaviour
{
    
    public Sound[] sounds;
    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.Volume;
            s.source.pitch = s.Pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        FindObjectOfType<AvocadoAudioManager>().Play("AvocadoMuziek");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.Name == name);
        s.source.Play();
    }

    public void StopPlaying(string sound)
    {
        Sound s = Array.Find(sounds, item => item.Name == sound);
        s.source.Stop();
    }
}
