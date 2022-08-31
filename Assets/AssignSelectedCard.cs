using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssignSelectedCard : MonoBehaviour
{
    public Image image;
    public Text text;

    public void AssignArtworkAndAtributes(GameObject card)
    {
        image.enabled = true;
        image.sprite = card.GetComponent<Image>().sprite;
        text.text = "HP : " + card.GetComponent<Card>().hp + "\nType : " + card.GetComponent<Card>().type + "\nRarity : " + card.GetComponent<Card>().rarity;
        //gameObject.GetChild(0).Text.text = "HP: " + card.name; +"\nType: " + card.GetComponent<Card>().type;
    }
}
