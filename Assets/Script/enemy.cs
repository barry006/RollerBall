using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float speed = 0;
    public List<Transform> waypoints;

    int waypointsIndex;
    float range;

  
    void Start()
    {
        waypointsIndex = 0;
        range = 1.0f;

    }

   
    void Update()
    {
        OnAnimatorMove();
    }


    private void OnAnimatorMove()
    {
        transform.LookAt(waypoints[waypointsIndex]);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, waypoints[waypointsIndex].position) < range)
        {
            waypointsIndex++;
            if (waypointsIndex >= waypoints.Count)
            {
                waypointsIndex = 0;
            }
        }
    }

}
    




