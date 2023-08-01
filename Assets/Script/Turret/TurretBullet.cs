using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBullet : MonoBehaviour
{
    public GameObject DiePEffect;
    private GameObject DiePEffectClone;
    public float Damage;
    public float TimeEffect;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if (collisionGameObject.tag != "Player")
        {
            if (collisionGameObject.GetComponent<HealthEnemy>() != null)
            {
                collisionGameObject.GetComponent<HealthEnemy>().TakeDamage(Damage);
            }
            Die();
        }
    }
    void Die()
    {
        if (DiePEffect != null)
        {
            DiePEffectClone=Instantiate(DiePEffect, transform.position, Quaternion.identity);
            Destroy(DiePEffectClone,TimeEffect);
        }
        Destroy(gameObject);
    }
}
