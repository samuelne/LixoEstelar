using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;


//Developed by Samuel.

public class Jogador : MonoBehaviour
{
    // Velocidade do jogador.
    private float speed = 5;

    // Vida do Jogador
    private int vidaJogador = 100;

    public void SetVidaJogador(int v)
    {

        this.vidaJogador = v;

    }

    public int GetVidaJogador()
    {

        return this.vidaJogador;

    }

    public void PerdeVida()
    {

        print(vidaJogador);

        vidaJogador -= 10;

        Text vidaText = GameObject.Find("vidaText").GetComponent<Text>();

        vidaText.text = vidaJogador.ToString() + "%";


        if (vidaJogador == 0)
        {


            SceneManager.LoadScene("Stage1");

        }

    }

    // Quantidade de metal coletado para poder atirar.
    private float atirarMetal = 200;

    // GameObject para selecionar o prefab do tiro.
    [SerializeField]
    private GameObject prefabTiro = null;

    // Selecionar spawn no jogador da onde sairá o tiro.
    [SerializeField]
    private Transform tiroSpawn = null;

    // Controla o animator do jogador.
    private Animator animatorPlayer = null;


    // Quantidade de lixo organico coletado.
    private int organico = 0;

    // Quantidade de lixo metal coletado.
    private int metal = 0;

    // Quantidade de lixo papel coletado.
    private int papel = 0;

    // Quantidade de lixo vidro coletado.
    private int vidro = 0;

    // Quantidade de lixo plastico coletado.
    private int plastico = 0;

    // Controle de mudança de animação.
    private int mudarAnimation = 0;

    // Set a velocidade do jogador.
    public void SetSpeed(float s)
    {

        this.speed = s;

    }

    // Get a velocidade do jogador.
    public float GetSpeed()
    {
      
        return speed;

    }


    private ParticleSystem particle;


    // Use this for initialization
    void Start()
    {
        GameObject animacaoObjeto = GameObject.Find("Animacao");
        animatorPlayer = animacaoObjeto.GetComponent <Animator>();

        particle = GameObject.Find("Afterburner").GetComponent <ParticleSystem>();
    

        //É preciso dar o start da animação pois se não dará problema na colisão
        mudarAnimation = 1;
        animatorPlayer.SetInteger("Controle", 1);

    }
	
    // Update is called once per frame
    void Update()
    {
        
        if (ControleCena.controlePAUSE == 0)
        {
            MoveJoystick();
            MovePlayerTec();
            MudarAnimacao();
            Atirar(false);
            TempoJogo();
            particle.Play();

            Button btn = GameObject.Find("ButtonAtirar").GetComponent<Button>();

            btn.enabled = true;

        }
        if (ControleCena.controlePAUSE != 0 || pause == 1)
        {
            particle.Stop();
            Button btn = GameObject.Find("ButtonAtirar").GetComponent<Button>();
            btn.enabled = false;

            return;
        }




    }

    private int pause = 0;

    public int GetPause()
    {

        return this.pause;

    }

    public void SetPause(int p)
    {

        this.pause = p;

    }



    public float secondsCount;

    public float GetSecondsCount()
    {

        return secondsCount;

    }

    public int minuteCount;

    public int GetMinuteCount()
    {

        return minuteCount;

    }

    private int hourCount;

    private void TempoJogo()
    {        

        Text tempoText = GameObject.Find("tempoText").GetComponent<Text>();   

        secondsCount += Time.deltaTime;

        tempoText.text = String.Format("{0:00}:{1:00}:{2:00}", hourCount, minuteCount, secondsCount);

        if (secondsCount >= 59)
        {
            minuteCount++;
            secondsCount = 0;
        }
        else if (minuteCount >= 59)
        {
            hourCount++;
            minuteCount = 0;
        }

    }


    private void AnimacaoPorta()
    {
      
        Animator porta = GameObject.Find("portaEsquerda").GetComponent<Animator>();


        if (minuteCount == 3)
        {

            porta.SetInteger("animacaoPorta", 1);
        

        
        }

    }

    public bool PauseButton()
    {

        bool p = false;

        return p;

    }

    [SerializeField]
    private VirtualJoystick moveJoystick = null;

    void MoveJoystick()
    {
        Vector3 dir = Vector3.zero;

        dir.x = Input.GetAxis("Horizontal");
        dir.y = Input.GetAxis("Vertical");

        Rigidbody2D rigi2d = GetComponent <Rigidbody2D>();

        Transform camTransform;

        //float drag = 5f;

        //rigi2d.drag = drag;


        camTransform = Camera.main.transform;


        if (dir.magnitude > 1)
            dir.Normalize();

        if (moveJoystick.InputDirection != Vector3.zero)
        {

            dir = moveJoystick.InputDirection;
        }

        //Rotate our direction vector with camera
        Vector3 rotateDir = camTransform.TransformDirection(dir);
        rotateDir = new Vector3(rotateDir.x, rotateDir.z, 0);
        rotateDir = rotateDir.normalized * dir.magnitude;

        rigi2d.AddForce(rotateDir * speed * 8);

    }

    /// <summary>
    /// Movimenta o Jogador pelo teclado.
    /// </summary>
    void MovePlayerTec()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(horizontal, vertical);

        Rigidbody2D rigi2d = GetComponent <Rigidbody2D>();

        if (vertical != 0)
        {

			
            rigi2d.MovePosition(rigi2d.position + movement * speed * Time.deltaTime);

        }

