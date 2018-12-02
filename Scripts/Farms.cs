using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farms : MonoBehaviour {

    public int produced;
    public int farmers;
    public int handicap_food;

    public GameObject death;
    GameObject deathtag;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        produced = (farmers * 2) - handicap_food;
        if(produced < 0){
            produced = 0;
        }

        if(handicap_food >= 100 && deathtag == null){
            deathtag = Instantiate(death, transform.position, Quaternion.identity);
        } else{
            if(deathtag != null && handicap_food < 100)
            {
                Destroy(deathtag);
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "farmer"){
            farmers++;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "farmer")
        {
            farmers--;
        }
    }
}
