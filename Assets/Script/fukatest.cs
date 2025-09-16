using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class fukatest : MonoBehaviour
{
    //[Header("Debug.Log"),SerializeField]
    //int repeatCount = 1; // 実行回数を指定
    //[Header("transform.position"), SerializeField]
    //int repeatCount2 = 1;
    //[Header("transform.localscale"), SerializeField]
    //int repeatCount3 = 1;
    //[Header("transform.localposition"), SerializeField]
    //int repeatCount4 = 1;
    //[Header("transform.localrotation"), SerializeField]
    //int repeatCount5 = 1;

    //[SerializeField]
    //int[] num = { 0,1,2,3,4 };

    [SerializeField]
    int number = 1;
    Transform _tr = null;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;

        _tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // for (int i = 0; i < num[0]; i++)
        //{
        //   Debug.Log($"現在のループ回数: {i + 1}");
        //}

        //for (int i = 0; i < num[1]; i++)
        //{
        //    transform.position = new Vector3(5, 5, 5);
        //}

        //for (int i = 0; i < num[2]; i++)
        //{
        //    transform.localScale = new Vector3(5, 5, 5);
        //}

        //for (int i = 0; i < num[3]; i++)
        //{
        //    transform.localPosition = new Vector3(5, 5, 5);
        //}

        //for (int i = 0; i < num[4]; i++)
        //{
        //    transform.localRotation = Quaternion.Euler(5, 5, 5);
        //}

        //switch (number)
        //{
        //    case 1:
        //        for (int i = 0; i < number; i++)
        //            {
        //               Debug.Log($"現在のループ回数: {i + 1}");
        //            }
        //            break;
        //    case 2:
        //        for (int i = 0; i < number; i++)
        //            {
        //                transform.position += new Vector3(5, 5, 5);
        //            }
        //            break;
        //    case 3:
        //        for (int i = 0; i < number; i++)
        //            {
        //                transform.localScale += new Vector3(5, 5, 5);
        //            }
        //            break;
        //    case 4:
        //        for (int i = 0; i < number; i++)
        //            {
        //                transform.localPosition += new Vector3(5, 5, 5);
        //            }
        //            break;
        //    case 5:
        //        for (int i = 0; i < number; i++)
        //            {
        //                transform.localRotation *= Quaternion.Euler(5, 5, 5);
        //            }
        //            break;
       // }
    }
}
