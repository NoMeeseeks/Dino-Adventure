using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidaController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            bool vidaRecuperada = GameManagerController.Instance.recuperarVida();
            if (vidaRecuperada)
            {
                Destroy(this.gameObject);
            }
        }

    }
}
