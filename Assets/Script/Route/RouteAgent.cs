using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class RouteAgent : MonoBehaviour
{
    public Route routePrefab;
    public float flySpeed;
    public bool IsLoop;
    private Route route;
    public void Start()
    {
        route = Instantiate(routePrefab);
        int n = route.waypoints.Length;
        Sequence seq = DOTween.Sequence();
        for (int i = 1; i < n; i++)
        {
            float distance = Vector2.Distance(route[i], route[i - 1]);
            seq.Append(transform
            .DOMove(route[i], distance / flySpeed)
            .SetEase(Ease.Linear)
            .From(route[i - 1]));
        }
        if (IsLoop)
        {
            //loop nhung chay nguoc ve
            // seq.Append(transform
            // .DOMove(route[0], 2)
            // .From(route[n - 1]));
            
            seq.SetLoops(-1);
        }

        //Destroy(route.gameObject);
    }
}
