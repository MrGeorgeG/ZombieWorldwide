using System.Collections;
using System.Collections.Generic;
using Systems.Health_System;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public bool activated;

    public float rotationSpeed;

    void Update()
    {

        if (activated)
        {
            transform.localEulerAngles += Vector3.forward * rotationSpeed * Time.deltaTime;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        
        activated = false;
        print(collision.gameObject.name);
        GetComponent<Rigidbody>().Sleep();
        GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
        GetComponent<Rigidbody>().isKinematic = true;

    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.CompareTag("Breakable"))
        //{
        //    if (other.GetComponent<BreakBoxScript>() != null)
        //    {
        //        other.GetComponent<BreakBoxScript>().Break();
        //    }
        //}

        if(other.CompareTag("Zombie"))
        {
            IDamagable damagable = other.GetComponent<IDamagable>();
            damagable?.TakeDamage(50);
        }
    }
}
