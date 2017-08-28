using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControleAnimacao : MonoBehaviour
{

    private Animator porta;
    private Jogador jogador;
    private AudioSource audioPorta;
    private AudioSource audioCamera;

    // Use this for initialization
    void Start()
    {
        porta = GameObject.Find("portaEsquerda").GetComponent<Animator>();
        jogador = GameObject.Find("Jogador").GetComponent<Jogador>();
        audioPorta = GameObject.Find("portaEsquerda").GetComponent<AudioSource>();
        audioCamera = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }
	
    // Update is called once per frame
    public void Update()
    {
        if (ControleCena.controlePAUSE == 0)
        {
      
            AnimacaoPorta();


        }
        else
        {
            audioCamera.Pause();
            audioPorta.Pause();
            return;

        }

    }


    float controleAnimacaoPorta = 0;

    public Sprite[] sprt;


    private void AnimacaoPorta()
    {
        

        if (jogador.GetMinuteCount() == 3 && jogador.secondsCount >= 0.1f && controleAnimacaoPorta == 0)
        {

			
            porta.SetInteger("animacaoPorta", 1);
            jogador.SetPause(1);
            controleAnimacaoPorta = 1;
            audioCamera.Pause();
            audioPorta.Play();

            //LixoCriado.SetVelocidadeQueda(0.4f, 4f);

        } 

        if (audioPorta != audioPorta.isPlaying && audioCamera != audioCamera.isPlaying)
        {

            audioCamera.Play();

        }



    }

    public void MudarSprite(int i)
    {

        Animator porta = GameObject.Find("portaEsquerda").GetComponent<Animator>();
        Jogador jogador = GameObject.Find("Jogador").GetComponent<Jogador>();
        SpriteRenderer fundo = GameObject.Find("Fundo").GetComponent<SpriteRenderer>();


        if (i == 1)
        {


            porta.SetInteger("animacaoPorta", 0);
            fundo.sprite = sprt[0];


        }

        if (i == 2)
        {


            jogador.SetPause(0);


        }


    }
}
