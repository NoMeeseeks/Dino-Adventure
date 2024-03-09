using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player")){
            GameManagerController.Instance.perderVida();

            other.gameObject.GetComponent<PlayerController>().aplicarGolpe();
        }
        if (other.gameObject.CompareTag("bala"))
        {
            Destroy(this.gameObject);
        }
    }
}
