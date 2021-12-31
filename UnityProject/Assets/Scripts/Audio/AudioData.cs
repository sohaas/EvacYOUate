using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AudioData")]
public class AudioData : ScriptableObject
{
    [SerializeField]
    private List<AudioClip> _clips;

    [System.NonSerialized]
    private int _lastPlayedIndex = -1;

    public AudioClip NextClip()
    {
        _lastPlayedIndex++;

        if (_lastPlayedIndex < _clips.Count)
        {
            return _clips[_lastPlayedIndex];
        } 
        else
        {
            return null;
        }
    }
}
