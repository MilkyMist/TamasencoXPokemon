using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json.Linq;

public class GetRequest : MonoBehaviour
{
    int i;
    public static string pokemonCards;

    // Start is called before the first frame update
    void Start()
    {
        string requestURL = "https://api.pokemontcg.io/v2/cards?q=nationalPokedexNumbers:[1 TO 151]&select=name,rarity,hp,types,images";
        StartCoroutine(GetReq(requestURL));
    }

    IEnumerator GetReq(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    pokemonCards = webRequest.downloadHandler.text;
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    break;
            }
        }
    }
}
