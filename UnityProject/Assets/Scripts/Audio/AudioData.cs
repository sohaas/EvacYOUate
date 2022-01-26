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

    // returns next clip
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

    // returns the clip last played 
    public AudioClip LastClip()
    {
        if (lastPlayedIndex < _clips.Count)
        {
            return _clips[lastPlayedIndex];
        } 
        else
        {
            return null;
        }
    }

    // returns clip specified by index
    public AudioClip Clip(int index)
    {
        if (index >= 0 && index < _clips.Count)
        {
            return _clips[index];
        }
        else
        {
            return null;
        }
    }
}
