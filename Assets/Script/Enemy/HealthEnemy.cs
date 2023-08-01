using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class HealthEnemy : MonoBehaviour
{
    public float StartHealth;
    private float Healt;
    public GameObject diePEffect;
    private GameObject CloneDiePEffect;
    public Animator anim;
    private bool takeDamageAnim;
    private bool Attack;
    public int Score;
    public UnityEvent onDie;



    // Start is called before the first frame update
    void Start()
    {
        Healt = StartHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(float damage)
    {
        Healt -= damage;
        anim.SetTrigger("TakeDamage");
        if (Healt <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (diePEffect != null)
        {
            CloneDiePEffect = Instantiate(diePEffect, transform.position, Quaternion.identity);
            Destroy(CloneDiePEffect, 1f);
        }

        onDie.Invoke();

        Scoring.AddScore(Score);
        // CheckWin.AddCountEnemy();
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        if (collisionGameObject.tag == "Player")
        {
            anim.SetTrigger("Attack");

        }
    }

}
