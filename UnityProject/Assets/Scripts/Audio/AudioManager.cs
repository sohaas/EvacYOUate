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
    [SerializeField] private AudioData aftershockAudios;
    private AudioSource _audioSource;
    
    public Light speakingIndicator;
    public Light[] beaconLights;

    void Awake()
    {
        instance = this;
        _audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        EventManager.instance.enteredStopPoint += OnStopEnter;
        EventManager.instance.requestedRepeat += RepeatAudio;
        EventManager.instance.timeIsUp += PlayAftershock;
        
        speakingIndicator.enabled = false; // no speaking indication in the beginning
    }

    bool Play(AudioClip clip)
    {
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

            return true;
        }

        return false;
    }

    void PlayNextAudio()
    {
        var clip = instructions.NextClip();

        if (Play(clip))
        {
            Invoke("OnAudioPlayed", clip.length);
        }
    }

    void RepeatAudio()
    {
        if (!playing)
        {
            var clip = instructions.LastClip();
            
            if (Play(clip))
            {
                Invoke("OnAudioRepeated", clip.length);
            }
        }
    }

    void PlayAftershock()
    {
        var clip = aftershockAudios.Clip(ExperimentManager._condition / 2);
        if (clip)
        {
            _audioSource.clip = clip;
            _audioSource.Play();
            
            Invoke("OnAftershockOver", clip.length);
        }
    }

    void OnAftershockOver()
    {
        EventManager.instance.AfterShock(MovementType.TELE);
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
        if (instructions.lastPlayedIndex == 0)
        {
            EventManager.instance.PlayedInteraction(MovementType.TELE);
        }
        else
        {
            EventManager.instance.PlayedInteraction(MovementType.CONTINUOUS);
        }
    }

    void OnAudioRepeated()
    {
        // disable speaking indication (TODO: outsource)
        speakingIndicator.enabled = false; 
        foreach (Light l in beaconLights)
        {
            l.enabled = true;
        }
        
        playing = false;
    }

    void OnStopEnter(bool audio)
    {
        if (audio)
        {
            PlayNextAudio();
        }
    }

    void OnDestroy()
    {
        EventManager.instance.enteredStopPoint -= OnStopEnter;
        EventManager.instance.requestedRepeat -= RepeatAudio;
        EventManager.instance.timeIsUp -= PlayAftershock;
    }
}