        if (horizontal != 0)
        {

            rigi2d.MovePosition(rigi2d.position + movement * speed * Time.deltaTime);

        }

    }

    //Muda Animação pelo celular
    //
    public void MudarAnimacaoCel(int i)
    {


        //Vidro
        if (i == 1)
        {

            mudarAnimation = 1;
            animatorPlayer.SetInteger("Controle", 1);
        }

        //Plastico
        if (i == 2)
        {
            mudarAnimation = 2;
            animatorPlayer.SetInteger("Controle", 2);

        }

        //Organico
        if (i == 3)
        {
            mudarAnimation = 3;
            animatorPlayer.SetInteger("Controle", 3);

        }

        //Metal
        if (i == 4)
        {
            mudarAnimation = 4;
            animatorPlayer.SetInteger("Controle", 4);

        }


        //Papel
        if (i == 5)
        {
            mudarAnimation = 5;
            animatorPlayer.SetInteger("Controle", 5);

        }


    }

    // Muda animacão
    // 1 = organico
    // 2 = metal
    // 3 = papel
    // 4 = vidro
    // 5 = plastico.
    public void MudarAnimacao()
    {       

		
        if (Input.GetKey(KeyCode.Alpha1))
        {        
            mudarAnimation = 1; 
            animatorPlayer.SetInteger("Controle", 1);

        }       


        if (Input.GetKey(KeyCode.Alpha2))
        {
            mudarAnimation = 2;
            animatorPlayer.SetInteger("Controle", 2);

        }

        if (Input.GetKey(KeyCode.Alpha3))
        {
            mudarAnimation = 3; 
            animatorPlayer.SetInteger("Controle", 3);

        }

        if (Input.GetKey(KeyCode.Alpha4))
        {
            mudarAnimation = 4; 			      
            animatorPlayer.SetInteger("Controle", 4);

        }

        if (Input.GetKey(KeyCode.Alpha5))
        {
            mudarAnimation = 5;
            animatorPlayer.SetInteger("Controle", 5);

        }

    }


    /// <summary>
    /// O jogador pode atirar se ele tiver coletado "atirarMetal" metais.
    /// </summary>
    public void Atirar(bool clicked)
    {
      
        Text tiros = GameObject.Find("TirosText").GetComponent<Text>();

        tiros.text = atirarMetal.ToString();

        if (Input.GetKeyDown(KeyCode.K) && atirarMetal >= 1 || clicked == true && atirarMetal >= 1)
        {

            atirarMetal -= 1;    

            // Create the Bullet from the Bullet Prefab
            var bullet = (GameObject)Instantiate(prefabTiro, tiroSpawn.position, tiroSpawn.rotation);

            // Add velocity to the bullet
            bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.up * 10;

            // Destroy the bullet after 2 seconds
            Destroy(bullet, 1.0f);

        }

    }


    private Collider2D coll2 = null;

    /// <summary>
    /// Colisão entre o jogador e os objetos: organico, metal, papel...
    /// Raises the collision enter2 d event.
    /// </summary>
    /// <param name="coll">Coll.</param>
    void OnTriggerEnter2D(Collider2D coll)
    {


        this.coll2 = coll;

        // ORGANICO.
        if (mudarAnimation == 3 && coll2.gameObject.tag == "organico")
        {

            organico += 1;

            Destroy(coll.gameObject);

            Text txtOrganico = GameObject.Find("OrganicoText").GetComponent <Text>();

            txtOrganico.text = organico.ToString();
		
            print("Coletou");


        }

        if (mudarAnimation != 3 && coll.gameObject.tag == "organico")
        {

            Destroy(coll.gameObject);

            PerdeVida();

        }

        // METAL.
        if (mudarAnimation == 4 && coll.gameObject.tag == "metal")
        {

            metal += 1;
            atirarMetal += 1;

            Destroy(coll.gameObject);

            Text txtMetal = GameObject.Find("MetalText").GetComponent <Text>();

            txtMetal.text = metal.ToString();

            print("Coletou");

        } 

        if (mudarAnimation != 4 && coll.gameObject.tag == "metal")
        {

            Destroy(coll.gameObject);

            PerdeVida();
        }


        // PAPEL.
        if (mudarAnimation == 5 && coll.gameObject.tag == "papel")
        {

            papel += 1;

            Destroy(coll.gameObject);

            Text txtPapel = GameObject.Find("PapelText").GetComponent <Text>();

            txtPapel.text = papel.ToString();

            print("Coletou");

        } 

        if (mudarAnimation != 5 && coll.gameObject.tag == "papel")
        {

            Destroy(coll.gameObject);

            PerdeVida();
        }

        // VIDRO.
        if (mudarAnimation == 1 && coll.gameObject.tag == "vidro")
        {

            vidro += 1;

            Text txtVidro = GameObject.Find("VidroText").GetComponent <Text>();

            txtVidro.text = vidro.ToString();

            Destroy(coll.gameObject);
            print("Coletou");

        } 

        if (mudarAnimation != 1 && coll.gameObject.tag == "vidro")
        {

            Destroy(coll.gameObject);


            PerdeVida();
        }

        // PLASTICO.
        if (mudarAnimation == 2 && coll.gameObject.tag == "plastico")
        {

            plastico += 1;

            Text txtPlastico = GameObject.Find("PlasticoText").GetComponent <Text>();

            txtPlastico.text = plastico.ToString();

            Destroy(coll.gameObject);

            print("Coletou");

        }

        if (mudarAnimation != 2 && coll.gameObject.tag == "plastico")
        {

            Destroy(coll.gameObject);

            PerdeVida();
        }     

    }

}