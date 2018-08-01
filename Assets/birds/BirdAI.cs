using UnityEngine;
using System.Collections;


public class BirdAI : MonoBehaviour
{
    public float speed = .3f;
    public float speedIncrease = 0.003f;
    public float minDistance = 2f;
    public float maxDistance = 10f;
    public float minAngle = -90f;
    public float maxAngle = 90f;
    public float minWaitTime = 1f;
    public float maxWaitTime = 5f;
    private float distance, angle;
    private bool running, paused;


    void Start()
    {
        PickPosition(false);
    }

    void Update()
    {
        if (Time.timeScale == 0f)
        {
            paused = true;
            StopAllCoroutines();
        }
        else if (paused)
        {
            PickPosition(false);
            paused = false;
        }
    }



    void PickPosition(bool b)
    {
        if (running)
        {
            StopCoroutine("MoveToRandomPos");
        }
        distance = Random.Range(minDistance, maxDistance);
        angle = Random.Range(minAngle, maxAngle);
        if (b)
        {
            angle = 180;
        }
        StartCoroutine("MoveToRandomPos");

    }

    void OnCollisionEnter(Collision col)
    {
            distance = 0;
            angle = 0;

            PickPosition(true);
        
    }

    IEnumerator MoveToRandomPos()
    {

        running = true;


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

            transform.Translate(0, 0, (distance > 0) ? speed : 0);
            distance -= speed;
            yield return null;
        }

        distance = 0;
        angle = 0;
        PickPosition(false);
    }
}