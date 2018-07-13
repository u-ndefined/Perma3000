using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : ISingleton<SelectionManager> {

    protected SelectionManager(){}

    ResourcesDisplayer displayer;

    Parcel selected;

	private void Awake()
	{
        displayer = GameObject.Find("ResourcePanel").GetComponent<ResourcesDisplayer>();

	}

	private void Start()
	{
        displayer.HideResources();
	}

	public void Select(Parcel parcel)
	{
        displayer.ShowResources(parcel);
        selected = parcel;
	}
}
