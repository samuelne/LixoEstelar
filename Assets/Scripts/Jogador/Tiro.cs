using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Developed by Samuel.

public class Tiro : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void Update () {
		
	}


	void OnTriggerEnter2D (Collider2D coll) {


        if (coll.gameObject.tag == "organico" || coll.gameObject.tag == "vidro"|| coll.gameObject.tag == "papel" 
            || coll.gameObject.tag == "metal" || coll.gameObject.tag == "plastico") {


			Destroy (coll.gameObject);
			Destroy (this.gameObject);
		} 

	}
		
}
