using UnityEngine;

public class ClickVisualizer : MonoBehaviour
{
    [SerializeField] private GameObject _flagPrefab;

    [SerializeField] private float _destroyDelay = 2f;

    public void ShowClick(Vector3 position)
    {
        if (_flagPrefab == null)
            return;

        GameObject flag = Instantiate(_flagPrefab, position, Quaternion.identity);

        Destroy(flag, _destroyDelay);
    }
}


