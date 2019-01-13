using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {

    Object[] myMusic;
    new AudioSource audio;

    // Use this for initialization
    void Start ()
    {
        myMusic = Resources.LoadAll("Audio/Music", typeof(AudioClip));
        audio = GetComponent<AudioSource>();
        PlayRandomMusic();
    }

    // Update is called once per frame
    void Update () {
        if (!audio.isPlaying)
        {
            PlayRandomMusic();
        }
    }

    private void PlayRandomMusic()
    {
        audio.clip = myMusic[Random.Range(0, myMusic.Length)] as AudioClip;
        audio.Play();
    }
}
