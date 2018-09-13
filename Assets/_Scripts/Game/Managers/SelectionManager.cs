using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : ISingleton<SelectionManager> {

    protected SelectionManager(){}

    UIManager UI;

    public Parcel selected;

    private void Awake()
    {
        UI = UIManager.Instance;

    }

	private void Start()
	{
        //Unselect();
	}

    public void Unselect()
    {
        selected = null;
        UI.HideAll();
    }

	public void Select(Parcel parcel)
	{
        //UI.HideAll();
        selected = parcel;
        //UI.Show(GameData.Panel.Actions);
        //UI.Show(GameData.Panel.Parcel);
        //if (!parcel.empty) UI.Show(GameData.Panel.ParcelPlant);
        //else UI.Hide(GameData.Panel.ParcelPlant);
	}

    public void Refresh()
    {
        Select(selected);
    }



}
