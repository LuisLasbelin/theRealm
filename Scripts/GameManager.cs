using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public Text events_s, food_s, totalFarmers_s;

    //guadaña
    public GameObject scyte;
    private Vector3 mousePosition;

    GameObject[] totalFarmers_g;
    public Farms[] farms;
    public int totalFarmers;
    public int food;

    public float timeCycle_set;
    float timeCycle;
    public int cycles_set;
    int cycles;

    public static int cyclesCompleted;

    public string[] events;

	// Use this for initialization
	void Start () {
        timeCycle = timeCycle_set;
    }
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKey("e")){
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            scyte.SetActive(true);
            scyte.transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);
        } else{
            scyte.SetActive(false);
        }

        food_s.text = food.ToString();
        totalFarmers_s.text = totalFarmers.ToString();

        timeCycle -= Time.deltaTime;

        //cycles or days
        if(timeCycle <= 0){
            for (int i = 0; i < farms.Length; i++){
                food += farms[i].produced;
            }
            food -= totalFarmers;

            if(food <= 0){
                Loose();
            }

            timeCycle = timeCycle_set;
            cycles++;
            cyclesCompleted++;
        }

        //events
        if(cycles == cycles_set){
            for (int i = 0; i < farms.Length; i++)
            {
                farms[i].handicap_food = Mathf.RoundToInt(Random.Range(0f, 4f));
            }

            int eve = Mathf.RoundToInt(Random.Range(0f, 9f));
            if(eve < 4){
                events_s.text = events[0];
                farms[eve].handicap_food = 3;
                farms[eve + 2].handicap_food = 3;
            }
            if(eve > 6){
                events_s.text = events[1];
                farms[eve].handicap_food = 20;
                farms[eve - 1].handicap_food = 20;
                farms[eve - 2].handicap_food = 20;
                farms[eve - 3].handicap_food = 20;
            }
            if(eve == 5){
                events_s.text = events[2];
                farms[eve].handicap_food = 200;
                farms[eve + 1].handicap_food = 200;
                farms[eve + 2].handicap_food = 200;
                farms[eve + 3].handicap_food = 200;
            }

            cycles = 0;
        }

        //calculate famers
        totalFarmers_g = GameObject.FindGameObjectsWithTag("farmer");
        totalFarmers = totalFarmers_g.Length;
	}

    private void OnMouseDown()
    {
        if (Input.GetKey("e")){
            //scyte.GetComponent<Kill>().Execute();
        }
    }

    void Loose(){
        SceneManager.LoadScene(2);
    }
}
