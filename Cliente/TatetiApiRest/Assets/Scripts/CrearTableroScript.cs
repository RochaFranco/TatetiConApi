using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class CrearTableroScript : MonoBehaviour
{

    private void Start()
    {
        GameObject.Find("crearTablero").GetComponent<Button>().onClick.AddListener(CrearTablero);
    }

    public void CrearTablero()
    {
        StartCoroutine(CorrutinaCrearTablero());
    }

    private IEnumerator CorrutinaCrearTablero()
    {
        string url = "https://localhost:7299/crearTablero";
        WWWForm form = new WWWForm();
        form.AddField("tittle", "test data");
        

        using (UnityWebRequest web = UnityWebRequest.Post(url, form))
        {
            web.chunkedTransfer = false;

            web.useHttpContinue = false;

            yield return web.SendWebRequest();
            if (web.isNetworkError || web.isHttpError)
                Debug.Log(web.error);
        }
    }
}
