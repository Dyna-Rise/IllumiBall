using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    //どのボールを吸い寄せるかをタグで指定
    public string targetTag;
    bool isHolding;　//目的のボールがゴールしたというフラグ

    //ボールが入っているかtrueかfalseかで返す
    public bool IsHolding()
    {
        return isHolding;
    }

    //目的物が入ったらフラグON
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == targetTag)
        {
            isHolding = true;
        }
    }

    //目的物が抜けたらフラグOFF
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == targetTag)
        {
            isHolding = false;
        }
    }


    private void OnTriggerStay(Collider other)
    {
        //コライダーに触れているオブジェクトのRigidbodyを取得
        Rigidbody r = other.gameObject.GetComponent<Rigidbody>();

        //ボールの方向を計算
        Vector3 direction = other.gameObject.transform.position - transform.position;

        //方向を正規化して directionを1（-1）に書き換える
        direction.Normalize();

        //タグに応じてボールに力を加える
        if(other.gameObject.tag == targetTag)
        {
            //中心地点でボールを止めるため速度を減速させる
            r.velocity *= 0.9f;
            r.AddForce(direction * -20.0f,ForceMode.Acceleration);
        }
        else
        {
            //HoleからみてBall（相手）の方向に弾く
            r.AddForce(direction * 80.0f,ForceMode.Acceleration);
        }
    }
}
