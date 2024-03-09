using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public int monedaValor = 1;
    public AudioClip sonidoMoneda;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManagerController.Instance.sumarPuntos(monedaValor);
            Destroy(this.gameObject);
            AudioManagerController.Instance.reproducirSonido(sonidoMoneda);
        }

    }
}
