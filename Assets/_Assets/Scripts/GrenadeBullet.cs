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
    private List<Health> oldVictims;

    private void Start()
    {
        oldVictims = new List<Health>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        var explosion =  Instantiate(explositionPrefab, transform);
        explosion.transform.parent = null;
        BlowObjects();
        Destroy(gameObject);
    }

    private void BlowObjects()
    {
        oldVictims.Clear();
        var affectedObjects = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach(var affectedObject in affectedObjects)
        {
            var rigidbody = affectedObject.GetComponent<Rigidbody>();
            if(rigidbody)
            {
                DealDamage(affectedObject);
                AddForceToObject(rigidbody);
            }
        }
    }

    private void AddForceToObject(Rigidbody rigidbody)
    {
        rigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius, 1, ForceMode.Impulse);
    }

    private void DealDamage(Collider victim)
    {
        var health = victim.GetComponentInParent<Health>();
        if (health && !oldVictims.Contains(health))
        {
            health.TakeDamage(damage);
            oldVictims.Add(health);
        }
    }
}
