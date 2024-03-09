using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform personaje;

    private float tamanioCamara;
    private float alturaPantalla;
    // Start is called before the first frame update
    void Start()
    {
        tamanioCamara = Camera.main.orthographicSize;
        alturaPantalla = tamanioCamara * 2;
    }

    // Update is called once per frame
    void Update()
    {
        CalcularPosicion();
    }

    void CalcularPosicion()
    {
        int pantallaPersonaje = (int)(personaje.position.y / alturaPantalla);
        float alturaCamara = (pantallaPersonaje * alturaPantalla) + tamanioCamara;

        transform.position = new Vector3(transform.position.x,alturaCamara,transform.position.z);
    }
}
