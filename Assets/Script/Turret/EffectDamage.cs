using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDamage : MonoBehaviour
{
    public float DamageEffect;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }



    private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        

        if (collisionGameObject.tag != "Player")
        {
            if (collisionGameObject.GetComponent<HealthEnemy>() != null)
            {
                collisionGameObject.GetComponent<HealthEnemy>().TakeDamage(DamageEffect);
                
            }
        }
    }
}
