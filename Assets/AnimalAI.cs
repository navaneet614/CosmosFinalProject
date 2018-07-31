using UnityEngine;
using System.Collections;


public class AnimalAI : MonoBehaviour
{
    public float speedMin = 0.02f;
    public float speedMax = 0.2f;
    public float speedIncrease = 0.003f;
    public float minDistance = 2f;
    public float maxDistance = 10f;
    public float minAngle = -90f;
    public float maxAngle = 90f;
    public float minWaitTime = 1f;
    public float maxWaitTime = 5f;
    Animator animator;
    private float distance, angle;
    private bool running;


    void Start()
    {
        animator = GetComponent<Animator>();
        PickPosition();
    }

    void PickPosition()
    {
        if (running)
        {
            StopCoroutine("MoveToRandomPos");
        }
        distance = Random.Range(minDistance, maxDistance);
        angle = Random.Range(minAngle, maxAngle);
        StartCoroutine("MoveToRandomPos");

    }

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.name == "Terrain_2" || col.gameObject.name == "Uneven_Ground_Dirt_01 1")
        {

        } else
        {
            distance = 0;
            angle = 0;
            animator.SetBool("walk", false);
            animator.SetBool("run", false);
            PickPosition();
        }
    }

    IEnumerator MoveToRandomPos()
    {

        running = true;
        float speed = Random.Range(speedMin, speedMax);
        if (speed > speedMax/2)
        {
            animator.SetBool("run", true);
        } else
        {
            animator.SetBool("walk", true);
        }

        float currentSpeed = 0;
        while (distance>0)
        {
            transform.Rotate(0, angle == 0 ? 0 : (angle<0?-1:1), 0);
            if (Mathf.Abs(angle) < 1)
            {
                angle = 0;
            } else
            {
                angle += (angle < 0 ? 1 : -1);
            }

            transform.Translate(0, 0, (distance>0)?currentSpeed:0);
            distance -= currentSpeed;
            currentSpeed += (currentSpeed >= speed ? 0 : speedIncrease);
            yield return null;
        }

        distance = 0;
        angle = 0;
        animator.SetBool("walk", false);
        animator.SetBool("run", false);

        float randomFloat = Random.Range(0.0f, 1.0f); // Create %50 chance to wait
        running = false;
        if (randomFloat < 0.5f)
            StartCoroutine(WaitForSomeTime());
        else
            PickPosition();
    }

    IEnumerator WaitForSomeTime()
    {
        yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
        PickPosition();
    }
}