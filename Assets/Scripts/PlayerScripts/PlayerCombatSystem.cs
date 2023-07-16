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
    private int parryDamage;
    PlayerMovement playermovement;
    GameObject Enemy;
    

    // Start is called before the first frame update
    void Start()
    {
        parryDamage = 200;
        playermovement = gameObject.GetComponent<PlayerMovement>();
        anim = gameObject.GetComponent<Animator>();
        Enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Game Mode up" + GameManger.currentGameMode);

        if (playerHealth <= 200)
        {
            
            GameManger.currentGameMode = GameManger.gameMode.normal;
        }
        if(Input.GetKeyDown(KeyCode.E) && !playermovement.isAttacking){


            Attack();
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {

            Enemy.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }



        if (Input.GetKeyDown(KeyCode.Q) && !playermovement.isParrying)
        {

            Parry();
        }

        else if (Input.GetKeyUp(KeyCode.Q))
        {

            Enemy.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
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
                    parryDamage = 200;
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

        if (GameManger.currentGameMode == GameManger.gameMode.reverse)
        {
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
        else
        {
            Enemy.GetComponent<EnemyBehaviour>().TakeDamage(0);
            anim.SetTrigger("Parry");
            Debug.Log( "Game Mode "+GameManger.currentGameMode);
        }
       
        

    }



}
