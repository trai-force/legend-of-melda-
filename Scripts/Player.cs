using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    Rigidbody rb;
    [Header("visuals")]
   public GameObject Model;
    [Header("Force")]
    public float speed = 3.5f;
    public float jumpvelocity = 5.0f;
    public float knockbackForce = 20f;
    private float knockbacktimer;
    public float RotatingSpeed = 10f;
    public float RotatingSpeedplayer = 1000f;
    public bool canjump;
    private Quaternion targetModelRotation;
    [Header("stats")]
    public int health = 100;
    [Header("Weapons")]
    public Sword sword;
    public Bow bow;

    public GameObject BombPrefab;
    public int bombamount = 5;
    public float trowspeed = 10f;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        targetModelRotation = Quaternion.Euler(0, 0, 0);
        bow.gameObject.SetActive(false);
    }

    // Update is called once p
  
	void Update () {
        CheckForGround();

        if (knockbacktimer > 0)
        {

            knockbacktimer -= Time.deltaTime;
        }
        else
        {
            PlayerMovement();


        }


       
       // Model.transform.rotation = Quaternion.Lerp(Model.transform.rotation, targetModelRotation, Time.deltaTime* RotatingSpeed);
       


    }

    //  private void OnCollisionEnter(Collision collision)
    // {
    //    if (collision.transform.name == "Floor")
    //  {

    //     canjump = true;
    //   }
    // }

    public void PlayerMovement()
    {
        //rb.velocity = new Vector3(0, 0, 0);
        //if (Input.GetKey("right"))
        //{
        //    //rb.transform.position += Vector3.right * speed * Time.deltaTime;
        //    // transform.RotateAround(transform.position, Vector3.up, RotatingSpeed * Time.deltaTime);

        //    //Model.transform.localEulerAngles = new Vector3(0, 90, 0);
        //    //   Model.transform.rotation = Quaternion.Lerp(Model.transform.rotation, Quaternion.Euler (0, 90, 0), Time.deltaTime* RotatingSpeed);
        //    targetModelRotation = Quaternion.Euler(
        //        0,
        //        Model.transform.localEulerAngles.y + RotatingSpeedplayer *Time.deltaTime,
        //        0
        //        );
        //}

        //if (Input.GetKey("left"))
        //{
        //    //  rb.transform.position += Vector3.left * speed * Time.deltaTime;
        //    //transform.RotateAround(transform.position, Vector3.up, -RotatingSpeed * Time.deltaTime);
           
        //    // Model.transform.localEulerAngles = new Vector3(0, 270, 0);
        //  //  Model.transform.rotation = Quaternion.Lerp(Model.transform.rotation, Quaternion.Euler(0, 270, 0), Time.deltaTime * RotatingSpeed);
        //    targetModelRotation = Quaternion.Euler(
        //        0,
        //        Model.transform.localEulerAngles.y - RotatingSpeedplayer * Time.deltaTime,
        //        0);

        //}
        //if (Input.GetKey("up"))
        //{
        //   // rb.transform.position += transform.forward * speed * Time.deltaTime;
        //    rb.velocity =  new Vector3 (Model.transform.forward.x *speed,rb.velocity.y,Model.transform.forward.z * speed);
        //    //  Model.transform.localEulerAngles = new Vector3(0, 0, 0);
        //   // Model.transform.rotation = Quaternion.Lerp(Model.transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * RotatingSpeed);
        //   // targetModelRotation = Quaternion.Euler(0, 0, 0);


        //}
        //if (Input.GetKey("down"))
        //{
        //    // rb.transform.position -= transform.forward * speed * Time.deltaTime;
        //    rb.velocity = new Vector3(-Model.transform.forward.x * speed, rb.velocity.y, -Model.transform.forward.z * speed);
        //    //Model.transform.localEulerAngles = new Vector3(0,180, 0);
        //  //  Model.transform.rotation = Quaternion.Lerp(Model.transform.rotation, Quaternion.Euler(0, 180, 0), Time.deltaTime * RotatingSpeed);
        //   // targetModelRotation = Quaternion.Euler(0, 180, 0);

        //}



        if (Input.GetKeyDown("space") && canjump == true)
        {

            rb.velocity = new Vector3(0, jumpvelocity, 0);
            canjump = false;
        }

        //check equipement interaction 

        if (Input.GetKeyDown("f")){
            sword.Attack();
            sword.gameObject.SetActive(true);

            bow.gameObject.SetActive(false);
        }

        if (Input.GetKeyDown("x"))
        {
            trowbomb();

        }
        if (Input.GetKeyDown("w"))
        {
            bow.gameObject.SetActive(true);

            sword.gameObject.SetActive(false);
            bow.Attack();

        }

    }

    private void trowbomb()
    {
        if (bombamount <= 0)
        {
            return;
        }
        GameObject Spawndbomb = Instantiate(BombPrefab);
        Spawndbomb.transform.position = transform.position + Model.transform.forward;
        Vector3 trowdirection = (Model.transform.forward + Vector3.up).normalized;
        Spawndbomb.GetComponent<Rigidbody>().AddForce(trowdirection * trowspeed);
        bombamount--;
    }


    public void CheckForGround()
    {

        RaycastHit hit;
       
        if (
        Physics.Raycast(transform.position, Vector3.down, out hit, 1.10f))
        {
            canjump = true;
           
        }



    }

     void OnTriggerEnter(Collider other)
    {
       // Debug.Log(other.GetComponent<Collider>().name);
       if (other.GetComponent<Collider>().GetComponent<enemybullet>() != null)
        {
            Hit((transform.position - other.transform.position).normalized);

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<enemy>())
        {

            Hit((transform.position - collision.transform.position).normalized);
        }
      //  Debug.Log(collision.gameObject.name);

    }
    private void Hit(Vector3 direction)
    {
        knockbacktimer = 1f;
        Vector3 knockbackdirction = (direction + Vector3.up).normalized;
        rb.AddForce(knockbackdirction * knockbackForce);
        health--;
        Debug.Log(health);

    }
}
