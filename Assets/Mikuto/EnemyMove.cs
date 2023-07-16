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
    [Tooltip("�d�͂𖳎����Ĉړ����邩�̃t���O")]
    [SerializeField] bool _toggleGravity = false;
    Rigidbody _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //���ʂ��^�[�Q�b�g�̕����Ɍ�����
        transform.forward = (_target.transform.position - transform.position).normalized;
        if( !_toggleGravity )
        {
            //�^�[�Q�b�g�Ɍ������Ĉړ�������(�d�͖���)
            _rb.velocity = (_target.transform.position - transform.position).normalized * _moveSpeed;
        }
        else
        {
            //�^�[�Q�b�g�Ɍ������Ĉړ�������(�d�͂���)
            Vector3 velo = (_target.transform.position - transform.position).normalized * _moveSpeed;
            _rb.velocity = new Vector3(velo.x, _rb.velocity.y, velo.z);
        }
    }
}
