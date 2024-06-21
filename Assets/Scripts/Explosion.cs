using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _radiusOverlap = 5f;
    [SerializeField] private float _force = 500f;
    [SerializeField] private SpawnerSphere _spawner;

    private void OnEnable()
    {
        _spawner.Returned += Bang;
    }

    private void OnDisable()
    {
        _spawner.Returned -= Bang;
    }

    private void Bang(Sphere sphere)
    {
        Collider[] colliders = Physics.OverlapSphere(sphere.transform.position, _radiusOverlap);

        foreach(Collider collider in colliders)
        {
            if(collider.TryGetComponent(out IExplodable explodable))
            {
                Rigidbody rigidbody= collider.GetComponent<Rigidbody>();
                rigidbody.AddExplosionForce(_force, collider.transform.position, _radiusOverlap);
            }
        }
    }
}
