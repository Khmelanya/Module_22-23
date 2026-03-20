
public class CharacterAnimationController : Controller
{
    private CharacterFacade _facade;
    private CharacterView _view;

    private bool _isDead;

    public CharacterAnimationController(CharacterFacade facade, CharacterView view)
    {
        _facade = facade;
        _view = view;
    }

    protected override void UpdateLogic(float deltaTime)
    {
        if (_isDead)
            return;

        bool isMoving = _facade.Agent.velocity.magnitude > 0.1f;
        float targetWeight = _facade.HealthRatio < 0.3f ? 1f : 0f;

        _view.SetRun(isMoving);
        _view.SetInjuredWeight(targetWeight);

        if (_facade.IsDead)
        {
            _view.PlayDie();
            _isDead = true;
        }
    }
}
