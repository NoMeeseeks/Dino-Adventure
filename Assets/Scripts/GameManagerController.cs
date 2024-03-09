using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerController : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManagerController Instance { get; private set; }
    public HudController hud;
    public int PuntosTotales { get; private set; }

    private int vidas = 3;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("ups");
        }
    }
    public void sumarPuntos(int puntos)
    {

        PuntosTotales = PuntosTotales + puntos;
        hud.actualizarPuntos(PuntosTotales);
    }
    public void perderVida()
    {
        vidas = vidas - 1;
        if(vidas == 0)
        {
            SceneManager.LoadScene(1);
        }
        hud.desactivarVida(vidas);
    }
    public bool recuperarVida()
    {
        if(vidas == 3)
        {
            return false;
        }
        hud.activarVida(vidas);
        vidas = vidas + 1;
        return true;
    }
}
