using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SeedButton : MonoBehaviour 
{
    private TextMeshProUGUI text;
    private Image icon;
    private Seed seed;

    private Button buttonComponent;

	private void Awake()
	{
        text = GetComponentInChildren<TextMeshProUGUI>();
        icon = GetComponentInChildren<Image>();
        buttonComponent = GetComponent<Button>();
	}

	private void Start()
    {
        
        buttonComponent.onClick.AddListener(HandleClick);
    }

    public void Setup(Seed _seed)
    {
        seed = _seed;
        icon.sprite = seed.icon;
        text.text = seed.type.ToString();
        
    }

    public void HandleClick()
    {
        //ActionManager.Instance.Plant(seed);
    }

    void OnMouseEnter()
    {
        //The mouse is no longer hove   ring over the GameObject so output this message each frame
        Debug.Log("Mouse is no longeqsdqr on GameObject.");
    }
    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        Debug.Log("Mouse is no longer on GameObject.");
    }
}
