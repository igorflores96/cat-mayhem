using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreamButtonCooldown : MonoBehaviour
{

    [SerializeField] private FloatReference cooldownStunTimeMax;

    private bool countCooldown;
    private float cooldownStunTime;

    public Image iconImage;

    private void Awake()
    {
        countCooldown = true;
        cooldownStunTime = 0f;//cooldownStunTimeMax.Value;
    }

    // Update is called once per frame
    void Update()
    {
        if(countCooldown)
        {
            cooldownStunTime -= Time.deltaTime;

            if(cooldownStunTime <= 0f)
            {
                countCooldown = false;
                iconImage.fillAmount = 0f;
            }
            else
            {
                iconImage.fillAmount = cooldownStunTime / cooldownStunTimeMax.Value;
            }
        }
    }


    public void CanCountStun(FloatVariable stunCooldownTime)
    {
        cooldownStunTime = stunCooldownTime.Value;
        countCooldown = true;
    }
}
