using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstamtiateScript : MonoBehaviour
{
    public GameObject obj1; //Šï”—p
    public GameObject obj2; //‹ô”—p

    // Start is called before the first frame update
    void Start()
    {
        for (int k = 0; k < 9; k++)
        {
            for (int j = 0; j < 9; j++)
            {
                for (int i = 0; i < 9; i++)
                {
                    if ((i + k + j) % 2 == 0)
                    {
                        Instantiate(obj1, new Vector3(i * 1.0f, k * 1.0f, j * 1.0f), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(obj2, new Vector3(i * 1.0f, k * 1.0f, j * 1.0f), Quaternion.identity);
                    }
                }
                }
            }
        }
        
    }


