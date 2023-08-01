using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public GameObject DiePEffect;
    public GameObject RabbitPrefab;
    private GameObject Rabbit;

    public float speed = 1.5f;
    private GameObject DiePEffectClone;
    public float Damage;
    // Start is called before the first frame update
    void Start()
    {

        Rabbit = Instantiate(RabbitPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        //Ky Thuat di theo Rabbit
        transform.position = Vector2.MoveTowards(transform.position, Rabbit.transform.position, speed*Time.deltaTime);
        if (Vector2.Distance(Rabbit.transform.position, transform.position) > 0.1f)
        {
            Vector2 direction = Rabbit.transform.position - transform.position;
            float angle = Vector2.SignedAngle(Vector2.up, direction);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
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
            Destroy(DiePEffectClone,0.5f);
            Destroy(Rabbit);
        }
        Destroy(gameObject);
    }
}
