using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    // TODO: hide in inspector and assign at the start of the experiment
    public AudioData instructions;
    public Light speakingIndicator;
    public Light[] beaconLights;

    private AudioSource _audioSource;

    // TODO: mode variable for conditions
    // TODO: add onDestroyMethod to unsubscribe

    private void Awake()
    {
        instance = this;
        _audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        EventManager.instance.enteredStopPoint += OnStopEnter;
        speakingIndicator.enabled = false; // no speaking indication in the beginning
    }

    void Update()
    {

    }

    private void PlayNextAudio()
    {

        var clip = instructions.NextClip();

        if (clip)
        {
            speakingIndicator.enabled = true; // indicate speaking with a light
            foreach (Light l in beaconLights)
            {
                l.enabled = false;
            }
            _audioSource.clip = clip;
            _audioSource.Play();
            Invoke("OnAudioPlayed", clip.length);
        }
 
    }

    private void OnAudioPlayed()
    {
        speakingIndicator.enabled = false; // disable speaking indication
        foreach (Light l in beaconLights)
        {
            l.enabled = true;
        }
        EventManager.instance.PlayedInteraction();
    }

    private void OnStopEnter(bool audio)
    {
        if (audio)
        {
            PlayNextAudio();
        }
    }
}
