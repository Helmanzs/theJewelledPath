using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class SpellCooldown : MonoBehaviour
{
    [SerializeField] protected Image imageCooldown;
    [SerializeField] protected TMP_Text textCooldown;
    [SerializeField] protected float cooldownTime = 10f;

    private bool isCooldown = false;
    protected bool IsCooldown => isCooldown;

    private float cooldownTimer = 0f;

    private void Start()
    {
        textCooldown.gameObject.SetActive(false);
        imageCooldown.fillAmount = 0.0f;
    }
    private void FixedUpdate()
    {
        if (isCooldown)
        {
            ApplyCooldown();
        }
    }
    protected void PutOnCooldown()
    {
        isCooldown = true;
        cooldownTimer = cooldownTime;
    }
    private void ApplyCooldown()
    {
        textCooldown.gameObject.SetActive(true);
        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer <= 0.0f)
        {
            isCooldown = false;
            textCooldown.gameObject.SetActive(false);
            imageCooldown.fillAmount = 0.0f;
        }
        else
        {
            textCooldown.text = Mathf.RoundToInt(cooldownTimer).ToString();
            imageCooldown.fillAmount = cooldownTimer / cooldownTime;
        }
    }

    public abstract void UseSpell();
}
