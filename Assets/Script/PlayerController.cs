using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private const int LeftButton = 0;
    
    private const float RotationSpeed = 10f;

    private NavMeshAgent _agent;
    private Animator _animator;
    private ClickVisualizer _visualizer;    

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponentInChildren<Animator>();
        _visualizer = GetComponentInChildren<ClickVisualizer>();
    }

    private void Update()
    {
        if (_agent == null || !_agent.enabled)
            return;

        if (Input.GetMouseButtonDown(LeftButton))
        {
            MoveToClick();
        }

        RotatePlayer();
        UpdateAnimation();
    }

    private void MoveToClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            _agent.SetDestination(hit.point);
        }

        if (_visualizer != null)
        {
            _visualizer.ShowClick(hit.point);
        }
    }

    private void UpdateAnimation()
    {
        if (_animator == null)
            return;

        bool isMoving = _agent.velocity.magnitude > 0.1f;

        _animator.SetBool("isRunning", isMoving);
    }

    private void RotatePlayer()
    {
        if (_agent.velocity.sqrMagnitude > 0.1f)
        {
            Vector3 direction = _agent.velocity.normalized;
            direction.y = 0; 

            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);
        }
    }
}