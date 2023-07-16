using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatSystem : MonoBehaviour
{
    public int playerHealth;
    Animator anim;
    public Transform effectPoint;
    public LayerMask enemyLayer;
    public int attackRange;
    [SerializeField]int attackDamage = 10;
    [SerializeField]int parryDamage = 10;
    PlayerMovement playermovement;
    GameObject Enemy;
    

    // Start is called before the first frame update
    void Start()
    {
        
        playermovement = gameObject.GetComponent<PlayerMovement>();
        anim = gameObject.GetComponent<Animator>();
        Enemy = GameObject.FindGameObjectWithTag("Enemy");
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
                if (enemy.GetComponent<EnemyBehaviour>().enemyHealth < 500)
                {
                    parryDamage = 500;
                }
                playerHealth -= attackDamage;
                Debug.Log("Self damage player health : "+playerHealth);
            }
            else if (GameManger.currentGameMode == GameManger.gameMode.normal)
            {
                parryDamage = 0;
                enemy.GetComponent<EnemyBehaviour>().TakeDamage(attackDamage);
                attackDamage = 500;
                Debug.Log("Enemy damage");
            }
            
        }
        
    }

    void Parry() {
        if (Enemy.GetComponent<EnemyBehaviour>().isAttacking)
        {
            Enemy.GetComponent<EnemyBehaviour>().TakeDamage(parryDamage);

            anim.SetTrigger("Parry");
        }
        else
        {
            anim.SetTrigger("Parry");
        }
        

    }



}
