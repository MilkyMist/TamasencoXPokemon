using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IPointerClickHandler
{
    public byte id;
    public new string name;
    public string hp;
    public string type;
    public string rarity;

    public GameObject selectedCard;

    void Awake()
    {
        selectedCard = GameObject.Find("Canvas/DeckBuildingScreen/SelectedCard");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        print("I was clicked: "+ id);
        selectedCard.GetComponent<AssignSelectedCard>().AssignArtworkAndAtributes(gameObject);
    }

    
}
