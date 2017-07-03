using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maincamera : MonoBehaviour
{
    public Transform sunpos;
    public GameObject target;
    public Vector3 targetoffset;
    public Vector3 currentcamerapos;
    public float turnSpeed = 4.0f;
    public Transform player;
    public Vector3 testoffset;
    private Vector3 offset;
    // Use this for initialization
    void Start()
    {
        offset = new Vector3(player.position.x, player.position.y );
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(player.transform.position, Vector3.up, 45f);
        transform.position = target.transform.position + targetoffset ;

        //if (Input.GetMouseButton(2)) { 
        //offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
        //transform.position = player.position + offset;
        //transform.LookAt(player.position + testoffset);
        //}
    }

}