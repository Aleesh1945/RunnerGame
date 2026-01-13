using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Settings")]
    public int health = 3; // Количество жизней

    [Header("UI Elements")]
    public HealthBarController healthBarController; // Ссылка на контроллер UI сердец

    public delegate void OnPlayerDeath();
    public event OnPlayerDeath onPlayerDeath; // Событие для смерти игрока

    void Start()
    {
        // Проверяем, что ссылка на контроллер UI задана
        if (healthBarController != null)
            healthBarController.UpdateHeartsHUD(health);
        else
            Debug.LogError("HealthBarController не назначен в инспекторе!");
    }

    public void TakeDamage()
    {
        if (health > 0)
        {
            health--;
            if (healthBarController != null)
                healthBarController.UpdateHeartsHUD(health);

            if (health <= 0)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        onPlayerDeath?.Invoke();
        Debug.Log("Player has died!");
    }

    public int GetHealth()
    {
        return health;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            TakeDamage();
        }
    }
}