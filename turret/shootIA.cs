using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootIA : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float timeBetweenShoots, timer;
    [SerializeField] AudioSource audio;

    [SerializeField] followIA Turret;
    
    void Start()
    {
        //StartCoroutine(Shoot());
    }

    /*IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenShoots);
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        }
        
    }*/
    void Update()
    {
            switch(Turret.turretState){
                case TurretState.Idle:
                break;

                case TurretState.Shoot:
                    timer+=Time.deltaTime;
                    if(timer>=timeBetweenShoots){
                        timer=0;
                        Instantiate(projectilePrefab, transform.position, Quaternion.identity,transform.parent);
                        audio.Play();
                    }
                break;
            }
    }
}
