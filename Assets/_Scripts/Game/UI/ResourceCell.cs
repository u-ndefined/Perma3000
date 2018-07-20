using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tacticsoft;
using TMPro;
using System.Text;

public class ResourceCell : TableViewCell 
{
    public TextMeshProUGUI ressource;
    public TextMeshProUGUI quantity;

    public void SetContent(KeyValuePair<GameData.Resource, float> resource)
    {
        ressource.text = resource.Key.ToString();
        quantity.text = resource.Value.ToString();
    }
}
