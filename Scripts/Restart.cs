using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : MonoBehaviour {

    static int cyclesCompleted;
    public Text record;

    private void Start()
    {
        cyclesCompleted = GameManager.cyclesCompleted;

        record.text = "You survived " + cyclesCompleted + " days.";
    }

    public void NewGame(){

        SceneManager.LoadScene(1);
    }
}
