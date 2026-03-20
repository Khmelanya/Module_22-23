using System;
using UnityEngine;
public class AudioController : Controller
{
    private AudioHandier _handler;
    private AudioView _view;

    public AudioController(AudioHandier handler, AudioView view)
    {
        _handler = handler;
        _view = view;

          _view.Initialize(OnMusicToggle, OnSoundsToggle);
    }

    private void OnMusicToggle()
    {
        if (_handler.IsMusicOn())
            _handler.OffMusic();

        else _handler.OnMusic();
    }

    private void OnSoundsToggle()
    {
        if (_handler.IsSoundOn())
            _handler.OffSounds();

        else _handler.OnSounds();
    }

    protected override void UpdateLogic(float deltaTime) { }
}
