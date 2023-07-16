using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �񕜃A�C�e���p�X�N���v�g
/// </summary>
public class Recovery : ItemBase
{
    GameObject _player;
    PlayerHp _playerHp;
    public float _recveryHp = 20f;


    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player");
        _playerHp = _player.GetComponent<PlayerHp>();
    }

    // Update is called once per frame
    public override void Item()
    {
        //HP��
        _playerHp._curentHp += _recveryHp;
        //HP���ő�l��葽����΍ő�l�ɂ���
        if(_playerHp._curentHp > _playerHp._maxHp)
        {
            _playerHp._curentHp = _playerHp._maxHp;
        }
    }
}
