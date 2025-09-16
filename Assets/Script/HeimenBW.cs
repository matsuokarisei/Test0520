using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeimenBW : MonoBehaviour
{
    public GameObject cubePrefab; // CubeのPrefab（マテリアル未設定でもOK）

    [Header("生成するブロックの数")]
    [Range(1, 50)] public int XCount = 20; // X軸（列数）
    [Range(1, 30)] public int YCount = 10;    // Y軸（行数）
    [Range(0.01f,1f)]public float delay = 0.05f;    // 生成間隔（秒）
    private float space = 1.0f;   // Cube間の距離

    [Tooltip("Cubeに使う色（自由に追加OK）")]
    public List<Color> cubeColors = new List<Color> { Color.white, Color.black };

    private List<GameObject> generatedCubes = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        GenerateA(); // 遅延なしで即時生成
        StartCoroutine(ScaleLoop()); // アニメーション開始
    }

    void GenerateA()
    {
        int colorCount = cubeColors.Count;

        for (int x = 0; x < XCount; x++)
        {
            if (x % 2 == 0)
            {
                for (int y = 0; y < YCount; y++)
                {
                    GenerateB(x, y, colorCount);
                }
            }
            else
            {
                for (int y = YCount - 1; y >= 0; y--)
                {
                    GenerateB(x, y, colorCount);
                }
            }
        }
    }

    IEnumerator ScaleLoop()
    {
        while (true)
        {
            // 1. 左下から順番に消す
            for (int i = 0; i < generatedCubes.Count; i++)
            {
                    generatedCubes[i].transform.localScale = Vector3.one * 0.5f;

                yield return new WaitForSeconds(delay);
            }

            // 2. 逆順に元に戻す
            for (int i = generatedCubes.Count - 1; i >= 0; i--)
            {
                    generatedCubes[i].transform.localScale = Vector3.one;

                yield return new WaitForSeconds(delay);
            }
        }
    }

    void GenerateB(int x, int y, int colorCount)
    {
        // 配置座標
        Vector3 pos = new Vector3(x * space, y * space);

        // Cube生成
        GameObject cube = Instantiate(cubePrefab, pos, Quaternion.identity, this.transform);

        // ジグザグ順インデックスを計算（列の高さが rowCount に対応）
        int linearIndex = x * YCount + (x % 2 == 0 ? y : (YCount - 1 - y));
        int colorIndex = linearIndex % colorCount;

        cube.GetComponent<Renderer>().material.color = cubeColors[colorIndex];

        generatedCubes.Add(cube); // 保存
    }
}