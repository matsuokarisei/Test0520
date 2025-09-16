using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeimenBW2 : MonoBehaviour
{
    public GameObject cubePrefab;

    [Header("ê∂ê¨Ç∑ÇÈÉuÉçÉbÉNÇÃêî")]
    [Range(1, 50)] public int Xcount = 20;
    [Range(1, 30)] public int Ycount = 10;
    [Range(0.01f, 1f)] public float delay = 0.05f;
    private float space = 1.0f;

    public List<Color> cubeColor = new List<Color> { Color.white, Color.black };

    private List<GameObject> generatedCube = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        GenerateA();
        StartCoroutine(Scaleroop());
    }

    void GenerateA()
    {
        int colorCount = cubeColor.Count;

        for (int x = 0; x < Xcount; x++)
        {
            if (x % 2 == 0)
            {
                for ( int y = 0; y < Ycount; y++)
                {
                    GenerateB(x, y, colorCount);
                }
            }
            else
            {
                for (int y = Ycount - 1; y >= 0; y--)
                {
                    GenerateB(x, y, colorCount);
                }
            }
        }
    }

    IEnumerator Scaleroop()
    {
        while(true)
        {
            for (int i = 0; i < generatedCube.Count; i++)
            {
                generatedCube[i].transform.localScale = Vector3.one * 0.5f;

                yield return new WaitForSeconds(delay);
            }
            for (int i = generatedCube.Count - 1; i >= 0; i--)
            {
                generatedCube[i].transform.localScale = Vector3.one; 

                yield return new WaitForSeconds(delay);
            }
        }
    }

    void GenerateB(int x,int y,int colorCount)
    {
        Vector3 pos = new Vector3(x * space, y * space);

        GameObject cube = Instantiate(cubePrefab, pos, Quaternion.identity, this.transform);

        int linearIndex = x * Ycount + (x % 2 == 0 ? y : (Ycount - 1 - y));
        int colorIndex = linearIndex % colorCount;

        cube.GetComponent<Renderer>().material.color = cubeColor[colorIndex];

        generatedCube.Add(cube);
    }
}
