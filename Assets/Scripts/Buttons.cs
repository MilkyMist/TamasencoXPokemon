using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public GameObject aboutScreen;
    public GameObject homeScreen;
    public GameObject deckBuildingScreen;

    public void AboutScreen()
    {
        Debug.Log("About Button Clicked");
        homeScreen.SetActive(false);
        aboutScreen.SetActive(true);
    }

    public void BackFromAboutScreen()
    {
        Debug.Log("Back From About Button Clicked");
        homeScreen.SetActive(true);
        aboutScreen.SetActive(false);
    }

    public void DeckBuildingScreen()
    {
        Debug.Log("Deck Building Button Clicked");
        homeScreen.SetActive(false);
        deckBuildingScreen.SetActive(true);
    }

    public void BackFromDeckBuildingScreen()
    {
        Debug.Log("Back From Deck Building Button Clicked");
        homeScreen.SetActive(true);
        deckBuildingScreen.SetActive(false);
    }
}
