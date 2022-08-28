using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CrowdAI : MonoBehaviour
{
    
    public Transform[] waypoints;
    private int waypointIndex;
    
    public float travelDelay;
    private bool isWaiting;
    public float speed;

    void Awake()
    {
        StartCoroutine(MoveTo());
    }

    private IEnumerator MoveTo()
    {
        while (true)
        {
            if (!isWaiting)
            {
                float step = Time.deltaTime * speed;
                transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].position, step);
                ReachedWaypoint();
            }
            else
            {
                yield return new WaitForSeconds(travelDelay);
                isWaiting = false;
            }
            yield return null;
        }
    }

    private void ReachedWaypoint()
    {
        if (transform.position == waypoints[waypointIndex].position)
        {
            isWaiting = true;
            waypointIndex++;
            waypointIndex %= waypoints.Length;
        }
    }
}
