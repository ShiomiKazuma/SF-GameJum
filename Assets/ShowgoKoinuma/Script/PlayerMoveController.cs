using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    /// <summary>�ړ����x</summary>
    [SerializeField] float _moveSpeed = 10;
    /// <summary>�W�����v�p���[</summary>
    [SerializeField] float _jumpPower = 10;
    /// <summary>�󒆂ł̕����]���̃X�s�[�h</summary>
    [SerializeField] float _turnSpeed = 3;
    /// <summary>�I�u�W�F�N�g���S���瑫���܂ł̋����i�v�����j</summary>
    float _isGroundedLength = 1.1f;
    Rigidbody _rb;


    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        // �����ړ�����
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");
        Vector3 dir = new Vector3(h, 0, v); // �ړ�����
        dir = Camera.main.transform.TransformDirection(dir); //�J������̃x�N�g���ɒ���
        dir.y = 0;
        dir = dir.normalized;
        Vector3 velo = dir * _moveSpeed;
        velo.y = _rb.velocity.y;
        if (!IsGround())
        {
            // �󒆂ł����������]�����\
            velo = _rb.velocity;
            if (!(dir.magnitude == 0f))
            {
                // ���x�̑傫����ێ����Ȃ���������������ς���
                Vector2 airDir = Vector2.Lerp(new Vector2(_rb.velocity.x, _rb.velocity.z), new Vector2(dir.x, dir.z) * _rb.velocity.magnitude, Time.deltaTime * _turnSpeed);
                velo = new Vector3(airDir.x, _rb.velocity.y, airDir.y);
            }
            _rb.velocity = velo;
        }
        else
        {
            _rb.velocity = velo;
        }

        // Jump����
        if (Input.GetButtonDown("Jump") && IsGround())
        {
            _rb.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
        }
    }

    /// <summary>�ڒn���Ă��邩�𔻒肷��</summary>
    /// <returns></returns>
    bool IsGround()
    {
        Vector3 start = transform.position;
        Vector3 end = start + Vector3.down * _isGroundedLength;
        return Physics.Linecast(start, end);
    }
}
