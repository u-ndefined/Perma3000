using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Seed", menuName = "Scriptable/Seed")]
public class ScriptableSeed : ScriptableObject 
{
    public Sprite icon;
    public GameData.plantType type;
    public int range;
    public EditorInputOutput[] inputsOutputs;

    public Dictionary<Put, Put> Puts()
    {
        Dictionary<Put, Put> puts = new Dictionary<Put, Put>();
        foreach(EditorInputOutput p in inputsOutputs)
        {
            puts.Add(p.Input(), p.Output() );
        }
        return puts;
    }
}
