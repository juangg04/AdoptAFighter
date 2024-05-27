using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private FloatSO animalDef;

    [SerializeField] private FloatSO animalHealth;

    public float maxHealth = 100f;
    public int currentHealth;
    public Image health;

    private void Start()
    {
        animalHealth.Value = maxHealth;
        UpdateHearts();
    }

    public void TakeDamage(int damage)
    {
        animalHealth.Value -= (damage * animalDef.Value);
        if (animalHealth.Value <= 0f)
        {
            animalHealth.Value = 0;
            gameObject.GetComponent<MaquinaDeEstados>().ActivarEstado(gameObject.GetComponent<MaquinaDeEstados>().Muerto);
        }
        UpdateHearts();
    }

    public void Heal(int healAmount)
    {
        animalHealth.Value += healAmount;
        if (animalHealth.Value > maxHealth)
        {
            animalHealth.Value = maxHealth;
        }
        UpdateHearts();
    }

    private void UpdateHearts()
    {
        float fillPercentage = (float)animalHealth.Value / maxHealth;
            health.fillAmount = fillPercentage;

    }
}