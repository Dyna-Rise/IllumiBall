using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClearDetector : MonoBehaviour
{
    public Hole holeRed;
    public Hole holeBlue;
    public Hole holeGreen;

    public GameObject panel; //UIパネル

    private void Start()
    {
        //最初は非表示
        panel.SetActive(false);
    }

    private void Update()
    {
        //すべてのボールが入ったらラベル表示
        if (holeRed.IsHolding() && holeBlue.IsHolding() && holeGreen.IsHolding())
        {
            panel.SetActive(true);
        }
        else
        {
            panel.SetActive(false);
        }
    }

    //簡易ＵＩ
    //private void OnGUI()
    //{
    //    //すべてのボールが入ったらラベル表示
    //    if(holeRed.IsHolding() && holeBlue.IsHolding() && holeGreen.IsHolding())
    //    {
    //        //画面より左から50の位置，上から50の位置、幅100、高さ30のテキストエリアを作り、文字を表示
    //        GUI.Label(new Rect(50, 50, 100, 30), "Game Clear!");
    //    }
    //}
}
