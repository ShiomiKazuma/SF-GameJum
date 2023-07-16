using UnityEngine;
/// <summary>
/// �G�l�~�[�̈ړ��Ɋւ���R���|�[�l���g
/// </summary>
public class EnemyMove : MonoBehaviour
{
    [Tooltip("�G�l�~�[�̈ړ����x�p�����[�^")]
    [SerializeField] float _moveSpeed = 1f;
    [Tooltip("�^�[�Q�b�g")]
    [SerializeField] GameObject _target;
    [Tooltip("�ړ��̎��")]
    [SerializeField] MoveType _moveType = MoveType.Default;
    Rigidbody _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (_target == null) return;
        //���ʂ��^�[�Q�b�g�̕����Ɍ�����
        transform.forward = (_target.transform.position - transform.position).normalized;
        switch (_moveType)
        {
            case MoveType.Default:
                Vector3 velo = (_target.transform.position - transform.position).normalized * _moveSpeed;
                _rb.velocity = new Vector3(velo.x, _rb.velocity.y, velo.z);
                break;
            case MoveType.NoGravity:
                _rb.velocity = (_target.transform.position - transform.position).normalized * _moveSpeed;
                break;
            case MoveType.Ghost:
                float sin = Mathf.Sin(Time.time*2);
                Vector3 velo2 = (_target.transform.position - transform.position).normalized * _moveSpeed;
                _rb.velocity = new Vector3(velo2.x, 2*sin, velo2.z);
                break;
        }
    }
}
enum MoveType
{
    /// <summary>�d�͂������ԂŃ^�[�Q�b�g�Ɍ������Ĉړ�������</summary>
    Default,
    /// <summary>�d�͂𖳎�������ԂŃ^�[�Q�b�g�Ɍ������Ĉړ�������</summary>
    NoGravity,
    Ghost,
}