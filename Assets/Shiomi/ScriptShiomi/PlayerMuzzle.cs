using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMuzzle : MonoBehaviour
{
    /// <summary>マズルの位置 </summary>
    Transform _muzzlePos;
    /// <summary> プレイヤーの状態</summary>
    public PlayerCondition _playerCondition;

    /// <summary> 水鉄砲の発射間隔</summary>
    [SerializeField] float _waterGunInterval;

    [SerializeField] GameObject _waterBullet = default;
    float _timer = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        //マズルの位置を取得
        _muzzlePos = this.transform;
        //プレイヤーの初期状態
        _playerCondition = PlayerCondition.WaterGun;

        _timer = _waterGunInterval;
    }

    // Update is called once per frame
    void Update()
    {
         _timer += Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && _playerCondition == PlayerCondition.WaterGun && _timer  > _waterGunInterval)
        {
            Instantiate(_waterBullet, _muzzlePos.position, Quaternion.identity);
            _timer = 0;
        }
    }

    public enum PlayerCondition
    {
        WaterGun,
        CorkGun,
    }
}
