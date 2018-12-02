using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour {

    public GameObject fade;
    SpriteRenderer sprite;


    public float fading = 1;

    // Use this for initialization
    void Start () {
        sprite = fade.GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        fading -= Time.deltaTime;
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, fading);
    }
}
