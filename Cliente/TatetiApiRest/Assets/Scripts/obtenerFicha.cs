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
    PonerFicha ponerFicha;

    public void Start()
    {
        GameObject.Find(boton).GetComponent<Button>().onClick.AddListener(VerTablero);
        ponerFicha = GameObject.Find(boton).GetComponent<PonerFicha>();
    }

    public void VerTablero()
    {
        StartCoroutine(ponerFicha.CorrutinaPonerFicha());
        StartCoroutine(CorrutinaObtenerFicha());

    }

    [System.Obsolete]
    private IEnumerator CorrutinaObtenerFicha()
    {
        string url = "https://localhost:7299/mandarFicha/" + fila + "/" + col;


        using (UnityWebRequest web = UnityWebRequest.Get(url))
        {
                web.chunkedTransfer = false;

                web.useHttpContinue = false;

                yield return web.SendWebRequest();
                if (web.isNetworkError || web.isHttpError)
                {
                    Debug.Log(web.error);
                }
                else
                {
                if (web.downloadHandler.text == "" || web.downloadHandler.text == " " || web.downloadHandler.text == null)
                {
                    StartCoroutine(ponerFicha.CorrutinaPonerFicha());
                    StartCoroutine(CorrutinaObtenerFicha());
                }
                Debug.Log(web.downloadHandler.text);
                outPutArea.text = web.downloadHandler.text;
            }


            /*do
            {
                yield return web.SendWebRequest();
                if (web.isNetworkError || web.isHttpError)
                    Debug.Log(web.error);
                else
                    Debug.Log(web.downloadHandler.text);
                outPutArea.text = web.downloadHandler.text;
                Esperar();

            } while (web.downloadHandler.text != null || web.downloadHandler.text != "" || web.downloadHandler.text != " ");*/
            
        }
    }

    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(5);
    }

}
