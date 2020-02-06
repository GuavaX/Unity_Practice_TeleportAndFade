using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class DeliverDoor : MonoBehaviour
{
    private Image imgCross;

    private void Start()
    {
        imgCross = GameObject.Find("轉場效果").GetComponent<Image>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //print(other.name);
        if (other.name == "傳送區域")
        {
            StartCoroutine(NextLevel());
        }
    }

    private IEnumerator NextLevel()
    {
        for (int i = 0; i < 50; i++)
        {
            imgCross.color += new Color(0, 0, 0, 0.02f);
            yield return new WaitForSeconds(0.05f);
        }

        //yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("第二關");
        
    }

}
