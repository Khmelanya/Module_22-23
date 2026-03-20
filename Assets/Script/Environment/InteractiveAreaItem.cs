using UnityEngine;

public abstract class InteractiveAreaItem : MonoBehaviour
{
    [SerializeField] protected float Radius = 5f;

    protected virtual bool CheckRadiusOnExecute => true;

    private void OnTriggerEnter(Collider other)
    {
        if (CanInteract(other))
        {
            OnActivate(other);
        }
    }

    protected abstract void OnActivate(Collider target);
    protected abstract bool CanInteract(Collider other);

    protected void ExecuteEffect(Collider target)
    {
        if (target != null)
        {
            bool isInRange = !CheckRadiusOnExecute || Vector3.Distance(transform.position, target.transform.position) <= Radius;

            if (isInRange)
            {
                ApplyEffect(target);
            }
            else
            {

            }
        }
         Destroy(gameObject);
    }

    protected abstract void ApplyEffect(Collider target);

    private void OnDrawGizmos()
    {
        Gizmos.color = CheckRadiusOnExecute ? Color.red : Color.green;
        Gizmos.DrawWireSphere(transform.position, Radius);
    }
}

