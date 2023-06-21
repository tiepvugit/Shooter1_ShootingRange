using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeBullet : MonoBehaviour
{
    [SerializeField]
    private GameObject explositionPrefab;
    [SerializeField]
    private float explosionRadius;
    [SerializeField]
    private float explosionForce;
    [SerializeField]
    private int damage;


    private void OnCollisionEnter(Collision collision)
    {
        var explosion =  Instantiate(explositionPrefab, transform);
        explosion.transform.parent = null;
        BlowObjects();
        Destroy(gameObject);
    }

    private void BlowObjects()
    {
        var affectedObjects = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach(var affectedObject in affectedObjects)
        {
            var rigidbody = affectedObject.GetComponent<Rigidbody>();
            if(rigidbody)
            {
                DealDamage(affectedObject);
                rigidbody.AddExplosionForce(explosionForce, transform.position ,explosionRadius,1, ForceMode.Impulse);
            }
        }
    }

    private void DealDamage(Collider collider)
    {
        var health = collider.GetComponent<Health>();
        if (health)
        {
            health.TakeDamage(damage);
        }
    }
}
