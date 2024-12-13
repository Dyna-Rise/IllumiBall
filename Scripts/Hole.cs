using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    //どのタグ名が書いてあるボールを目的とするか
    public string targetTag;

    //目的のボールがあるかどうか
    bool isHolding;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //目的のボールがあるかないかの結果を示す
    public bool IsHolding()
    {
        return isHolding;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == targetTag)
        {
            //目的の相手が入ってきたらフラグを立てる
            isHolding = true;
        }    
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == targetTag)
        {
            //目的の相手が脱出してしまったらフラグを降ろす
            isHolding = false;
        }
    }

    void OnTriggerStay(Collider other)
    {
        //接触した相手のRigidbodyを参照
        Rigidbody r = other.gameObject.GetComponent<Rigidbody>();

        //ボールがどの位置にあるかを計算
        Vector3 direction = other.gameObject.transform.position - transform.position;
        //ボールとの距離差を正規化して値1に整える
        direction.Normalize();

        //タグに応じて吸い寄せるか、引き離すか
        if(other.gameObject.tag == targetTag)
        {
            //一致していれば中心に引き寄せる
            r.velocity *= 0.9f;
            r.AddForce(direction * -20.0f, ForceMode.Acceleration);
        }
        else
        {
            //異なっていれば弾く
            r.AddForce(direction * 80.0f,ForceMode.Acceleration);
        }

    }
}
