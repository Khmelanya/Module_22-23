using UnityEngine;
using UnityEngine.Audio;

public class GameEntryPoint : MonoBehaviour
{
    [SerializeField] private CharacterFacade _playerFacade;
    [SerializeField] private ClickVisualizer _clickVisualizer;
    [SerializeField] private MedkitSpawner _medkitSpawner;
    [SerializeField] private CharacterView _playerView;

    [SerializeField] private AudioMixer _mainMixer;
    [SerializeField] private AudioView _audioView;

    private Controller _mainController;

    private void Awake()
    {
        AudioHandier audioHandler = new AudioHandier(_mainMixer);

        _mainController = new CompositeController(
            new PlayerInputController(_playerFacade, _clickVisualizer, _medkitSpawner), 
            new MovementRotationController(_playerFacade),                           
            new AgentJumpController(_playerFacade),
            new CharacterAnimationController(_playerFacade, _playerView),
            new AudioController(audioHandler, _audioView)
        );

        _mainController.Enable();
    }

    private void Update() => _mainController.Update(Time.deltaTime);
}
