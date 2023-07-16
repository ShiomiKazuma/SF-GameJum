using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MoveCompas : MonoBehaviour
{
    [SerializeField] Image _image;                  //�R���p�X�̃C���[�W
    [SerializeField] Transform _player;             //�v���C���[�̈ʒu�Ȃǎ擾
    [SerializeField] float _angleOffset = 0f;       //�A���O���̏�����

    RectTransform rt;                               //UI�p��Transform
    Quaternion q;                                   //�R���p�X�̉�]
    Quaternion offset;                              //��]�̃I�t�Z�b�g


    // Start is called before the first frame update
    void Start()
    {
        rt = _image.rectTransform;                                      //�R���p�X�̈ʒu�iTransform�j
        offset = Quaternion.AngleAxis(_angleOffset, Vector3.up);        //player�̂����𒆐S�ɉ�]����

    }

    // Update is called once per frame
    void Update()
    {
        q = _player.rotation * offset;                                  //player�̉�]���擾
        q.z = q.y;
        q.y = 0f;
        
        rt.rotation = q;                                                //�R���p�X�̂�����player�̂����ŉ�]������
    }
}
