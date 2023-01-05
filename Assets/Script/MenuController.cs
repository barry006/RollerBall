using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuController : MonoBehaviour
{
    public GameObject endPanel1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoseGame()
    {
        endPanel1.SetActive(true);
        endPanel1.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "GameOver...";
    }
    public void WinGame()
    {
        endPanel1.SetActive(true);
        endPanel1.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "you win!";
    }
}
