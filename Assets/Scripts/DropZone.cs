using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerDrag + "was dropped on" + gameObject.name);

        Card d = eventData.pointerDrag.GetComponent<Card>();
        if (d != null)
        {
            d.parentToReturnTo = this.transform;
        }
    }
}
