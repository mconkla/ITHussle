using UnityEngine.Audio;
using System;
using UnityEngine.UI;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
  
    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            
                s.source.volume = MainMenue.stored;
                s.source.pitch = s.pitch;
                s.source.loop = s.loop;
            
        }
    }
  
    public void Play(string name)       //GameManager Plays Theme when Gamestarts
    {
    
            Sound s = Array.Find(sounds, sound => sound.name == name);
            s.source.Play();
     
     
        
    }
    public void Stop(string name)       //GameManager Stops Theme when Gamestarts
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Pause();
        
    }
    public void Resume(string name)     //GameManager Resumes Theme when continue
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.UnPause();

    }

}
