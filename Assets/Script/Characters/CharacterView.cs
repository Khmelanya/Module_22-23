using UnityEngine;

public class CharacterView : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private string _runParam = "isRunning";
    private string _dieTrigger = "Die";

    private int _injuredLayerIndex = 1;

    public void SetRun(bool isRunning) => _animator.SetBool(_runParam, isRunning);

    public void SetInjuredWeight(float weight)
    {
        float current = _animator.GetLayerWeight(_injuredLayerIndex);

        _animator.SetLayerWeight(_injuredLayerIndex, Mathf.Lerp(current, weight, Time.deltaTime * 5f));
    }

    public void PlayDie() => _animator.SetTrigger(_dieTrigger);
}
