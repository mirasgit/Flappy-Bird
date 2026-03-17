using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float _maxTime = 1.5f;
    [SerializeField] private float _heightRange = 0.45f;
    [SerializeField] private GameObject _pipe;

    private float _timer;

    private ObjectPool<GameObject> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<GameObject>(
            CreatePipe,
            OnGetPipe,
            OnReleasePipe,
            OnDestroyPipe,
            true,
            10,
            20);
    }

    private void Start()
    {
        SpawnPipe();
    }


    private void Update()
    {
        if (_timer > _maxTime)
        {
            SpawnPipe();
            _timer = 0;
        }

        _timer += Time.deltaTime;
    }

    private void SpawnPipe()
    {
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-_heightRange, _heightRange));
        //GameObject pipe = Instantiate(_pipe, spawnPos, Quaternion.identity);
        //Destroy(pipe, 10f);
        GameObject pipe = _pool.Get();
        pipe.transform.position = spawnPos;

        StartCoroutine(ReturnToPool(pipe, 10f));
    }
    private GameObject CreatePipe() => Instantiate(_pipe);

    private void OnGetPipe(GameObject pipe) => pipe.SetActive(true);

    private void OnReleasePipe(GameObject pipe)
    {
        pipe.SetActive(false);
    }
    private void OnDestroyPipe(GameObject pipe)
    {
        Destroy(pipe);
    }

    private IEnumerator ReturnToPool(GameObject pipe, float time)
    {
        yield return new WaitForSeconds(time);
        _pool.Release(pipe);
    }
}
