using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : ISingleton<SelectionManager> {

    protected SelectionManager(){}

    private ResourcesDisplayer resourcesDisplayer;
    private PlantDisplayer plantDisplayer;
    private GameObject actionPanel;

    public Parcel selected;

    private void Awake()
    {
        resourcesDisplayer = GetComponentInChildren<ResourcesDisplayer>();
        plantDisplayer = GetComponentInChildren<PlantDisplayer>();

        actionPanel = GameObject.Find("ActionPanel");

    }

	private void Start()
	{
        Unselect();
	}

    public void Unselect()
    {
        resourcesDisplayer.HideResources();
        plantDisplayer.HidePlant();
        actionPanel.SetActive(false);
        selected = null;
    }

	public void Select(Parcel parcel)
	{
        resourcesDisplayer.ShowResources(parcel);
        actionPanel.SetActive(true);
        selected = parcel;

        Plant plant = PlantManager.Instance.GetPlant(parcel.coordinates);

        if (plant != null) plantDisplayer.ShowPlant(plant);
        else plantDisplayer.HidePlant();
	}

    public void Refresh()
    {
        Select(selected);
    }



}
