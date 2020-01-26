using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level2GameManager : MonoBehaviour
{
    private Image imgCross;

    private void Start()
    {
        imgCross = GameObject.Find("轉場效果").GetComponent<Image>();
        imgCross.color += new Color(0, 0, 0, 1); //透明度範圍為 0~1

        StartCoroutine(EnterLevel()); //載入關卡時執行淡入效果
    }

    private IEnumerator EnterLevel() //淡入效果
    {
        for (int i = 0; i < 50; i++)
        {
            imgCross.color -= new Color(0, 0, 0, 0.02f);
            yield return new WaitForSeconds(0.05f);
        }

    }

}
