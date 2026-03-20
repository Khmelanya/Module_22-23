using UnityEngine;
using UnityEngine.AI;

public class CharacterFacade : MonoBehaviour, IDamageable, IHealable
{
    [SerializeField] private float _maxHealth = 100f;

    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private float _movementSpeed = 5f;
    [SerializeField] private float _rotationSpeed = 500f;

    [SerializeField] private float _jumpSpeed = 5f;
    [SerializeField] private AnimationCurve _jumpCurve;


    public NavMeshAgent Agent => _agent;
    public DirectionalRotator Rotator => _rotator;
    public AgentJumper Jumper => _jumper;
    public bool IsDead => _health.IsDead;
    public float HealthRatio => _health.Ratio;
    public Vector3 CurrentVelocity => _mover.CurrentVelocity;

    private Health _health;
    private AgentJumper _jumper;
    private AgentMover _mover;
    private DirectionalRotator _rotator;

    private void Awake()
    {
        _health = new Health(_maxHealth);
        _agent.autoTraverseOffMeshLink = false;
        _agent.updateRotation = false;

        _mover = new AgentMover(_agent, _movementSpeed);
        _jumper = new AgentJumper(_jumpSpeed, _agent, this, _jumpCurve);
        _rotator = new TransformDirectionalRotator(transform, _rotationSpeed);
    }

    public void MoveTo(Vector3 position) => _mover.SetDestination(position);

    public void TakeDamage(float amount)
    {
        if (IsDead)
            return;

        _health.TakeDamage(amount);

        if (IsDead) 
            Die();
    }

    public void Heal(float amount)=> _health.Heal(amount);

    public void Die()
    {
        _agent.isStopped = true;
        _agent.enabled = false;
    }
}
