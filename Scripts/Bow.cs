using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour {
    public GameObject arrowprefab;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        arrowprefab.transform.forward = transform.forward;
    }

    public void Attack()
    {

          GameObject arrowobject = Instantiate (arrowprefab);
          arrowobject.transform.position = transform.position + transform.forward;
         

    }
}
