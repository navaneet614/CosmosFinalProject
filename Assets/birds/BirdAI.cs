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
    private bool running;


    void Start()
    {
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

        }
        else
        {
            distance = 0;
            angle = 0;

            PickPosition();
        }
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
        PickPosition();
    }
}