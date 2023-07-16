using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using UnityEngine;
using Slider = UnityEngine.UI.Slider;

public class PlayerHp : MonoBehaviour
{
    //HPバーを設定
    [SerializeField] private Slider _slider = default;

    /// <summary>体力の最大値/// </summary>
    [SerializeField] public float _maxHp = 100.0f;
    /// <summary>現在の体力</summary>
    public float _curentHp;
    // Start is called before the first frame update
    void Start()
    {
        //現在のHPを最大値に初期化
        _curentHp = _maxHp;
    }
    
    //プレイヤーがダメージを受けた時の処理
    public void PlayerDamage(float damage)
    {
        _curentHp -= damage;
        //HPバーの更新
        _slider.value = _curentHp / _maxHp;
    }
}
