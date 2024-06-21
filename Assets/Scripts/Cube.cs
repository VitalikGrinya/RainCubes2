using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Cube : Item<Cube>
{
    private bool _isOnCollision = false;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out Platform platform))
        {
            HandleCollision();
        }
    }

    protected override void Reset()
    {
        base.Reset();
        _isOnCollision = false;
    }

    protected override IEnumerator LifeTime()
    {
        base.Initialize();

        yield return base.LifeTime();
    }

    private void HandleCollision()
    {
        if(_isOnCollision == false) 
        { 
            StartCoroutine(LifeTime());
            _isOnCollision= true;
        }
    }
}
