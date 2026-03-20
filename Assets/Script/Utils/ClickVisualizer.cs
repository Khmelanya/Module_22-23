using UnityEngine;

public class ClickVisualizer : MonoBehaviour
{
    [SerializeField] private Transform _flagPrefab;

    private Transform _currentFlag;

    public void ShowClick(Vector3 position)
    {
        if (_flagPrefab == null)
            return;

        if (_currentFlag == null)
            _currentFlag = Instantiate(_flagPrefab);

        _currentFlag.gameObject.SetActive(true);

        _currentFlag.position = position + Vector3.up * 0.1f;
    }

    public void Hide()
    {
        if (_currentFlag != null)
            _currentFlag.gameObject.SetActive(false);
    }
}


