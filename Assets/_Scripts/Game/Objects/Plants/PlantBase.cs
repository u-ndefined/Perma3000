using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantBase : ScriptableObject 
{
    public Sprite icon;
    public GameData.plantType type;
    public EditorResource[] editorInputs;
    public EditorResource[] editorOutputs;

    public int HP;

    [Header("Harvest")]
    public bool harvestable;
    public int harvestTime;
    public float food;


    public Dictionary<GameData.Resource, float> ArrayToDictionary(EditorResource[] resources)
    {
        Dictionary<GameData.Resource, float> result = new Dictionary<GameData.Resource, float>();
        foreach (EditorResource r in resources)
        {
            result.Add(r.type, r.quantity);
        }
        return result;
    }

    public virtual void Harvest()
    {
        Spaceship.Instance.food += food;
    }

    public virtual void Grow()
    {
        
    }

    public virtual Dictionary<GameData.Resource, float> GetInputs()
    {
        return ArrayToDictionary(editorInputs);
    }

    public virtual Dictionary<GameData.Resource, float> GetOutputs()
    {
        return ArrayToDictionary(editorOutputs);
    }

}
