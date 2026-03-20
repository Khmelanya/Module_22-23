public class AgentJumpController : Controller
{
    private CharacterFacade _facade;

    public AgentJumpController(CharacterFacade facade)
    {
        _facade = facade;
    }

    protected override void UpdateLogic(float deltaTime)
    {
        if (_facade.IsDead)
            return;

        if (_facade.Agent.isOnOffMeshLink && !_facade.Jumper.InProcess)
            _facade.Jumper.Jump(_facade.Agent.currentOffMeshLinkData);
    }
}
