using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : Singleton<SoundManager> {

    [SerializeField]
    private AudioClip clickClip = null;

    private List<AudioSource> sources = new List<AudioSource>();

    public void PlayClickClip()
    {
        PlaySound(clickClip);
    }

    private void PlaySound(AudioClip clip)
    {
        AudioSource source = GetAudioSource();
        source.clip = clip;
        source.Play();
    }

    private AudioSource GetAudioSource()
    {
        AudioSource source = gameObject.GetComponent<AudioSource>();
        if (source == null)
        {
            source = gameObject.AddComponent<AudioSource>();
            sources.Add(source);
        }
        return source;
    }
}