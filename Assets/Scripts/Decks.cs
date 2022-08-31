using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Decks : MonoBehaviour
{
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
            
        }

        for (int i = 0; i < 50; i++)
        {
            deck1[i] = JsonConv.pokemonCardsJson.data[i];
            Debug.Log(deck1[i].name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
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
}