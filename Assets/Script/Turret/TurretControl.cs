using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretControl : MonoBehaviour
{
    public float shootSpeed;
    public float shootTimer;
    private bool isShooting;
    public Transform shootPos;
    public GameObject bullet;
    public bool IsDropShoot;
    public bool IsLeftShoot;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Shoot()
    {
        anim.SetTrigger("IsAttack");
        isShooting=true;
        GameObject newBullet = Instantiate(bullet, shootPos.position, Quaternion.identity);
        if (IsLeftShoot)
        {
            newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-(shootSpeed * Time.fixedDeltaTime), 0f);
        }
        else
        {
            newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed * Time.fixedDeltaTime, 0f);
        }
        yield return new WaitForSeconds(shootTimer);
        isShooting=false;


    }

    IEnumerator DropShoot()
    {
        anim.SetTrigger("IsAttack");
        isShooting=true;
        GameObject newBullet = Instantiate(bullet, shootPos.position, Quaternion.identity);
        yield return new WaitForSeconds(shootTimer);
        isShooting=false;


    }

    private void OnCollisionEnter2D(Collision2D collision){
        GameObject collisionGameObject = collision.gameObject;
        if(collisionGameObject.tag == "Enemy" && !isShooting){
            if(IsDropShoot){
                StartCoroutine(DropShoot());
            }else{
                StartCoroutine(Shoot());
            }
            
        }
    }

    private void OnTriggerStay2D(Collider2D collider){
        GameObject colliderGameObject = collider.gameObject;
        if(colliderGameObject.tag == "Enemy" && !isShooting){
                StartCoroutine(DropShoot());
        }
    }

}
