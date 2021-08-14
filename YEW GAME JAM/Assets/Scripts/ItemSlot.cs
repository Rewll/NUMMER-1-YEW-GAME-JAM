using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public RectTransform[] places;
    private int amountOfThingsFound;
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            if (eventData.pointerDrag.CompareTag("important"))
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = places[amountOfThingsFound].anchoredPosition;
                eventData.pointerDrag.GetComponent<DragDrop>().moveable = false;
                eventData.pointerDrag.GetComponent<RectTransform>().parent = transform;
                amountOfThingsFound++;
            }
            Debug.Log(eventData.pointerDrag.name);
        }
    }
}
