using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatSystem : MonoBehaviour
{
    int playerHealth;
    Animator anim;
    public Transform effectPoint;
    public LayerMask enemyLayer;
    public int attackRange;
    [SerializeField]int attackDamage = 10;
    PlayerMovement playermovement;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = gameObject.GetComponent<PlayerBehaviour>().health;
        playermovement = gameObject.GetComponent<PlayerMovement>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    
        if(Input.GetKey(KeyCode.E) && !playermovement.isAttacking){

            Attack();
        }

        if (Input.GetKey(KeyCode.Q) && !playermovement.isParrying)
        {

            Parry();
        }
    }

    void Attack() {
        anim.SetTrigger("Attack");
        
        if (playerHealth <= 200)
        {
            GameManger.currentGameMode = GameManger.gameMode.normal;
        }
        //anim.SetTrigger("attack");

        Collider2D[] hitPoints = Physics2D.OverlapCircleAll(effectPoint.position, attackRange, enemyLayer);
        foreach (Collider2D enemy in hitPoints)
        {
            Debug.Log("hit : "+ enemy.name);
            if (GameManger.currentGameMode == GameManger.gameMode.reverse)
            {
                playerHealth -= attackDamage;
                Debug.Log("Self damage");
            }
            else if (GameManger.currentGameMode == GameManger.gameMode.normal)
            {
                enemy.GetComponent<EnemyBehaviour>().TakeDamage(attackDamage);
                Debug.Log("Enemy damage");
            }
            
        }
        
    }

    void Parry() {

        anim.SetTrigger("Parry");

    }



}
