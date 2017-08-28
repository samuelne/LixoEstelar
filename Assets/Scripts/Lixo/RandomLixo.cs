using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLixo : MonoBehaviour {

    // MAURO RODRIGO SPINETTI

    public GameObject[] Lixos;

    public bool escolheLixoParaCriar = false;
    public int lixoCriado;
    public Vector3 position;

    public int tempoDeIntervaloEntreCadaLixo = 2;

    public float timeRight;
    public float contagemProgressiva;


	private Jogador jogador;


	// Use this for initialization
	void Start () {

		jogador = GameObject.Find ("Jogador").GetComponent<Jogador> ();

        timeRight = 0;
		
	}
	
	// Update is called once per frame
	public void Update () {

		if (jogador.GetPause () == 0) {
			

			ContagemProgressiva ();


			if (timeRight >= tempoDeIntervaloEntreCadaLixo) {
				escolheLixoParaCriar = true;
			}


			if (escolheLixoParaCriar) {
				CriandoLixoAleatoriamente ();
			}	

		} else {


			return;
		}
	}

    public void ContagemProgressiva()
    {
        timeRight += Time.deltaTime;
        contagemProgressiva = Mathf.Round(timeRight);
    }


    public void CriandoLixoAleatoriamente()
    {


        for (int i = 0; i < 1; i++)
        {
            //tipo de lixo criado
            lixoCriado = Random.Range(0, 20);

            //posicao do lixo no eixo X
            position = new Vector3(Random.Range(-7, 8), Random.Range(6, 7));
            Instantiate(Lixos[lixoCriado], position, Quaternion.identity);

            escolheLixoParaCriar = false;
            timeRight = 0;
        }
    }


    IEnumerator Example()
    {
        CriandoLixoAleatoriamente();
        yield return new WaitForSeconds(tempoDeIntervaloEntreCadaLixo);

    }

}
