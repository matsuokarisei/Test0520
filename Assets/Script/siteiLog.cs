using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class siteiLog : MonoBehaviour
{
    [SerializeField,Range(1.0f,9999.0f)]
    int repeatCount = 1; // 実行回数を指定

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
   //void Update()
    //{
    //    for (int i = 0; i < repeatCount; i++)
    //    {
    //        Debug.Log($"現在のループ回数: {i + 1}");
    //    }
    //}
}
