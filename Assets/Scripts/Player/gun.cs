using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
          {
               shoot();
          }
    }
    void shoot()
    {
        muzzleFlash.Play();
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
               Debug.Log(hit.transform.name);

               Target target = hit.transform.GetComponent<Target>();
                
                if (target != null)
               {
                    target.TakeDamage(damage);
               }
            //Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        }

    }
}
