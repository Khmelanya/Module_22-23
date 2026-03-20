using UnityEngine;
using UnityEngine.UI;
using System;

public class AudioView :MonoBehaviour
{
    [SerializeField] private Button _musicButton;
    [SerializeField] private Button _soundsButton;

    public void Initialize(Action onMusicClick, Action onSoundsClick)
    {
        _musicButton.onClick.AddListener(() => onMusicClick());
        _soundsButton.onClick.AddListener(() => onSoundsClick());
    }
}
