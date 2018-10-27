using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientosJugador : MonoBehaviour {

    public float velocidad =0.1f;
    public float velocidadEscalera = 0.08f;
    public float salto = 5.0f;
    int sinGravedad = 0;
    int conGravedad = 1;
    bool derecha = true;
    public Rigidbody2D rb;
    bool suelo;

	// Use this for initialization
	void Start () {
		
	}

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Suelo"){
            suelo = true;
        }
    }

    // Update is called once per frame
    void Update () {

        if (Input.GetKey("right")){
            transform.position = new Vector3(
                transform.position.x + velocidad,
                transform.position.y,
                transform.position.z
            );

            if (!derecha)
            {
                Giro();
            }
        }


        if (Input.GetKey("left"))
        {
            transform.position = new Vector3(
                transform.position.x - velocidad,
                transform.position.y,
                transform.position.z
            );

            if (derecha)
            {
                Giro();
            }
        }

        if (Input.GetKey("space") && suelo)
        {
            Saltar(salto);
            suelo = false;
        }

        if (Input.GetKey("up"))
        {
            Subir();
        }



    }

    void Giro(){
        if (derecha){
            derecha = false;
        }else{
            derecha = true;
        }
        transform.localScale = new Vector3(
            - transform.localScale.x, 
            transform.localScale.y,
            transform.localScale.z
        );

    }

    void Volar(float impulso)
    {
        rb.velocity = new Vector3(0, impulso, 0);

    }

    void Saltar(float impulso)
    {
        rb.velocity = new Vector3(0, impulso, 0);


    }

    void Subir()
    {
        rb.gravityScale = sinGravedad;
        Debug.Log("Gravedad: "+ rb.gravityScale);
        transform.position = new Vector3(
            transform.position.x,
            transform.position.y + velocidadEscalera,
            transform.position.z
        );
    }


}
