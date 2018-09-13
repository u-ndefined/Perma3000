using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

/// <summary>
/// Fonctions utile
/// <summary>
public static class GameData
{
  

    public enum Resource
    {
        Water,
        Stuff,
        A,
        B,
        C,
        D,
        E,
        F,
        None
    }

    public enum Tag
    {
        Vital,
        None
    }

    public enum plantType
    {
        Lentils,
        Tomatoes
    }

    public enum Panel
    {
        Actions,
        Parcel,
        ParcelPlant,
        Seeds,
        EndTurn
    }

   
}
