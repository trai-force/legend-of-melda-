using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {
    public float duration = 5f;
    public float explotionradius = 3f;
    public float explotiontimer = 3f;
    private float explotionduration = 0.25f;

    private bool exploded;
    public GameObject explotionmodel;
	// Use this for initialization
	void Start () {
        explotiontimer = duration;
        explotionmodel.SetActive  (false);
        explotionmodel.transform.localScale = Vector3.one * explotionradius;
	}
	
	// Update is called once per frame
	void Update () {
        explotiontimer -= Time.deltaTime;
        if (explotiontimer <= 0 && exploded ==false)
        {
            exploded = true;
       
           Collider[] hitObjects  = Physics.OverlapSphere(transform.position, explotionradius);
            foreach(Collider collider in hitObjects)
            {
                Debug.Log(collider.name + "was hit");
                if (collider.GetComponent<enemy>() != null)
                {

                    collider.GetComponent<enemy>().Hit();
                }

            }
            StartCoroutine(Explode());


        }
    }
    private IEnumerator Explode()
    {
        explotionmodel.SetActive(true);
        yield return new  WaitForSeconds(explotionduration);
        Destroy(gameObject);


    }
}
