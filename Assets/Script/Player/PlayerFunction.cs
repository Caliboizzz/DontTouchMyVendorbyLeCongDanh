using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFunction : MonoBehaviour
{
    public float shootSpeed;
    public float shootTimer;
    private bool isShooting;
    private float spawnDelay = 1;

    public Transform shootPos;
    public GameObject bullet;
    public GameObject diePEffect;
    private GameObject CloneDiePEffect;
    public Animator anim;
    private bool Attack;
    private bool Death;
    public GameObject gameLosePanel;
    public bool IsLeftShoot;


    // Start is called before the first frame update
    void Start()
    {
        isShooting = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isShooting)
        {
            StartCoroutine(Shoot());

        }
    }

    public void OnClickShoot()
    {
        if (!isShooting)
        {
            StartCoroutine(Shoot());

        }
    }

    IEnumerator Shoot()
    {
        
        isShooting = true;
        GameObject newBullet = Instantiate(bullet, shootPos.position, Quaternion.identity);
        if (IsLeftShoot)
        {
            anim.SetTrigger("IsAttack");
            newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-(shootSpeed * Time.fixedDeltaTime), 0f);
        }
        else
        {
            anim.SetTrigger("Attack");
            newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed * Time.fixedDeltaTime, 0f);
        }

        yield return new WaitForSeconds(shootTimer);
        isShooting = false;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        if (collisionGameObject.tag == "Enemy")
        {
            isShooting = true;
            if (IsLeftShoot)
            {
                Die();
            }
            else
            {
                
                anim.SetTrigger("Death");
                StartCoroutine(ShowLosePanel());
            }

        }
    }

    IEnumerator ShowLosePanel()
    {
        yield return new WaitForSeconds(spawnDelay);
        Time.timeScale = 0;
        gameLosePanel.SetActive(true);
    }

    void Die()
    {
        if (diePEffect != null)
        {
            CloneDiePEffect = Instantiate(diePEffect, transform.position, Quaternion.identity);
            Destroy(CloneDiePEffect, 2f);
        }
        Destroy(gameObject);
    }
}
