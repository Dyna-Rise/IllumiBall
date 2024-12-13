using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    //重力加速度（定数）
    const float Gravity = 9.81f;

    //重力の適用具合（重力の強さをコントロール）
    public float gravityScale = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vector = new Vector3(); //重力ベクトルの初期化

        //キーの入力を検知しベクトルを設定
        vector.x = Input.GetAxis("Horizontal");
        vector.z = Input.GetAxis("Vertical");

        //ひっくり返しを表現するZキーがおされたら
        if (Input.GetKey("z"))
        {
            vector.y = 1.0f;
        }
        else
        {
            vector.y = -1.0f;
        }

        //シーンの重力を入力ベクトルの方向に合わせて変化させる
        Physics.gravity = Gravity * vector.normalized * gravityScale;
    }
}
