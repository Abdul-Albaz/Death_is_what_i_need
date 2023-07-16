using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField]int enemyHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void TakeDamage(int damage) {

        if (enemyHealth <= 0)
        {
            Die();
        }
        else { enemyHealth -= damage; }
        
        Debug.Log("EnemyHealth : " + enemyHealth);
        
    }

    public void Die()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
    }
}
