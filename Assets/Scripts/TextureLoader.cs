using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// Class that use to load texture from server. 
/// Probably it can extended and load data about Card: (texture + title + description + List{ effectsIDs, chooserId })
/// </summary>
public class TextureLoader : MonoBehaviour
{
    /// <summary>
    /// Textures dictionary, use card "title" to get texture 
    /// </summary>
    public Dictionary<string, Texture2D> Textures = new Dictionary<string, Texture2D>();

    /// <summary>
    /// Is loading in process
    /// </summary>
    public bool IsLoadingEnded;

    /// <summary>
    /// TODO: use as new parameter in void StartLoading(string url).
    /// </summary>
    public string url = "https://images.earthcam.com/ec_metros/ourcams/fridays.jpg";
 
    /// <summary>
    /// Load all textures to title. Use once before battle, doesnt support to add texture 
    /// </summary>
    /// <param name="titles">Card titles</param>
    public void LoadTexture(List<string> titles)
    {
        Debug.Log("Loaded started");
        IsLoadingEnded = false;
        StartCoroutine(StartLoading(titles));
    }

    private IEnumerator StartLoading(List<string> titles)
    {
        foreach (var i in titles)
        {
            //Dont load different texture to same card
            if (Textures.ContainsKey(i))
            {
                continue;
            }

            UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
            yield return www.SendWebRequest();

            Textures.Add(i, ((DownloadHandlerTexture)www.downloadHandler).texture);

            Debug.Log("Load " + i);
        }

        IsLoadingEnded = true;
    }
}
