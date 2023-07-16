using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public int enemyHealth;
    [SerializeField]float attackThreshold;
    [SerializeField] float followThreshold;
    float distance;
    [SerializeField] Transform player;
    [SerializeField] Transform startPostion;
    [SerializeField] private float offset;
    Rigidbody2D rb;
    Animator anim;
    [SerializeField] private float enimySpped;
    public bool isAttacking = false;
    Vector3 direction;
    [SerializeField] LayerMask playerMask;
    [SerializeField] Transform effectPoint;
    [SerializeField] float effectRadius;
    [SerializeField] int enemyHealing;
    public int enemyDamg;
    public bool isTakingDamge;
    bool[] healthLevel;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player =  GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
       
        distance = Vector2.Distance(transform.position, player.position);
        
        if (distance <= followThreshold)
        {
            Debug.Log("kshaa");
            
            //if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Monster_Attack_animation"))
            //{
                
            // }

            if (distance <= attackThreshold)
            {
                anim.SetBool("Attack", true);
                anim.SetBool("Walk", false);
                Invoke(nameof(attackAnimation),2f);

                if (isAttacking && !player.GetComponent<PlayerMovement>().isParrying && GameManger.currentGameMode == GameManger.gameMode.reverse && player.GetComponent<PlayerCombatSystem>().playerHealth <= 600)
                {      
                    if (Physics2D.OverlapCircle(new Vector2(effectPoint.position.x,effectPoint.position.y),effectRadius,playerMask))
                    {
                        player.GetComponent<PlayerCombatSystem>().playerHealth += enemyHealing;
                        
                    }
                }
                
                if (isAttacking  && GameManger.currentGameMode == GameManger.gameMode.normal)
                {
                    if (Physics2D.OverlapCircle(new Vector2(effectPoint.position.x, effectPoint.position.y), effectRadius, playerMask))
                    {
                        Debug.Log("emey is damging player");
                        player.GetComponent<PlayerCombatSystem>().playerHealth -= enemyDamg;
                        
                    }

                    if (player.GetComponent<PlayerCombatSystem>().playerHealth <= 0)
                    {

                        player.gameObject.SetActive(false);
                    }

                }

               

                //if (!isAttacking)
                //{
                //    this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                //}
            }
            else
            {   
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.position.x + offset, transform.position.y), Time.deltaTime * enimySpped);
                anim.SetBool("Attack", false);
                anim.SetBool("Walk", true);
            }
        }
        else
        {
            anim.SetBool("Attack", false);
            anim.SetBool("Walk", false);
        }
        

    }

    public void TakeDamage(int damage) {

        
        if (enemyHealth <= 0)
        {
            Debug.Log("Enemy Die");
            Die();

        }

        else {
            GetComponent<SpriteRenderer>().color = new Color32(251, 157, 157, 255);
            isTakingDamge = true;
            enemyHealth -= damage;
        }
        
        Debug.Log("EnemyHealth : " + enemyHealth);
        //this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

    public void Die()
    {
        Debug.Log("Enemy Die 2");
        gameObject.SetActive(false);
       // this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
    }

    public void attackAnimation()
    {
       
       anim.SetBool("Attack",false);
        CancelInvoke();
      
    }

    
}
