using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using UnityEngine;
using Slider = UnityEngine.UI.Slider;

public class PlayerHp : MonoBehaviour
{
    //HP�o�[��ݒ�
    [SerializeField, Header ("HP�o�[��ݒ�")] private Slider _slider = default;

    /// <summary>�̗͂̍ő�l/// </summary>
    [SerializeField, Header("�̗͂̍ő�l")] public float _maxHp = 100.0f;
    /// <summary>���݂̗̑�</summary>
    [Header("���݂̗̑�")] public float _curentHp;
    // Start is called before the first frame update
    void Start()
    {
        //���݂�HP���ő�l�ɏ�����
        _curentHp = _maxHp;
    }
    
    //�v���C���[���_���[�W���󂯂����̏���
    public void PlayerDamage(float damage)
    {
        _curentHp -= damage;
        //HP�o�[�̍X�V
        _slider.value = _curentHp / _maxHp;
    }
}
