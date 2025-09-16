using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class rokuitiiti : MonoBehaviour
{
    //変数宣言  //constをつけることで定数にできる   
    private const int speed = 1;　//1の部分をリテラルという

    //関数（ファンクション）
    int Add(int a, int b)
    {
        //戻り値
        return a + b;
    }

    //mathf.clamp()の値
    float health = 120f;

    //メソッド（関数）
    // Start is called before the first frame update
    void Start()
    {
        PrintMessage("メソッド"); //引数を渡す

        // ローカル変数の宣言
        int score = 100;

        // ローカル変数の使用
        Debug.Log("Score: " + score);

        //型推論（var）
        var dict = new Dictionary<string, int>();
        //Dictionary<string, int> dict = new Dictionary<string, int>();

        health = Mathf.Clamp(health, 0f, 100f); // healthは100に制限される

        //parse
        string intString = "123";
        string floatString = "45.67";

        // 文字列をint型に変換
        int intValue = int.Parse(intString);
        Debug.Log("int value: " + intValue);

        // 文字列をfloat型に変換
        float floatValue = float.Parse(floatString);
        Debug.Log("float value: " + floatValue);
    }

    //messageの部分が引数
    void PrintMessage (string message)
    {
        Debug.Log(message); //引数を利用
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    float result = Clamp(15f, 0f, 10f); // 結果は 10f

    //mathf.clamp()に近い処理
    public static float Clamp(float value, float min, float max)
    {
        if (value < min) return min;
        if (value > max) return max;
        return value;
    }
}
