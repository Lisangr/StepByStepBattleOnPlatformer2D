using UnityEngine;

public class Player : MonoBehaviour
{
    public int currentHP;
    public int MaxHP;
    public int damage = 50;
    public Animator animator;
    private Damage damageScript;

    public void Start()
    { damageScript = FindObjectOfType<Damage>().GetComponent<Damage>();
    }

    public void OnAttackFirstPressed()
    {
        
        Attack();
        animator.SetTrigger("Attack1");

    }
    public void OnAttackSecondPressed()
    {
        
        Attack();
        animator.SetTrigger("Attack2");

    }
    public void OnAttackThirdPressed()
    {
        
        Attack();
        animator.SetTrigger("Attack3");

    }
    public void OnAttackFourthPressed()
    {
        
        Attack();
        animator.SetTrigger("Block");
    }

    public void Attack()
    {
        damageScript.TakeDamageForEnemy(damage);
        Timer timer = FindObjectOfType<Timer>().GetComponent<Timer>();
        timer.ResetTimerAndMoveEnemy();
    }
}