using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Agregamos
using UnityEngine.UI;
public class JugadorController : MonoBehaviour
{
    //Declarlo la variable de tipo RigidBody que luego asociaremos a nuestro
private Rigidbody rb;
    //Inicializo el contador de coleccionables recogidos
    private int contador;
    //Inicializo variables para los textos
    public Text textoContador, textoGanar;
    //Declaro la variable pública velocidad para poder modificarla desde la
public float velocidad;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        contador = 0;
       
        setTextoContador();
        textoGanar.text = "";
    }
    void FixedUpdate()
    {
    float movimientoH = Input.GetAxis("Horizontal");
        float movimientoV = Input.GetAxis("Vertical");
    Vector3 movimiento = new Vector3(movimientoH, 0.0f,movimientoV);
    rb.AddForce(movimiento * velocidad);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coleccionable"))
        {
            //Desactivo el objeto
            other.gameObject.SetActive(false);
contador = contador + 1;
            //Actualizo elt exto del contador
            setTextoContador();
        }
    }
void setTextoContador()
    {
        textoContador.text = "Contador: " + contador.ToString();
        if (contador >= 12)
        {
            textoGanar.text = "¡Ganaste!";
        }
    }
}