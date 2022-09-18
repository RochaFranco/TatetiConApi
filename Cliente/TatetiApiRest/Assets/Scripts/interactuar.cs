using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using UnityEngine;

public class interactuar : MonoBehaviour
{
    [ContextMenu("CrearTablero")]
    public async Task hacerAlgo()
    {
        Debug.Log("toque el boton");

        string url = "https://localhost:7299/crearTablero";

        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = new Uri(url);

            HttpResponseMessage response = await client.GetAsync(url);
        }

        
    }

}
