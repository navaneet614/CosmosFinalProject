using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HareScript : MonoBehaviour {

    public float speedMin = 0.02f;
    public float speedMax = 0.2f;
    public float speedIncrease = 0.003f;
    public float minDistance = 2f;
    public float maxDistance = 10f;
    public float minAngle = -90f;
    public float maxAngle = 90f;
    public float minWaitTime = 1f;
    public float maxWaitTime = 5f;
    public float jumpHeight = 1f;
    private float distance, angle;
    private bool moving = true, onGround = true;

    // Use this for initialization
    void Start () {
        PickPosition();
    }

    void Update()
    {
        //CapsuleCollider collider = GetComponent<CapsuleCollider>();
        //onGround = Physics.CheckCapsule(collider.bounds.center, new Vector3(collider.bounds.center.x, collider.bounds.min.y - 0.1f, collider.bounds.center.z), 0.18f);

        if (moving && onGround)
        {
            GetComponent<Rigidbody>().AddForce(0, jumpHeight, 0, ForceMode.Impulse);
            onGround = false;
        }
    }

    void PickPosition()
    {
        StopCoroutine("MoveToRandomPos");
        distance = Random.Range(minDistance, maxDistance);
        angle = Random.Range(minAngle, maxAngle);
        StartCoroutine("MoveToRandomPos");

    }

    void OnCollisionEnter(Collision col)
    {

        if(col.gameObject.name == "Terrain_2" || col.gameObject.name == "Uneven_Ground_Dirt_01 1")
        {
            onGround = true;
        }else
        {
            distance = 0;
            angle = 0;
            PickPosition();
        }
    }

    IEnumerator MoveToRandomPos()
    {
        float speed = Random.Range(speedMin, speedMax);

    

        float currentSpeed = 0;
        while (distance > 0)
        {
            transform.Rotate(0, angle == 0 ? 0 : (angle < 0 ? -1 : 1), 0);
            if (Mathf.Abs(angle) < 1)
            {
                angle = 0;
            }
            else
            {
                angle += (angle < 0 ? 1 : -1);
            }

            transform.Translate(0, 0, (distance > 0) ? currentSpeed : 0);
            distance -= currentSpeed;
            currentSpeed += (currentSpeed >= speed ? 0 : speedIncrease);
            yield return null;
        }

        distance = 0;
        angle = 0;


        float randomFloat = Random.Range(0.0f, 1.0f); // Create %50 chance to wait
        if (randomFloat < 0.5f)
            StartCoroutine(WaitForSomeTime());
        else
            PickPosition();
    }

    IEnumerator WaitForSomeTime()
    {
        moving = false;
        yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
        moving = true;
        PickPosition();
    }
}
