using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {
    public int health = 1;
    public GameObject raycaststart;
   
    public GameObject raycastend;
    public float raydistance = 5f;

    // Use this for initialization
    void Start () {
      
    }
	
	// Update is called once per frame
	void Update () {
       
	}

    public virtual void Hit()
    {

        health--;
        if (health <= 0)
        {

            Destroy(gameObject);
        }

    }

    public void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.GetComponent<Sword>() != null ) {
            if (otherCollider.GetComponent<Sword>().isattacking) { 
            Hit();
            }
        }
        else if (otherCollider.GetComponent<Arrow>() != null) {
            Hit();
            Destroy(otherCollider.gameObject);
        }
    }
}
