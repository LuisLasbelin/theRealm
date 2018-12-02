using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour {

    Animator anim;

    void Start(){
        anim = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0)){

            anim.SetBool("kill", true);

        } else{
            anim.SetBool("kill", false);
        }
    }

}
