using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PonerFicha : MonoBehaviour
{

    [SerializeField]
    int col;
    [SerializeField]
    int fila;
    [SerializeField]
    string boton;

    public void Start()
    {
        
    }

    public void CrearTablero()
    {
        StartCoroutine(CorrutinaPonerFicha());
    }

    [System.Obsolete]
    public IEnumerator CorrutinaPonerFicha()
    {

        string url = "https://localhost:7299/ponerFicha";
        string json = "{\"fila\": " + fila + ",\"col\": " + col + "}";
        byte[] myData = System.Text.Encoding.Default.GetBytes(json);

        using (UnityWebRequest web = UnityWebRequest.Put(url,myData))
        {
            web.chunkedTransfer = false;

            web.useHttpContinue = false;

                web.SetRequestHeader("Content-Type", "application/json");
                yield return web.SendWebRequest();
                if (web.result != UnityWebRequest.Result.Success)
                {
                    Debug.Log(web.error);
                }
                else
                {
                    //Debug.Log("Upload complete!");
                }
        }
    }

    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(5);
    }
}
