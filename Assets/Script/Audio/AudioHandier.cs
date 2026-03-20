using UnityEngine;
using UnityEngine.Audio;

public class AudioHandier
{
    private const float OffVolumeValue = -80;
    private const float OnVolumeValue = 0;
    private const string MusicKey = "MusicVolume";
    private const string SoundsKey = "SoundsVolume";

    private AudioMixer _audioMixer;

    public AudioHandier(AudioMixer audioMixer)
    {
        _audioMixer = audioMixer;
    }

    public bool IsMusicOn() => IsVolumeOn(MusicKey);
    public bool IsSoundOn() => IsVolumeOn(SoundsKey);
    public void OffMusic() => _audioMixer.SetFloat(MusicKey, OffVolumeValue);
    public void OnMusic() => _audioMixer.SetFloat(MusicKey, OnVolumeValue);
    public void OffSounds() => _audioMixer.SetFloat(SoundsKey, OffVolumeValue);
    public void OnSounds() => _audioMixer.SetFloat(SoundsKey, OnVolumeValue);

    private bool IsVolumeOn(string key)
        => _audioMixer.GetFloat(key, out float volume) && Mathf.Abs(volume - OnVolumeValue) <= 0.01f;
}

