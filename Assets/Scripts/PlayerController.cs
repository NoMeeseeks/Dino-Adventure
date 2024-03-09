using System.Collections;
using System.Collections.Generic;
using UnityEngine;
   using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    public float velocidad;
    public float fuerzaSalto;
    public float fuerzaGolpe;

    public LayerMask Suelo;
    public AudioClip sonidoSalto;

    public GameObject bala;
 
    private Rigidbody2D rigidbody;
    private BoxCollider2D boxCollider;
    private Animator animator;

    private bool mirandoOrientacion;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Respawn"))
        {
                SceneManager.LoadScene("LevelOne");
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        procesarMovimiento();
        procesarSalto();
        if (Input.GetKeyDown(KeyCode.F))
        {
            Instantiate(bala, transform.position, Quaternion.identity);
        }
    }

    void procesarMovimiento()
    {
        float inputMovimiento = Input.GetAxis("Horizontal");

        if(inputMovimiento != 0f)
        {
            animator.SetBool("estaCorriendo", true);
        }
        else
        {
            animator.SetBool("estaCorriendo", false);
        }

        rigidbody.velocity = new Vector2(inputMovimiento * velocidad, rigidbody.velocity.y);

        gestionarOrientacion(inputMovimiento);
    }

    void gestionarOrientacion(float inputMovimiento)
    {
        if( (mirandoOrientacion == false && inputMovimiento < 0) || (mirandoOrientacion == true && inputMovimiento > 0) ) 
        {
            mirandoOrientacion = !mirandoOrientacion;
            transform.localScale = new Vector2(-transform.localScale.x,transform.localScale.y);
        }
    }

    bool tocandoSuelo()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center,new Vector2(boxCollider.bounds.size.x,boxCollider.bounds.size.y),0f,Vector2.down,0.2f,Suelo);
        return raycastHit.collider != null;
    }
    void procesarSalto()
    {
        if (Input.GetKeyDown(KeyCode.Space) && tocandoSuelo()) 
        {
            rigidbody.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            AudioManagerController.Instance.reproducirSonido(sonidoSalto);
        }
    }
    public void aplicarGolpe()
    {
        Vector2 direccionGolpe;
        if (rigidbody.velocity.x > 0)
        {
            direccionGolpe = new Vector2(-4, 3);
        }
        else
        {
            direccionGolpe = new Vector2(4, 3);
        }
        rigidbody.AddForce(direccionGolpe * fuerzaGolpe);
    }
}
