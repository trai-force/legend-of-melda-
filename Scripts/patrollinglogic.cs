using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrollinglogic : MonoBehaviour {

    public Vector3[] directions;
    private int directionpointer;

    public float timetochange = 1f;
    private float directiontimer;

    public float movingspeed;
	// Use this for initialization
	void Start () {
        directionpointer = 0;
        directiontimer = timetochange;
	}
	
	// Update is called once per frame
	void Update () {
        directiontimer -= Time.deltaTime;
        if (directiontimer <= 0f)
        {
            directiontimer = timetochange;
            directionpointer++;
            if (directionpointer >= directions.Length)
            {

                directionpointer = 0;

            }

            GetComponent<Rigidbody>().velocity = new Vector3(directions[directionpointer].x, directions[directionpointer].y, directions[directionpointer].z);

        }
	}
}
