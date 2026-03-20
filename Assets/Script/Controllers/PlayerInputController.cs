using UnityEngine;

public class PlayerInputController : Controller
{
    private const int LeftMouseButton = 0;
    private const KeyCode MedkitSpawnKey = KeyCode.F;

    private CharacterFacade _facade;
    private ClickVisualizer _visualizer;
    private MedkitSpawner _medkitSpawner;
    private Camera _camera;

    public PlayerInputController(CharacterFacade facade, ClickVisualizer visualizer, MedkitSpawner spawner)
    {
        _facade = facade;
        _visualizer = visualizer;
        _medkitSpawner = spawner;
        _camera = Camera.main;
    }
    protected override void UpdateLogic(float deltaTime)
    {
        if (_facade.IsDead)
            return;

        if (Input.GetMouseButtonDown(LeftMouseButton))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                _facade.MoveTo(hit.point);
                _visualizer.ShowClick(hit.point);
            }
        }

        if (Input.GetKeyDown(MedkitSpawnKey))
            _medkitSpawner.ToggleSpawning();

        if (_facade.Agent.remainingDistance <= _facade.Agent.stoppingDistance + 0.1f)
            _visualizer.Hide();
    }
}


