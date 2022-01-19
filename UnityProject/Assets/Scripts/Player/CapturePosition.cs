using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro.Examples;
using UnityEngine;

[System.Serializable]
public class CurrentPosition // a game objects position and rotation
{
    public List<float> CurrentPositionXYZ;
    public List<float> CurrentRotationXYZ;
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
    private List<float> _rotation;
    private static List<CurrentPosition> _positions;

    void Start()
    {
        _person = gameObject.transform;
        _positions = new List<CurrentPosition>();
    }

    // Update is called once per frame
    void Update()
    {
        // Create a temporary list with current x, y, and z positions
        _position = new List<float>();
        _position.Add(_person.position.x);
        _position.Add(_person.position.y);
        _position.Add(_person.position.z);
        
        // Create a temporary list with current x, y, and z rotations
        _rotation = new List<float>();
        _rotation.Add(_person.rotation.x);
        _rotation.Add(_person.rotation.y);
        _rotation.Add(_person.rotation.z);

        // Add the current position to the list of all positions
        _positions.Add(new CurrentPosition
        {
            CurrentPositionXYZ = _position,
            CurrentRotationXYZ = _rotation
        });
    }

    public static void SaveJson()
    {
        // Combine all information to one file
        AllPositions allPositions = new AllPositions
        {
            CombinedPositions = _positions
        };
        
        // Convert to string so can be saved as json
        string jsonString2Save = JsonUtility.ToJson(allPositions);
        
        Debug.Log(jsonString2Save);
        
        // Save json file with naming convention day-month-year_hour-minute-second.json
        File.WriteAllText(
            Path.Combine("Assets", "Recordings", System.DateTime.Now.ToString().Replace(" ", "_").Replace('.', '-').Replace(':', '-') + ".json"), jsonString2Save); // TODO: NamingConvention
    }
}
