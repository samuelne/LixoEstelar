using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Dev Samuel.

public class ControleCena : MonoBehaviour
{
    [SerializeField]
    private GameObject pausePanel = null, buttonVoltar = null, buttonTentar = null;
    [SerializeField]
    private Jogador jogador = null;


    public static int controlePAUSE = 0;


    // Use this for initialization
    void Start()
    {
		
    }
	
    // Update is called once per frame
    void Update()
    {		

        PauseGame(false);

    }


    public void PauseGame(bool p)
    {

        if (Input.GetKeyDown(KeyCode.Escape) || p == true)
        {

            //JOGO PAUSADO
            if (controlePAUSE == 0)
            {
                
                pausePanel.SetActive(true);
                buttonVoltar.SetActive(true);
                buttonTentar.SetActive(true);
                jogador.SetPause(1);
                print("pausado");

            }

            //JOGO DESPAUSADO
            if (controlePAUSE == 1)
            {
                pausePanel.SetActive(false);
                buttonVoltar.SetActive(false);
                buttonTentar.SetActive(false);
                jogador.SetPause(0);
                print("Não pausado");
                controlePAUSE = controlePAUSE - 2;
            }

            controlePAUSE += 1;

        } 

    }

    public void TentarDeNovo()
    {
        controlePAUSE = 0;
        SceneManager.LoadScene("Stage1");

    }
}
