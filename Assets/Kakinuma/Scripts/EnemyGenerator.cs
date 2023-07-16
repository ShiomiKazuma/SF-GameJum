using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵生成用スクリプト
/// </summary>
public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] GameObject _enemyPrefab = null;
    [SerializeField, Range(0.1f, 5f)] float _interval = 3f;
    float _timer;

    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _interval)
        {
            _timer = 0;
            Instantiate(_enemyPrefab, this.transform.position, _enemyPrefab.transform.rotation);
        }
    }
}
