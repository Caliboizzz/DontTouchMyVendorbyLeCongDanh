using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyRouteAgent : MonoBehaviour
{
    public float moveSpeed;
    public Route route;
    public float delay;
    public void Start()
    {
        Invoke(nameof(StartMoving), delay);
    }


    private void StartMoving()
    {
        int n = route.waypoints.Length;
        Sequence seq = DOTween.Sequence();
        for (int i=1; i < n; i++)
        {
            float distance = Vector2.Distance(route[i], route[i - 1]);
            seq.Append(transform
            .DOMove(route[i], distance / moveSpeed)
            .SetEase(Ease.Linear)
            .From(route[i-1]));
        }
        // seq.Append(transform
        //     .DOMove(route[0], 2)
        //     .From(route[n- 1]));
        // seq.SetLoops(-1);
        
    }


}
