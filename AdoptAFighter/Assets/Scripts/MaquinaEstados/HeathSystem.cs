using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Image health;

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHearts();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            gameObject.GetComponent<MaquinaDeEstados>().ActivarEstado(gameObject.GetComponent<MaquinaDeEstados>().Muerto);
        }
        UpdateHearts();
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        UpdateHearts();
    }

    private void UpdateHearts()
    {
        float fillPercentage = (float)currentHealth / maxHealth;
            health.fillAmount = fillPercentage;

    }
}