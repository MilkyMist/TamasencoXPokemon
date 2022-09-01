using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public byte id;
    public new string name;
    public string hp;
    public string type;
    public string rarity;

    public GameObject selectedCard;
    public Transform parentToReturnTo = null;

    void Awake()
    {
        selectedCard = GameObject.Find("Canvas/DeckBuildingScreen/SelectedCard");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        selectedCard.GetComponent<AssignSelectedCard>().AssignArtworkAndAtributes(gameObject);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentToReturnTo = this.transform.parent;
        this.transform.SetParent(this.transform.root);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.SetParent(parentToReturnTo);
        this.transform.SetAsFirstSibling();
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
