using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {
    public float swingspeed = 2f;
    public float cooldownspeed = 2f;
    public float cooldownduration = 0.5f;
    public float attackduration = 0.5f;
    public float damage;
    private float cooldownTimer;
    private Quaternion targetrotation;
    public bool isattacking;

    public bool Isattacking { get { return isattacking; } }
    // Use this for initialization
    void Start() {
        targetrotation = Quaternion.Euler(0, 0, 0);
    }

    // Update is called once per frame
    void Update() {
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetrotation, Time.deltaTime *(isattacking ? swingspeed : cooldownspeed));
        cooldownTimer -= Time.deltaTime;
    }

    public void Attack() {
        if (cooldownTimer > 0f)
        {

            return;
        }
        targetrotation = Quaternion.Euler(90, 0, 0);

        cooldownTimer = cooldownduration;
        StartCoroutine(cooldownwait());

    }

    private IEnumerator cooldownwait(){
        isattacking = true;
        yield return new WaitForSeconds(attackduration);
        isattacking = false;
        targetrotation = Quaternion.Euler(0, 0, 0);

}
}
