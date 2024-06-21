using UnityEngine;

public class SpawnerSphere : Spawner<Sphere>
{
    [SerializeField] private SpawnerCube _spawnerCube;

    private void OnEnable()
    {
        _spawnerCube.Spawned += SetCube;
    }

    private void OnDisable()
    {
        _spawnerCube.Spawned -= SetCube;
    }

    private void SetCube(Cube cube)
    {
        cube.Died += Spawn;
    }

    private void Spawn(Transform transform)
    {
        SetStartPosition(transform);
        GetObject();
    }
}