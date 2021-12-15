using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Audios")]
public class AudioData : ScriptableObject
{
    [SerializeField]
    private List<AudioClip> _clips;

    private int _lastPlayedIndex = -1;

    public AudioClip NextSong()
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
