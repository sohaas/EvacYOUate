using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AudioData")]
public class AudioData : ScriptableObject
{
    [SerializeField]
    private List<AudioClip> _clips;

    [System.NonSerialized]
    public int lastPlayedIndex = -1;

    public AudioClip NextClip()
    {
        lastPlayedIndex++;

        if (lastPlayedIndex < _clips.Count)
        {
            return _clips[lastPlayedIndex];
        } 
        else
        {
            return null;
        }
    }
}
