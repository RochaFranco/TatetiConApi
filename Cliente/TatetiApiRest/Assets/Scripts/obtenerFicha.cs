using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class obtenerFicha : MonoBehaviour
{
    [SerializeField]
    int fila;
    [SerializeField]
    int col;
    [SerializeField]
    string boton;
    [SerializeField]
    InputField outPutArea;

    public void Start()
    {
        GameObject.Find(boton).GetComponent<Button>().onClick.AddListener(VerTablero);
    }

    public void VerTablero()
    {
        StartCoroutine(CorrutinaVerTablero());
    }

    private IEnumerator CorrutinaVerTablero()
    {
        string url = "https://localhost:7299/mandarFicha/" + fila + "/" + col;


        using (UnityWebRequest web = UnityWebRequest.Get(url))
        {
            yield return web.SendWebRequest();
            if (web.isNetworkError || web.isHttpError)
                Debug.Log(web.error);
            else
                outPutArea.text = web.downloadHandler.text;
        }
    }
}
