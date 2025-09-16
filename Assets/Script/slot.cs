using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class slot : MonoBehaviour
{
    // 数字を表示するTextMeshProUGUIコンポーネントの配列
    public TextMeshProUGUI[] numberTexts;

    // 数字の更新間隔（秒）をInspectorで調整可能
    [Range(0.1f, 5f)]
    public float interval = 1.0f;

    // 各数字ごとのCoroutine参照を保持する
    private Coroutine[] coroutines;

    // 各数字の一時停止状態を記録する
    private bool[] isPaused;

    // 各テキストの現在の数字を記録する
    private int[] currentNumbers;

    // Spaceキーを押した回数をカウントし、どこまで停止したかを管理
    private int pauseCount = 0;

    void Start()
    {
        　　　　　　　　　　　　　　　　　　　　//LengthでInspector内の配列の長さを返す
        coroutines = new Coroutine[numberTexts.Length];　//Coroutineの保存
        isPaused = new bool[numberTexts.Length];　//停止中かどうかを記録(trueなら止まる）
        currentNumbers = new int[numberTexts.Length];　//数字は個別に動くため状態をそれぞれ記録

        for (int i = 0; i < numberTexts.Length; i++)
        {
            currentNumbers[i] = 1; // 初期値は1
            // 各Textごとにループ処理を開始
            coroutines[i] = StartCoroutine(LoopNumber(i));
        }
    }

    // 毎フレーム呼び出される。スペースキーで一時停止またはリセット。
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (pauseCount < numberTexts.Length)
            {
                // まだ一時停止していないテキストを順番に止める
                isPaused[pauseCount] = true;
                pauseCount++;
            }
            else
            {
                // 全て止まったらリセット処理
                ResetAll();
            }
        }
    }

    // 指定インデックスの数字をループで更新するCoroutine
    IEnumerator LoopNumber(int index)
    {
        while (true)
        {
            numberTexts[index].text = currentNumbers[index].ToString(); // 表示更新
            float timer = 0f;

            while (timer < interval)
            {
                if (!isPaused[index]) 　// trueじゃなければ
                    timer += Time.deltaTime;　//経過時間

                yield return null;　//1秒になるまで
            }

            if (!isPaused[index])
            {
                currentNumbers[index]++;
                if (currentNumbers[index] > 7)
                    currentNumbers[index] = 1; // 1〜7でループ
            }
        }
    }

    // 全ての数字をリセットして再スタート
    void ResetAll()
    {
        for (int i = 0; i < numberTexts.Length; i++)
        {
            if (coroutines[i] != null)
                StopCoroutine(coroutines[i]); // 古いCoroutineを止める

            isPaused[i] = false;
            currentNumbers[i] = 1;
            numberTexts[i].text = "1";
            coroutines[i] = StartCoroutine(LoopNumber(i)); // 新しく開始
        }

        pauseCount = 0; // カウンターも初期化
    }
}


