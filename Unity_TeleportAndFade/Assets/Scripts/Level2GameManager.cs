using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level2GameManager : MonoBehaviour
{
    private Image imgCross;
    private Text textScores;
    private GameObject warning;
    private GameObject centerText;
    private GameObject[] Bandits;
    private bool gotFirstScore;
    private bool gameOver;

    public GameObject bornBandits;    
    public GameObject[] bornPoint;

    private int gotThings = 0;

    private void Start()
    {
        imgCross = GameObject.Find("轉場效果").GetComponent<Image>();
        imgCross.color += new Color(0, 0, 0, 1); //透明度範圍為 0~1

        StartCoroutine(EnterLevel()); //載入關卡時執行淡入效果

        textScores = GameObject.Find("分數").GetComponent<Text>();
        centerText = GameObject.Find("中央字幕");
        warning = GameObject.Find("警告標語");
        warning.SetActive(false);
        Bandits = GameObject.FindGameObjectsWithTag("Bandit");
        for (int i = 0; i < Bandits.Length; i++) Bandits[i].SetActive(false);

    }

    private void Update()
    {
        textScores.text = gotThings+"/7";
        if ((gotThings == 7)&&(gameOver==false))
        {
            gameOver = true;
            warning.SetActive(false);
            centerText.GetComponent<Text>().text = "蒐集完成！！";
            StartCoroutine(SetCenterText());
        }

        if (gameOver == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("第一關");
            }
        }
    }

    private IEnumerator SetCenterText()
    {       
        yield return new WaitForSeconds(1);
        centerText.GetComponent<Text>().text = "按下空白鍵\n回到第一關";
    }

    private IEnumerator EnterLevel() //淡入效果
    {
        for (int i = 0; i < 50; i++)
        {
            imgCross.color -= new Color(0, 0, 0, 0.02f);
            yield return new WaitForSeconds(0.05f);
        }

    }

    public void GetScore()
    {
        if (gotFirstScore == false)
        {
            for (int i = 0; i < Bandits.Length; i++)
            {
                Bandits[i].SetActive(true);
            }
            gotFirstScore = true;
        }

        warning.SetActive(true);
        StartCoroutine(InvokeWaring());
        gotThings += 1;

        BornBandit();
    }

    public void BornBandit()
    {
        int i = Random.Range(0, 6);
        Instantiate(bornBandits, bornPoint[i].transform.position, Quaternion.identity);        
    }

    IEnumerator InvokeWaring()
    {
        yield return new WaitForSeconds(1);
        warning.SetActive(false);
    }



}
