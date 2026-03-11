using UnityEngine;


public class PlayerHealth : MonoBehaviour
{
    private const string Die = "Die";

    private const float InjuryThreshold = 0.3f;

    [SerializeField] private Animator _animator;

    [SerializeField] private float _maxHealth = 100f;

    private float _currentHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }
    public void TakeDamage(float damage)
    {
        if (damage < 0)
            return;

        _currentHealth -= damage;

        float criticalHealth = _maxHealth * InjuryThreshold;

        if (_currentHealth <= 0)
        {
            _currentHealth = 0;

            _animator.SetLayerWeight(1, 0f);
            _animator.SetTrigger(Die);
        }

        else if (_currentHealth <= criticalHealth)
            _animator.SetLayerWeight(1, 1f);
    }
}
