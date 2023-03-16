using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImagenPerfil : MonoBehaviour
{
    public WEBREQUEST web;

    private void Update()
    {
        Sprite sprite = Sprite.Create(web.GetTexture(),Rect.MinMaxRect(20,20,20,20),Vector2.zero );

        GetComponent<Image>().sprite = sprite;
    }
}
