using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public AudioData AudioData;
    private AudioSource _audioSource;

    // TODO: mode variable for conditions
    // TODO: add onDestroyMethod to unsubscribe

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        EventManager.instance.enteredInteraction += OnTriggerPoint;
    }

    void Update()
    {

    }

    private void PlayNextAudio()
    {
        var clip = AudioData.NextSong();

        if (clip)
        {
            _audioSource.clip = clip;
            _audioSource.Play();
            Invoke("OnAudioPlayed", clip.length);
        }
    }

    private void OnAudioPlayed()
    {
        EventManager.instance.PlayedInteraction();
    }

    private void OnTriggerPoint()
    {
        // need this method to control when audios are supposed to play
        PlayNextAudio();
    }
}
