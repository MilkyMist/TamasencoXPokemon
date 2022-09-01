using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Decks : MonoBehaviour
{
    public string[] allTypes = { "Fire", "Fighting", "Dragon", "Lightning", "Grass", "Water", "Fairy", "Psychic", "Darkness", "Metal", "Colorless" };
    public string[] allRarities = { "Amazing Rare", "Common", "LEGEND", "Promo", "Rare", "Rare ACE", "Rare BREAK", "Rare Holo", "Rare Holo EX", "Rare Holo GX", "Rare Holo LV.X", "Rare Holo Star", "Rare Holo V", "Rare Holo VMAX", "Rare Prime", "Rare Prism Star", "Rare Rainbow", "Rare Secret", "Rare Shining", "Rare Shiny", "Rare Shiny GX", "Rare Ultra", "Uncommon" };

    public GameObject cardTemplate;
    public Transform cardGrid;
    public static List<GameObject> cardList = new List<GameObject>();

    public static JsonConv.Pokemon[] deck1 = new JsonConv.Pokemon[50];
    void Start()
    {
        for (int i = 0; i < JsonConv.pokemonCardsJson.data.Length; i++)
        {
            cardList.Add(Instantiate(cardTemplate, new Vector3(0f, 0f, 0f), Quaternion.identity, cardGrid));
            
            cardList[i].GetComponent<Card>().id = JsonConv.pokemonCardsJson.data[i].id;
            cardList[i].GetComponent<Card>().name = JsonConv.pokemonCardsJson.data[i].name;
            cardList[i].GetComponent<Card>().hp = JsonConv.pokemonCardsJson.data[i].hp;
            cardList[i].GetComponent<Card>().type = JsonConv.pokemonCardsJson.data[i].types[0];
            cardList[i].GetComponent<Card>().rarity = JsonConv.pokemonCardsJson.data[i].rarity;
            cardList[i].name = JsonConv.pokemonCardsJson.data[i].name;

            CanvasGroup cg = cardList[i].AddComponent(typeof(CanvasGroup)) as CanvasGroup;
            
        }
    }

    public static void AssignArtwork(int i)
    {
        cardList[i].GetComponent<Image>().sprite = JsonConv.pokemonCardsJson.data[i].artwork;
    }

    public void OrderByHPAscending()
    {
        int minHP = 1000;
        int maxHP = 0;
        for (int i = 0; i < cardList.Count; i++)
        {
            if (Int32.Parse(cardList[i].GetComponent<Card>().hp) < minHP)
            {
                minHP = Int32.Parse(cardList[i].GetComponent<Card>().hp);
            }
            if (Int32.Parse(cardList[i].GetComponent<Card>().hp) > maxHP)
            {
                maxHP = Int32.Parse(cardList[i].GetComponent<Card>().hp);
            }
        }

        Debug.Log("minHP: " + minHP);
        Debug.Log("maxHP: " + maxHP);

        while (minHP != maxHP + 1)
        {
            for (int i = 0; i < cardList.Count; i++)
            {
                if (Int32.Parse(cardList[i].GetComponent<Card>().hp) == minHP)
                {
                    cardList[i].transform.SetAsLastSibling();
                }
            }
            minHP += 1;
        }
    }

    public void OrderByHPDescending()
    {
        int minHP = 1000;
        int maxHP = 0;
        for (int i = 0; i < cardList.Count; i++)
        {
            if (Int32.Parse(cardList[i].GetComponent<Card>().hp) < minHP)
            {
                minHP = Int32.Parse(cardList[i].GetComponent<Card>().hp);
            }
            if (Int32.Parse(cardList[i].GetComponent<Card>().hp) > maxHP)
            {
                maxHP = Int32.Parse(cardList[i].GetComponent<Card>().hp);
            }
        }

        Debug.Log("minHP: " + minHP);
        Debug.Log("maxHP: " + maxHP);

        while (minHP != maxHP + 1)
        {
            for (int i = 0; i < cardList.Count; i++)
            {
                if (Int32.Parse(cardList[i].GetComponent<Card>().hp) == minHP)
                {
                    cardList[i].transform.SetAsFirstSibling();
                }
            }
            minHP += 1;
        }
    }

    public void OrderByTypeAscending()
    {
        Array.Sort(allTypes, StringComparer.CurrentCultureIgnoreCase);

        for (int j = 0; j < allTypes.Length; j++)
        {
            Debug.Log(allTypes[j]);
            for (int i = 0; i < cardList.Count; i++)
            {
                if (cardList[i].GetComponent<Card>().type == allTypes[j])
                {
                    cardList[i].transform.SetAsLastSibling();
                }
            }
        }
    }

    public void OrderByTypeDescending()
    {
        Array.Sort(allTypes, StringComparer.CurrentCultureIgnoreCase);

        for (int j = 0; j < allTypes.Length; j++)
        {
            Debug.Log(allTypes[j]);
            for (int i = 0; i < cardList.Count; i++)
            {
                if (cardList[i].GetComponent<Card>().type == allTypes[j])
                {
                    cardList[i].transform.SetAsFirstSibling();
                }
            }
        }
    }

    public void OrderByRarityAscending()
    {
        Array.Sort(allRarities, StringComparer.CurrentCultureIgnoreCase);

        for (int j = 0; j < allRarities.Length; j++)
        {
            Debug.Log(allRarities[j]);
            for (int i = 0; i < cardList.Count; i++)
            {
                if (cardList[i].GetComponent<Card>().rarity == allRarities[j])
                {
                    cardList[i].transform.SetAsLastSibling();
                }
            }
        }
    }

    public void OrderByRarityDescending()
    {
        Array.Sort(allRarities, StringComparer.CurrentCultureIgnoreCase);

        for (int j = 0; j < allRarities.Length; j++)
        {
            Debug.Log(allRarities[j]);
            for (int i = 0; i < cardList.Count; i++)
            {
                if (cardList[i].GetComponent<Card>().rarity == allRarities[j])
                {
                    cardList[i].transform.SetAsFirstSibling();
                }
            }
        }
    }
}
