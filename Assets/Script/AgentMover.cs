using UnityEngine.AI;
using UnityEngine;

public class AgentMover
{
    private NavMeshAgent _agent;

    public AgentMover(NavMeshAgent agent, float movementSpeed)
    {
        _agent = agent;
        _agent.speed = movementSpeed;
        _agent.acceleration = 999;
    }

    public Vector3 CurrentVelocity => _agent.velocity;

    public void SetDestination(Vector3 position)
    {
        if(_agent.isOnNavMesh)
        _agent.SetDestination(position);
    }
}
