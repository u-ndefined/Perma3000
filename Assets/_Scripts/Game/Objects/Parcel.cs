using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Parcel : MonoBehaviour
{
    public Field field;
    public HexCoordinates coordinates;
    public bool empty;
    public Plant plant;

	private void Awake()
	{
        empty = true;

	}

	private void Start()
	{
        field.AddParcel(this);
	}
    
}
