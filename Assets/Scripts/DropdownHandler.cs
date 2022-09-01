using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownHandler : MonoBehaviour
{
    public GameObject DeckGrid1;
    public GameObject DeckGrid2;
    public GameObject DeckGrid3;
    public GameObject SelectedDeckText;

    // Start is called before the first frame update
    void Start()
    {
        var dropdown = transform.GetComponent<Dropdown>();

        dropdown.onValueChanged.AddListener(delegate { DropDownItemSelected(dropdown); });
    }

    void DropDownItemSelected(Dropdown dropdown)
    {
        int index = dropdown.value;

        Debug.Log("Value Changed");
        DeckGrid1.SetActive(false);
        DeckGrid2.SetActive(false);
        DeckGrid3.SetActive(false);
        if (dropdown.options[index].text == "Deck 1")
        {
            DeckGrid1.SetActive(true);
            SelectedDeckText.GetComponent<Text>().text = "Deck 1";
        }
        else if (dropdown.options[index].text == "Deck 2")
        {
            DeckGrid2.SetActive(true);
            SelectedDeckText.GetComponent<Text>().text = "Deck 2";
        }
        else if (dropdown.options[index].text == "Deck 3")
        {
            DeckGrid3.SetActive(true);
            SelectedDeckText.GetComponent<Text>().text = "Deck 3";
        }
    }
}
