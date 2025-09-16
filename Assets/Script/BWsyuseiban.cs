using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BWsyuseiban : MonoBehaviour
{
    public GameObject cubePrefab; // CubeのPrefab（マテリアル未設定でもOK）
    public float spacing = 1.0f;   // Cube間の距離
    public float delay = 0.05f;    // 生成間隔（秒）

    [Tooltip("Cubeに使う色（自由に追加OK）")]
    public List<Color> cubeColors = new List<Color> { Color.white, Color.black };

    private List<GameObject> generatedCubes = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenerateCubes());
    }

    IEnumerator GenerateCubes()
    {
        int colorCount = cubeColors.Count;

        for (int x = 0; x < 9; x++)
        {
            for (int y = 0; y < 9; y++)
            {
                for (int z = 0; z < 9; z++)
                {
                    // 中心の7×7×7をスキップ
                    if (x > 0 && x < 8 && y > 0 && y < 8 && z > 0 && z < 8)
                        continue;

                    // 上面(y==8)の7×7をスキップ
                    if (y == 8 && x > 0 && x < 8 && z > 0 && z < 8)
                        continue;

                    // 配置座標
                    Vector3 pos = new Vector3(x * spacing, y * spacing, z * spacing);

                    // Cube生成
                    GameObject cube = Instantiate(cubePrefab, pos, Quaternion.identity, this.transform);

                    // 色の設定（白黒交互）
                   // Renderer rend = cube.GetComponent<Renderer>();
                   // if ((x + y + z) % 2 == 0)
                       // rend.material.color = Color.white;
                   // else
                       // rend.material.color = Color.black;

                    // カラーをリストから選ぶ（順番か交互で）
                    int colorIndex = (x + y + z) % colorCount;
                    cube.GetComponent<Renderer>().material.color = cubeColors[colorIndex];

                    generatedCubes.Add(cube); // 保存

                    // 遅延
                    yield return new WaitForSeconds(delay);
                }
            }
        }
        // 全Cubeが生成されたらスケールのループ処理開始
        StartCoroutine(ScaleLoop());
    }

    IEnumerator ScaleLoop()
    {
        while (true)
        {
            // 1. 逆順で半分に縮小
            for (int i = generatedCubes.Count - 1; i >= 0; i--)
            {
                if (generatedCubes[i] != null)
                    generatedCubes[i].transform.localScale = Vector3.one * 0.5f;

                yield return new WaitForSeconds(delay);
            }

            // 少し待つ（お好み）
            yield return new WaitForSeconds(0.5f);

            // 2. 順番に元に戻す
            for (int i = 0; i < generatedCubes.Count; i++)
            {
                if (generatedCubes[i] != null)
                    generatedCubes[i].transform.localScale = Vector3.one;

                yield return new WaitForSeconds(delay);
            }

            yield return new WaitForSeconds(0.5f);
        }
    }
}
