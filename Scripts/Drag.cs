using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider2D))]

public class Drag : MonoBehaviour {

	Vector3 screenPoint;
	Vector3 offset;

    bool kill;

    Animator anim;

    public GameObject blood;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        anim.SetFloat("speed", Random.Range(0.1f, 2f));
    }

    void Update()
    {

        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);

        if(Input.GetKey("e")){
            kill = true;
        }else{
            kill = false;
        }
    }

    void OnMouseDown() {

		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        if(kill == true){
            Instantiate(blood, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
	}

	void OnMouseDrag()
	{
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
		transform.position = curPosition;
	}
}
