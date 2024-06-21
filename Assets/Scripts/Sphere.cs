using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Sphere : Item<Sphere>
{
    [SerializeField] private Material _invisibleMaterial;
    [SerializeField] private Material _defaultMaterial;

    private void OnEnable()
    {
        StartCoroutine(LifeTime());
    }

    protected override void Initialize()
    {
        SetMaterial(_defaultMaterial);
        base.Initialize();

        Color color = Material.color;
        color.r = 0f;
        color.g = 0f;
        color.b = 0f;
        color.a = 1f;

        SetColor(color);
    }

    protected override IEnumerator LifeTime()
    {
        Initialize();

        FadeMaterial();

        yield return base.LifeTime();

        SetMaterial(_invisibleMaterial);
    }
}
