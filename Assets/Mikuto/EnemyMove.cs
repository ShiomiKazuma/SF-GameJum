using UnityEngine;
/// <summary>
/// エネミーの移動に関するコンポーネント
/// </summary>
public class EnemyMove : MonoBehaviour
{
    [Tooltip("エネミーの移動速度パラメータ")]
    [SerializeField] float _moveSpeed = 1f;
    [Tooltip("ターゲット")]
    [SerializeField] GameObject _target;
    [Tooltip("重力を無視して移動するかのフラグ")]
    [SerializeField] bool _toggleGravity = false;
    Rigidbody _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //正面をターゲットの方向に向ける
        transform.forward = (_target.transform.position - transform.position).normalized;
        if( !_toggleGravity )
        {
            //ターゲットに向かって移動させる(重力無視)
            _rb.velocity = (_target.transform.position - transform.position).normalized * _moveSpeed;
        }
        else
        {
            //ターゲットに向かって移動させる(重力あり)
            Vector3 velo = (_target.transform.position - transform.position).normalized * _moveSpeed;
            _rb.velocity = new Vector3(velo.x, _rb.velocity.y, velo.z);
        }
    }
}
