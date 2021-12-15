using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public AudioData AudioData;
    private AudioSource _audioSource;

    // TODO: mode variable for conditions

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        EventManager.instance.robotAt += OnTriggerPoint;
    }

    private void PlayNextAudio()
    {
        var clip = AudioData.NextSong();
        Debug.Log("Tried getting clip");

        if (clip)
        {
            Debug.Log(clip);
            _audioSource.clip = clip;
            _audioSource.Play();
        }
    }

    private void OnTriggerPoint(int id)
    {
        // need this method to control when audios are supposed to play
        Debug.Log("Audio Manager: On Trigger Point");
        PlayNextAudio();
    }
}
