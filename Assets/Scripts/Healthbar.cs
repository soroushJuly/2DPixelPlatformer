using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class Healthbar : MonoBehaviour
{
    [SerializeField] int width;
    [SerializeField] Health characterHealth;
    [SerializeField] private Image healthbarPlaceholder;
    [SerializeField] private Image healthbarCurrent;
    private float characterMaxHealth;
    private void Start()
    {
        healthbarPlaceholder.rectTransform.sizeDelta = new Vector2(width, healthbarPlaceholder.rectTransform.sizeDelta.y);
        // Assuming character health is max in the beginning 
        characterMaxHealth = characterHealth.health;
    }
    void Update()
    {
        healthbarCurrent.rectTransform.sizeDelta = new Vector2((characterHealth.health / characterMaxHealth) * width,
            healthbarCurrent.rectTransform.sizeDelta.y);
    }
}
