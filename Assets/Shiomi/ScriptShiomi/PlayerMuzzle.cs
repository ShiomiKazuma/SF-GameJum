using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMuzzle : MonoBehaviour
{
    /// <summary>�}�Y���̈ʒu </summary>
    Transform _muzzlePos;
    /// <summary> �v���C���[�̏��</summary>
    public PlayerCondition _playerCondition;

    /// <summary> ���S�C�̔��ˊԊu</summary>
    [SerializeField] float _waterGunInterval;

    [SerializeField] GameObject _waterBullet = default;
    float _timer = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        //�}�Y���̈ʒu���擾
        _muzzlePos = this.transform;
        //�v���C���[�̏������
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
