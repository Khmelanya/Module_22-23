using UnityEngine;

public class MovementRotationController : Controller
{
    private CharacterFacade _facade;

    public MovementRotationController(CharacterFacade facade)
    {
        _facade = facade;
    }
    protected override void UpdateLogic(float deltaTime)
    {
        if (_facade.IsDead)
            return;

        Vector3 velocity = _facade.Agent.velocity;

        if (velocity.magnitude > 0.1f)
        {
            _facade.Rotator.SetInputDirection(velocity);
            _facade.Rotator.Update(deltaTime);
        }
    }
}
