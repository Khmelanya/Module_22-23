using System.Collections;
using UnityEngine;

public class MedkitSpawner : MonoBehaviour
{
    [SerializeField] private MedkitItem _medkitPrefab;
    [SerializeField] private float _spawnInterval = 5f;
    [SerializeField] private float _spawnRadius = 3f;

    private Coroutine _routine;
    private MedkitItem _spawnedItem;

    public void ToggleSpawning()
    {
        if (_routine == null)
            _routine = StartCoroutine(Spawning());
        else
        {
            StopCoroutine(_routine);
            _routine = null;
        }
    }
    private IEnumerator Spawning()
    {
        while (true)
        {
            if (_spawnedItem == null)
            {
                Vector3 posision = transform.position + Random.insideUnitSphere * _spawnRadius;
                posision.y = transform.position.y;

                _spawnedItem = Instantiate(_medkitPrefab, posision, Quaternion.identity);
            }
            yield return new WaitForSeconds(_spawnInterval);
        }
    }
}
