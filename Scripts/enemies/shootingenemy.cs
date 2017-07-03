using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingenemy : enemy {
    public GameObject model;
    public GameObject bulletprefab;
    public GameObject player;
    public Vector3 playerposition;
   
    public Quaternion playerrotation;
    private int TargetAngle;
    public float timetoshoot = 1f;
    private float shootingtimer;
    
    
    public float timetorotate = 2f;
    public float rotatingspeed = 5f;
    
   
    private float Rotationtimer;

    public bool followingplayer;
	// Use this for initialization
	void Start () {
        Rotationtimer = timetorotate;
        shootingtimer = timetoshoot;
       player = GameObject.Find("Player");
      
    }
	
	// Update is called once per frame
	void Update () {
         playerposition = player.transform.position ;
       
         playerrotation = player.transform.localRotation;
        


        raycastforplayer();

        Rotationtimer -= Time.deltaTime;
        if ( Rotationtimer <= 0f)
        {
            Rotationtimer = timetorotate;
            TargetAngle += 90;
            
        }
       if (followingplayer == false) {
             transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0, TargetAngle, 0), Time.deltaTime * rotatingspeed);
        }
        else
        {
            transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.LookRotation(playerposition), Time.deltaTime * rotatingspeed);
        }


        //shoot buller 
        shootingtimer -= Time.deltaTime;

        if (shootingtimer <= 0f)
        {
            shootingtimer = timetoshoot;
            GameObject bulletobject = Instantiate(bulletprefab);
            bulletobject.transform.position = transform.position + model.transform.forward;
            bulletobject.transform.forward = model.transform.forward;

        }
	}

    public void raycastforplayer()
    {
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward) * raydistance;
        Debug.DrawRay(raycaststart.transform.position, forward, Color.green);

        if (Physics.Raycast(raycaststart.transform.position, forward, out hit))
        {
            if (hit.collider.gameObject.tag == ("Player"))
            {
                print("HIT player");
            }
        }
    }

}
