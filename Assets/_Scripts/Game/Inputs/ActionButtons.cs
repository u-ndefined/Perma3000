using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionButtons : MonoBehaviour 
{
    PlantManager plantManager;
    SelectionManager selectionManager;

	private void Awake()
	{
        plantManager = PlantManager.Instance;
        selectionManager = SelectionManager.Instance;
	}

	public void Plant()
    {
        plantManager.PlantSeed(plantManager.RandomSeed(), selectionManager.selected);
        selectionManager.Refresh();
    }

    public void EndTurn()
    {
        plantManager.NextTurn();
        selectionManager.Refresh();
    }
}
