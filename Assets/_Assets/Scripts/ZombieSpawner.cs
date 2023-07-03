
using System.Collections;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _zombiePrefab;
    [SerializeField]
    private int _spawnQuantity;
    [SerializeField]
    private float _spawnInterval;
    [SerializeField]
    private float _radius;

#if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.2f);
    }

    private void OnDrawGizmosSelected()
    {
        UnityEditor.Handles.color = new Color(1, 0, 0, 0.1f);
        UnityEditor.Handles.DrawSolidDisc(transform.position, Vector3.up, _radius);

    }

#endif

    private void Start() => StartCoroutine(SpawnZombiesByTime());
    private IEnumerator SpawnZombiesByTime()
    {
        while (_spawnQuantity > 0)
        {
            SpawnZombie();
            yield return new WaitForSeconds(_spawnInterval);
        }
    }
    private void SpawnZombie()
    {
        Instantiate(_zombiePrefab, transform.position, transform.rotation);
        _spawnQuantity--;
    } 
}