using UnityEngine;
using System.Collections;
public class Mine : InteractiveAreaItem
{
    [SerializeField] private float _damage = 30f;
    [SerializeField] private float _detonationDelay = 1.5f;
    [SerializeField] private MineView _view;

    private void Awake()
    {
        SphereCollider sphereCollider = GetComponent<SphereCollider>();

        if (sphereCollider != null)
            sphereCollider.radius = Radius;
    }
    protected override bool CanInteract(Collider other) => other.GetComponent<IDamageable>() != null;
    protected override void OnActivate(Collider target) => StartCoroutine(DetonationRoutine(target));

    private IEnumerator DetonationRoutine(Collider target)
    {
        yield return new WaitForSeconds(_detonationDelay);

        if (_view != null)
            _view.PlayExplosion();

        ExecuteEffect(target);
    }

    protected override void ApplyEffect(Collider target)
    {
        if (target.TryGetComponent(out IDamageable damageable))
            damageable.TakeDamage(_damage);
    }
}

