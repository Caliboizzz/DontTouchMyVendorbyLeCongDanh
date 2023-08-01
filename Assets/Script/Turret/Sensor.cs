using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Sensor : MonoBehaviour
{

    public float ActionTimer;
    public bool IsPlane;
    private bool isAction;
    public UnityEvent SensorAction;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        if (IsPlane)
        {
            if (collisionGameObject.tag == "Plane")
            {
                SensorAction.Invoke();
                
            }
        }
        else
        {
            if (collisionGameObject.tag == "Enemy" && !isAction)
            {
                StartCoroutine(Action());
            }
        }

    }

    IEnumerator Action()
    {
        isAction = true;
        SensorAction.Invoke();
        yield return new WaitForSeconds(ActionTimer);
        isAction = false;
    }
}
