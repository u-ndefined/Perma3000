using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : ISingleton<ActionManager>
{
    protected ActionManager() {}
    
    PlantManager plantManager;
    SelectionManager selectionManager;

    //private void Awake()
    //{
    //    plantManager = PlantManager.Instance;
    //    selectionManager = SelectionManager.Instance;
    //}

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
