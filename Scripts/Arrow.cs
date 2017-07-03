using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {
    public float speed = 10;
    public float lifetime;
	// Use this for initialization
	void Start () {
      
       
    }
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;

        lifetime -= Time.deltaTime;
        if (lifetime <=0)
        {
            Destroy(gameObject);

        }
    }
}
