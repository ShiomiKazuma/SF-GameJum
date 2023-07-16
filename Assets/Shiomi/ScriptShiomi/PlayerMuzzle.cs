using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMuzzle : MonoBehaviour
{
    /// <summary>�^�񒆂̏e�� </summary>
    Transform _muzzlePos;
    /// <summary> �v���C���[�̏��</summary>
    public PlayerCondition _playerCondition;
    /// <summary> ���S�C�̔��ˊԊu</summary>
    [SerializeField] float _waterGunInterval;
    /// <summary>���S�C�̌�����</summary>
    [SerializeField] Material _waterGunMaterial;
    [SerializeField] GameObject _waterBullet = default;
    Material _playerMaterial;
    /// <summary> �R���N�e�̔��ˊԊu</summary>
    [SerializeField] float _corkGunInterval;
    /// <summary>�R���N�e�̌�����</summary>
    [SerializeField] Material _corkGunMaterial;
    [SerializeField] GameObject _corkBullet = default;
    float _timer = 0;
    int _changeCount = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        //�}�Y���̈ʒu���擾
        _muzzlePos = this.transform;
        //�v���C���[�̏������
        _playerCondition = PlayerCondition.WaterGun;
        //�v���C���[�̌����ڂ̏�����
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
            //�^�񒆂̏e��
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
