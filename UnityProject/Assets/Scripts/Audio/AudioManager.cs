using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public bool playing = true;

    // TODO: hide in inspector and assign at the start of the experiment
    public AudioData instructions;
    public Light speakingIndicator;
    public Light[] beaconLights;

    private AudioSource _audioSource;

    // TODO: mode variable for conditions
    // TODO: add onDestroyMethod to unsubscribe

    void Awake()
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

    void PlayNextAudio()
    {

        var clip = instructions.NextClip();

        if (clip)
        {
            // indicate speaking with a light (TODO: outsource)
            speakingIndicator.enabled = true; 
            foreach (Light l in beaconLights)
            {
                l.enabled = false;
            }

            // play audio
            _audioSource.clip = clip;
            _audioSource.Play();
            playing = true;

            Invoke("OnAudioPlayed", clip.length);
        }
 
    }

    void OnAudioPlayed()
    {
        // disable speaking indication (TODO: outsource)
        speakingIndicator.enabled = false; 
        foreach (Light l in beaconLights)
        {
            l.enabled = true;
        }
        
        playing = false;
        Debug.Log(instructions.lastPlayedIndex);
        if (instructions.lastPlayedIndex == 0)
        {
            EventManager.instance.PlayedInteraction(MovementType.TELE);
        }
        else
        {
            EventManager.instance.PlayedInteraction(MovementType.CONTINUOUS);
        }
    }

    void OnStopEnter(bool audio)
    {
        if (audio)
        {
            PlayNextAudio();
        }
    }
}
