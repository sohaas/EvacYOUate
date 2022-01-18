using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro.Examples;
using UnityEditorInternal;
using UnityEngine;

[System.Serializable]
public class CurrentPosition
{
    public List<float> CurrentPositionXYZ;
}

[System.Serializable]
public class AllPositions
{
    public List<CurrentPosition> CombinedPositions;
}

public class CapturePosition : MonoBehaviour
{
    private Transform _person;
    private List<float> _position;
    private List<CurrentPosition> _positions;

    // TODO: attach SaveJson to when final screen appears
    private int _frameCounter;
    
    void Start()
    {
        _frameCounter = 0; // TODO: Delete frameCounter once possible
        _person = gameObject.transform;
        _positions = new List<CurrentPosition>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_frameCounter < 50)
        {
            // Create a temporary list with current x, y, and z positions
            _position = new List<float>();
            _position.Add(_person.position.x);
            _position.Add(_person.position.y);
            _position.Add(_person.position.z);

            // Add the current position to the list of all positions
            _positions.Add(new CurrentPosition
            {
                CurrentPositionXYZ = _position
            });
        }
        else if (_frameCounter == 50)
        {
            AllPositions all = new AllPositions
            {
                CombinedPositions = _positions
            };
            
            SaveJson(all);
        }

        _frameCounter += 1;
    }

    public void SaveJson(AllPositions allPositions)
    {
        // Convert list to string so can be saved as json
        string jsonString2Save = JsonUtility.ToJson(allPositions);
        
        Debug.Log(jsonString2Save);
        
        // Save json file with positions as string
        File.WriteAllText(
            Path.Combine("Assets", "Recordings", "recording1.json"), jsonString2Save); // TODO: NamingConvention
    }
}
