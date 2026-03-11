using UnityEngine;

public class Mine : MonoBehaviour
{
    private const float ExplosionDelay = 2f;
    private const float ExplosionRadius = 5f;

    private PlayerHealth _targetPlayer;

    [SerializeField] private float _damage = 30f;

    private bool _isActivated;
    private float _timer;

       private void Awake()
    {
        _timer = ExplosionDelay;

        GetComponent<SphereCollider>().radius = ExplosionRadius;
    }

    private void Update()
    {
        if (_isActivated == false)
            return;

        _timer -= Time.deltaTime;

        if (_timer <= 0)
            Explode();
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            _targetPlayer = playerHealth;
            _isActivated = true;
        }
    }

    private void Explode()
    {
        if (_targetPlayer != null)
        {
            float distance = Vector3.Distance(transform.position, _targetPlayer.transform.position);

            if (distance <= ExplosionRadius)
                _targetPlayer.TakeDamage(_damage);
        }

        Destroy(gameObject);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, ExplosionRadius);
    }
}
