using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour {

    float timing;
    public float setTime;

    private void Update()
    {
        timing += Time.deltaTime;
        if(timing >= setTime){
            SceneManager.LoadScene(1);
        }
    }
}
