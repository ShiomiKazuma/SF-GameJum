using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using UnityEngine;
using Slider = UnityEngine.UI.Slider;

public class PlayerHp : MonoBehaviour
{
    /// <summary>体力の最大値/// </summary>
    [SerializeField] float _maxHp = 100.0f;
    /// <summary>現在の体力</summary>
    [SerializeField] float _curentHp;
    Slider _slider;
    // Start is called before the first frame update
    void Start()
    {
        //Sliderを取得
        _slider = GetComponent<Slider>();
        //現在のHPを最大値に初期化
        _curentHp = _maxHp;
    }
    
    // Update is called once per frame
    void Update()
    {
        //  Hpバーの更新
        _slider.value = _curentHp / _maxHp;
    }

    //プレイヤーがダメージを受けた時の処理
    public void PlayerDamage(float damage)
    {
        _curentHp -= damage;
        Debug.Log(_curentHp);
    }
}
