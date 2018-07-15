using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed 
{
    public GameData.plantType type;
    public Sprite icon;
    public int range;
    public Dictionary<Put, Put> puts;

    public Seed( GameData.plantType _type, Sprite _icon, int _range, Dictionary<Put, Put> _puts)
    {
        type = _type;
        icon = _icon;
        range = _range;
        puts = _puts;
    }
}
