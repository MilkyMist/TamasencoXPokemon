using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class JsonConv : MonoBehaviour
{
    [System.Serializable]
    public class Images
    {
        public string small;
        public string large;
    }

    [System.Serializable]
    public class Pokemon
    {
        public byte id;
        public string name;
        public string hp;
        public string[] types;
        public string rarity;
        public Images images;
        public Sprite artwork;
    }

    [System.Serializable]
    public class PokemonData
    {
        public Pokemon[] data;
    }

    public static PokemonData pokemonCardsJson = new PokemonData();
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(GetRequest.pokemonCards);
        pokemonCardsJson = JsonUtility.FromJson<PokemonData>(GetRequest.pokemonCards);
        Debug.Log(pokemonCardsJson.data.Length);

        for (int i = 0; i < pokemonCardsJson.data.Length; i++)
        {
            pokemonCardsJson.data[i].id = (byte)i;
            StartCoroutine(DownloadArtwork(pokemonCardsJson.data[i].images.small, i));
        }
    }

    IEnumerator DownloadArtwork(string uri, int i)
    {
        using (UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture(uri))
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
                    Debug.Log("Downloading Image for: " + pokemonCardsJson.data[i].name);
                    pokemonCardsJson.data[i].artwork = Sprite.Create(((DownloadHandlerTexture)webRequest.downloadHandler).texture, new Rect(0, 0, ((DownloadHandlerTexture)webRequest.downloadHandler).texture.width, ((DownloadHandlerTexture)webRequest.downloadHandler).texture.height), new Vector2(0.5f, 0.5f));
                    Decks.AssignArtwork(i);
                    //Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    break;
            }
        }
    }
}
