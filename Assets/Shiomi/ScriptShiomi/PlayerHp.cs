using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using UnityEngine;
using Slider = UnityEngine.UI.Slider;

public class PlayerHp : MonoBehaviour
{
    /// <summary>�̗͂̍ő�l/// </summary>
    [SerializeField] float _maxHp = 100.0f;
    /// <summary>���݂̗̑�</summary>
    [SerializeField] float _curentHp;
    Slider _slider;
    // Start is called before the first frame update
    void Start()
    {
        //Slider���擾
        _slider = GetComponent<Slider>();
        //���݂�HP���ő�l�ɏ�����
        _curentHp = _maxHp;
    }
    
    // Update is called once per frame
    void Update()
    {
        //  Hp�o�[�̍X�V
        _slider.value = _curentHp / _maxHp;
    }

    //�v���C���[���_���[�W���󂯂����̏���
    public void PlayerDamage(float damage)
    {
        _curentHp -= damage;
        Debug.Log(_curentHp);
    }
}
