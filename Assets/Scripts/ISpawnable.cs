using UnityEngine;

public interface ISpawnable
{
    public void SetSpawner<T>(Spawner<T> spawner) where T : MonoBehaviour, ISpawnable;
}
