using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    //重力加速度
    const float Gravity = 9.81f;

    //重力の適用具合
    public float gravityScale = 1.0f;

    // Update is called once per frame
    void Update()
    {
        Vector3 vector = new Vector3();

        //スマホ上で起動しているかどうかを判断
        if (Application.isMobilePlatform)
        {
            //加速度センサーが拾った値を変数vectorの値とする
            vector.x = Input.acceleration.x;
            vector.z = Input.acceleration.y;
            vector.y = Input.acceleration.z;
        }
        else //OSがスマホのものではないとした場合キーボード操作
        { 
            //キーの入力を検知しベクトルを設定
            vector.x = Input.GetAxis("Horizontal");
            vector.z = Input.GetAxis("Vertical");

            //高さ方向の判定はキーのzとする
            if (Input.GetKey("z")) //ひっくり返している
            {
                vector.y = 1.0f;
            }
            else
            {
                vector.y = -1.0f;
            }
        }

        //シーンの重力を入力ベクトルの方向に合わせて変化
        Physics.gravity = Gravity * vector.normalized * gravityScale;
        
    }
}
