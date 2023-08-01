using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketControl : MonoBehaviour
{
    
    

    public Transform shootPos;
    public Transform sensorPos;
    public GameObject bullet;
    public GameObject Sensor;
    public Animator anim;
    private GameObject CloneSensor;
    private bool IsAnimShoot;
    // Start is called before the first frame update
    void Start()
    {
        SpawnSensor();
    }

    // Update is called once per frame
    void Update()
    {
        if(IsAnimShoot){
            anim.SetTrigger("IsAttack");
            IsAnimShoot=false;
        }
        
        
    }

    public void Shoot()
    {
        
        GameObject newBullet = Instantiate(bullet, shootPos.position, Quaternion.identity);
        IsAnimShoot=true;
    }

    void SpawnSensor(){
        
        CloneSensor = Instantiate(Sensor, sensorPos.position, Quaternion.identity);   
    }

    void OnDestroy()
    {
        Destroy(CloneSensor);
    }
}
