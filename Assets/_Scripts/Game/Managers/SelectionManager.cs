using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : ISingleton<SelectionManager> {

    protected SelectionManager(){}

    private ResourcesDisplayer ResourcesDisplayer;
    private GameObject actionPanel;

    public Parcel selected;

    private void Awake()
    {
        ResourcesDisplayer = GameObject.Find("ResourcePanel").GetComponent<ResourcesDisplayer>();
        actionPanel = GameObject.Find("ActionPanel");

    }

	private void Start()
	{
        Unselect();
	}

    public void Unselect()
    {
        ResourcesDisplayer.HideResources();
        actionPanel.SetActive(false);
        selected = null;
    }

	public void Select(Parcel parcel)
	{
        ResourcesDisplayer.ShowResources(parcel);
        actionPanel.SetActive(true);
        selected = parcel;
	}
}
