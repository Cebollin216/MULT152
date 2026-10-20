using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TargetUI : MonoBehaviour
{
    [Header("Setup")]
    public PlayerTargeting playerTargeting;
    public GameObject targetPanel;

    public TMP_Text targetNameText;
    public TMP_Text targetHealthText;
    public Slider targetHealthBar;

    void UpdateTargetUI()
    {
        if (playerTargeting.CurrentTarget == null)
        {
            targetPanel.SetActive(false);
            return;
        }

        targetPanel.SetActive(true);

        EnemyTarget target = playerTargeting.CurrentTarget;
        EnemyHealth health = target.GetComponent<EnemyHealth>();
        targetNameText.text = target.name;
        targetHealthBar.value = health;
        targetHealthText.tag = targetHealthBar.health + " / " + targetHealth.maxHealth;
    }

}