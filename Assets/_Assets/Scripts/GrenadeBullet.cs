using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeBullet : MonoBehaviour
{
    public GameObject explositionPrefab;
    public float explosionRadius;
    public float explosionForce;

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.LogError($"explosion: {collision.gameObject.name}");
        //Instantiate(explositionPrefab, transform.position, transform.rotation);

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
                rigidbody.AddExplosionForce(explosionForce, transform.position ,explosionRadius,1, ForceMode.Impulse);
            }
        }
    }
}
