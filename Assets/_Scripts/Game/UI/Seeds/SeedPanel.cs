using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedPanel : UIPanel
{

    public SimpleObjectPool buttonObjectPool;
    public Transform contentPanel;

	private void Awake()
	{
        contentPanel = transform;
	}

	public override void Show()
	{
        RemoveButtons();
        AddButtons(PlantManager.Instance.seeds);
        base.Show();
	}


    private void RemoveButtons()
    {
        while (contentPanel.childCount > 0)
        {
            GameObject toRemove = transform.GetChild(0).gameObject;
            buttonObjectPool.ReturnObject(toRemove);
        }
    }

    private void AddButtons(List<Seed> seeds)
    {
        for (int i = 0; i < seeds.Count; i++)
        {
            Seed seed = seeds[i];
            GameObject newButton = buttonObjectPool.GetObject();
            newButton.transform.SetParent(contentPanel);

            SeedButton seedButton = newButton.GetComponent<SeedButton>();
            seedButton.Setup(seed);
        }
    }

   
}