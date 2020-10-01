using UnityEngine;

namespace RPG.Combat
{
    public class Health : MonoBehaviour
    {
        [SerializeField] float currentHealth;
        [SerializeField] float maxHealth = 100;
        private bool isAlive = true;

        public bool IsDead()
        {
            return !isAlive;
        }

        private void Start()
        {
            currentHealth = maxHealth;
        }

        public void TakeDamage(float damage)
        {
            currentHealth = Mathf.Max(currentHealth - damage, 0);
            print("HP: " + currentHealth + "/" + maxHealth);
            if (currentHealth == 0 && isAlive)
            {
                GetComponent<Animator>().SetTrigger("die");
                isAlive = false;
            }

        }
    }
}