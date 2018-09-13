using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputParcel : MonoBehaviour, IPointerClickHandler
{
    private Parcel parcel;

	private void Awake()
	{
        parcel = GetComponent<Parcel>();
	}

	public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("hello");
        SelectionManager.Instance.Select(parcel);
    }
}
