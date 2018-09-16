using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : ISingleton<ActionManager>
{
    protected ActionManager() {}

    private SelectionManager selectionManager;

    private float actions;

    private void Awake()
    {
        selectionManager = SelectionManager.Instance;
    }

    private void EndTurn()
    {
        
    }

    private void Plant()
    {
        
    }

    private void PullOut()
    {
        
    }




    //public void Plant(Seed seed)
    //{
    //    plantManager.PlantSeed(seed, selectionManager.selected);
    //    selectionManager.Refresh();
    //}

    //public void EndTurn()
    //{
    //    plantManager.NextTurn();
    //    selectionManager.Refresh();
    //}
}
