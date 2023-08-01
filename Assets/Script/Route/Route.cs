using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route : MonoBehaviour
{
    public Transform[] waypoints;
    public Vector3 this[int index] => waypoints[index].position;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        for(int i =0; i< waypoints.Length; i++)
        {
            Gizmos.DrawSphere(waypoints[i].position, 0.2f);
            if (i > 0)
            {
                //Gizmos.DrawLine(waypoints[i-1].position, waypoints[i].position);
                Gizmos.DrawLine(this[i - 1], this[i]);
            }
        }
    }
}
