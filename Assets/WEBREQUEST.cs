using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using UnityEngine.UI;

public class WEBREQUEST : MonoBehaviour
{
    Texture2D textura;
    public GameObject profile_picture;
    void Awake()
    {  
        StartCoroutine(GetRequest("https://randomuser.me/api/?results=50&callback=randomuserdata."));
    }




    IEnumerator GetRequest(string uri)
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
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    ObtenerDatos(webRequest);

                    break;
            }
        }
    }
    void ObtenerDatos(UnityWebRequest webRequest)
    {
        //Obtengo todos los nombres y fotos
        string infoText="";
        
        JSONNode data = JSON.Parse(webRequest.downloadHandler.text);
        for (int i = 0; i < data["results"].Count; i++)
        {
            infoText = data["results"][i]["name"]["title"] + " " + data["results"][i]["name"]["first"] + " " + data["results"][i]["name"]["last"] + "\n";
            StartCoroutine(DownloadImage(data["results"][i]["picture"]["thumbnail"]));
            Debug.Log(infoText + " " + i);
        }


    }

    public Texture2D GetTexture()
    {
        return textura;
    }

    IEnumerator DownloadImage(string MediaUrl)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
        yield return request.SendWebRequest();
        /*if (request.isNetworkError || request.isHttpError)
            Debug.Log(request.error);*/
        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(request.error);
        }
        else
        {
            //imagen = ((DownloadHandlerTexture)request.downloadHandler).texture;
        }
    }
}
