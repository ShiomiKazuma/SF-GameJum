using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMuzzle : MonoBehaviour
{
    /// <summary>真ん中の銃口 </summary>
    Transform _muzzlePos;
    /// <summary> プレイヤーの状態</summary>
    public PlayerCondition _playerCondition;
    /// <summary> 水鉄砲の発射間隔</summary>
    [SerializeField] float _waterGunInterval;
    /// <summary>水鉄砲の見た目</summary>
    [SerializeField] Material _waterGunMaterial;
    [SerializeField] GameObject _waterBullet = default;
    Material _playerMaterial;
    /// <summary> コルク銃の発射間隔</summary>
    [SerializeField] float _corkGunInterval;
    /// <summary>コルク銃の見た目</summary>
    [SerializeField] Material _corkGunMaterial;
    [SerializeField] GameObject _corkBullet = default;
    float _timer = 0;
    int _changeCount = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        //マズルの位置を取得
        _muzzlePos = this.transform;
        //プレイヤーの初期状態
        _playerCondition = PlayerCondition.WaterGun;
        //プレイヤーの見た目の初期化
        _playerMaterial = _waterGunMaterial;
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

        if(Input.GetMouseButtonDown(0) && _playerCondition == PlayerCondition.CorkGun && _timer > _corkGunInterval)
        {
            if(_changeCount == 0)
            {
                _playerMaterial = _corkGunMaterial;
                _changeCount = 1;
            }
            //真ん中の銃口
            Instantiate(_corkBullet, _muzzlePos.position, Quaternion.identity);
            _timer = 0;
        }
    }

    public enum PlayerCondition
    {
        WaterGun,
        CorkGun,
    }
}
