using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Base HP: " + currentHealth);

        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("LoseScreen");
        }
    }
}
