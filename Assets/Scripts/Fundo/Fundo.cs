using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fundo : MonoBehaviour
{


    private Material currentMaterial;
    public float speed;
    private float offset;


    // Use this for initialization
    void Start()
    {

        currentMaterial = GetComponent <Renderer>().material;


    }
	
    // Update is called once per frame
    void Update()
    {

        if (ControleCena.controlePAUSE == 0)
        {


            Parallax();

        }
        else
        {

            return;

        }

		
    }

    public void Parallax()
    {
        
            offset += 0.001f;

            currentMaterial.SetTextureOffset("_MainTex", new Vector2(0 * speed, offset));


        if (Time.time >= 2)
        {


            //currentMaterial.color = Color.blue;
            //transform.Translate(Vector3.down * 0.01f, Space.World);

            //currentMaterial.color = Color.LerpUnclamped (Color.red, Color.white, Mathf.PingPong(Time.time, 2f));


        }


        if (Time.time >= 5)
        {


            //currentMaterial.color = Color.white;
            //transform.Translate(Vector3.down * 0.01f, Space.World); 

            //currentMaterial.color = Color.LerpUnclamped (Color.red, Color.gray, Mathf.PingPong(Time.time, 2f));

        }


    }


    IEnumerator Muda(float waitTime)
    {


        yield return new WaitForSeconds(waitTime);


    }
}
