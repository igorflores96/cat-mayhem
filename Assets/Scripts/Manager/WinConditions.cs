using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class WinConditions : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private GameObject catObject;
    public GameObject[] brokenObjectsInScene;


    [Header("Canvas Settings")]
    //public TextMeshProUGUI caosCountText;
    public Image caosBar;

    private float caosCount;
    private bool[] objectCaosCount;
    private float lerpSpeedBar;

    private void Start()
    {
        caosCount = 0;
        objectCaosCount = new bool[brokenObjectsInScene.Length];
    }

    private void Update()
    {

        lerpSpeedBar = 3f * Time.deltaTime;

        //caosCountText.text = "Caos Count";

        if (catObject.GetComponent<CatColissions>().isCatch)
        {
            SceneManager.LoadScene("loseScreen");
        }
        else if(caosCount == brokenObjectsInScene.Length)
        {
            Invoke("ChangeScene", 0.2f); //Para fazer o som sair corretamente do último objeto quebrado.
        }


        for (int i = 0; i < brokenObjectsInScene.Length; i++)
        {
            if (brokenObjectsInScene[i].GetComponent<BrekableObjects>().IsBrokenStatus() && objectCaosCount[i] == false)
            {
                objectCaosCount[i] = true;
                caosCount++;
            }
        }
        CaosBarFiller();
    }

    void CaosBarFiller()
    {
        caosBar.fillAmount = Mathf.Lerp(caosBar.fillAmount, caosCount / brokenObjectsInScene.Length, lerpSpeedBar);
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene("WinScreen");
    }

}
