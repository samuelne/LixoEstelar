using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LixoCriado : MonoBehaviour
{

    // MAURO RODRIGO SPINETTI

    private float velocidadeQueda;

    public void SetVelocidadeQueda(float a, float b)
    {

        this.velocidadeQueda = Random.Range(a, b);

    }

    private float velocidadeGiro;
    private int ladoGiro;
    private Vector3 ladoGiroVector;

    public int tipoDeLixo;

    private Jogador jogador;


    // Use this for initialization
    void Start()
    {

        jogador = GameObject.Find("Jogador").GetComponent<Jogador>();


        velocidadeQueda = Random.Range(0.2f, 2f);
        velocidadeGiro = Random.Range(0, 0.7f);

        VerificaLadoGiro();
        	
    }



	
    // Update is called once per frame
    public void Update()
    {

        if (jogador.GetPause() == 0)
        {
			

            GirandoObjeto(velocidadeQueda, velocidadeGiro);

            if (transform.position.y < -6.5f)
            {

                jogador.PerdeVida();
                Destroy(gameObject);

            }

        }
        else
        {

            return;

        }

    }

    public void VerificaLadoGiro()
    {
        // verifica o lado que o objeto irá girar
        ladoGiro = Random.Range(0, 2);
        switch (ladoGiro)
        {
            case 0:
                ladoGiroVector = Vector3.forward;
                break;
            case 1:
                ladoGiroVector = Vector3.back;
                break;       
        }
    }



    public void GirandoObjeto(float velocidadeDaQueda, float velocidadeDoGiro)
    {
        transform.Translate(Vector3.down * velocidadeDaQueda * Time.deltaTime, Space.World);
        transform.Rotate(ladoGiroVector * velocidadeDoGiro);
    }
        

}
