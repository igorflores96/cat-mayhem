using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class win_conditions : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private GameObject catObject;
    public GameObject[] brokenObjectsInScene;


    [Header("Canvas Settings")]
    public TextMeshProUGUI caosCountText;
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

        caosCountText.text = "Barra de caos em: ";

        if (catObject.GetComponent<cat_colissions>().isCatch)
        {
            SceneManager.LoadScene((int)ScenesNames.loseScene);
        }
        else if(caosCount == brokenObjectsInScene.Length)
        {
            SceneManager.LoadScene((int)ScenesNames.winScene);
        }


        for (int i = 0; i < brokenObjectsInScene.Length; i++)
        {
            if (brokenObjectsInScene[i].GetComponent<brekable_objects>().IsBrokenStatus() && objectCaosCount[i] == false)
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

}
