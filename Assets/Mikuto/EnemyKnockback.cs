using UnityEngine;
/// <summary>
/// �G�l�~�[���v���C���[�ɓ����������A�v���C���[���m�b�N�o�b�N������R���|�[�l���g
/// </summary>
public class EnemyKnockback : MonoBehaviour
{
    [Tooltip("�v���C���[�𐁂���΂���")]
    [SerializeField] float _knockback = 2f;
    private void OnCollisionEnter(Collision collision)
    {
        //�Ԃ������Ώۂ��v���C���[�̃^�O�������Ă�����
        if (collision.gameObject.CompareTag("Player"))
        {
            //�Ԃ������v���C���[��rigidbody�R���|�[�l���g�������Ă�����
            if (collision.gameObject.TryGetComponent(out Rigidbody rb))
            {
                Vector3 velo = (collision.transform.position - transform.position).normalized * _knockback;
                rb.AddForce(velo, ForceMode.Impulse);
            }
        }
    }
}
