using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProximaCena : MonoBehaviour {

    public void cena(string ceena){
        SceneManager.LoadScene(ceena); 
    }
    public void sairdojogo(){

        Application.Quit();
    }
}
