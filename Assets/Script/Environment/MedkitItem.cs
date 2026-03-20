using UnityEngine;

public class MedkitItem : InteractiveAreaItem
{
    [SerializeField] private float _healAmount = 10f;
    protected override bool CheckRadiusOnExecute => false;
    protected override bool CanInteract(Collider other) => other.GetComponentInParent<IHealable>() != null;

    protected override void OnActivate(Collider target) => ExecuteEffect(target);

    protected override void ApplyEffect(Collider target)
    {
        if (target.TryGetComponent(out IHealable patient))
            patient.Heal(_healAmount);
    }
}
