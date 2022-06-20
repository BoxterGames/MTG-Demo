using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TextureLoader : MonoBehaviour
{
    public Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>();
    public bool IsLoadingEnded;

    public string url = "https://images.earthcam.com/ec_metros/ourcams/fridays.jpg";
 
    public void LoadTexture(List<string> newTexturers)
    {
        Debug.Log("Loaded started");
        IsLoadingEnded = false;
        StartCoroutine(StartLoading(newTexturers));
    }

    private IEnumerator StartLoading(List<string> newTexturers)
    {
        foreach (var i in newTexturers)
        {
            if (textures.ContainsKey(i))
            {
                continue;
            }

            UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
            yield return www.SendWebRequest();

            textures.Add(i, ((DownloadHandlerTexture)www.downloadHandler).texture);

            Debug.Log("Load " + i);
        }

        IsLoadingEnded = true;
    }
}
