using UnityEngine;

public class MineView : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _explosionClip;

    public void PlayExplosion()
    {
        if (_audioSource != null && _explosionClip != null)
            _audioSource.PlayOneShot(_explosionClip);
    }
}
