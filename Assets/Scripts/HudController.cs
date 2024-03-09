using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HudController : MonoBehaviour
{
    public TextMeshProUGUI puntuacion;

    public GameObject[] vidas;

    // Update is called once per frame
    void Update()
    {
        puntuacion.text = GameManagerController.Instance.PuntosTotales.ToString();
    }

    public void actualizarPuntos(int puntos)
    {
        puntuacion.text = puntos.ToString();
    }

    public void desactivarVida(int indice)
    {
        vidas[indice].SetActive(false);
    }

    public void activarVida(int indice)
    {
        vidas[indice].SetActive(true);
    }

}
