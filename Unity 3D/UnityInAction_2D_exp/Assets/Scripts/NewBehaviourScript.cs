using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Google_map_show : MonoBehaviour
{
    public RawImage img;
    void Start()
    {
        img = gameObject.GetComponent<RawImage>();
        StartCoroutine(GetRequest());
    }

    IEnumerator GetRequest()
    {
        WWW www = new WWW("https://www.openstreetmap.org/search?query=%D1%87%D0%B5%D0%BB%D1%8F%D0%B1%D0%B8%D0%BD%D1%81%D0%BA#map=17/55.17916/61.33437");

        // Wait for download to complete
        yield return www;

        //Renderer renderer = GetComponent<Renderer>();
        img.texture = www.texture;
        //img.texture = mytexture;
        //img.SetNativeSize();

    }
}