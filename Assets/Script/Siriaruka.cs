using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Siriaruka: MonoBehaviour
{
    //void Start()
   // {
   // Debug.Log("Start");
   //     Invoke("ShowLog", 5f); // 5•bŒã‚É "ShowLog" ‚ğŒÄ‚Ño‚·
   // }

    //IEnumerator ShowLogAfterDelay()
    //{
    //  yield return new WaitForSeconds(5f); // 5•b‘Ò‚Â
    //Debug.Log("5‚Ñ‚å‚¤‚²");
    //}
  

  // void ShowLog()
   // {
    //   Debug.Log("5‚Ñ‚å‚¤‚²‚É•\¦‚³‚ê‚Ü‚µ‚½I");
    //}

    
    
    
    public string playerName = "roto";
    public int level = 41;

    [Header("HP‚Ìİ’è€–Ú"),SerializeField,Range(1.0f,100.0f)]
    public int maxHp = 100;
    public int hp = 8;

    [Header("MP‚Ìİ’è€–Ú")]
    public int maxMp = 108;
    public int mp = 87;

    [Header("‹­‚³‚Ìİ’è€–Ú")]
    public int atk = 96;
    public int def = 43;
    public int speed = 74;

}


