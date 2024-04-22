using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float startTime = 5f;
    [SerializeField] private TextMeshProUGUI timer;
    [SerializeField] private GameObject panel;

    private float currentTime;
    private Enemy enemy;
    private bool playerInputBlocked;

    public void Start()
    {
        currentTime = startTime;
        timer.text = currentTime.ToString();
        playerInputBlocked = false;
        enemy = FindObjectOfType<Enemy>().GetComponent<Enemy>();
    }

    public void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            timer.text = Mathf.Round(currentTime).ToString();
            MovePlayer();
        }
        else
        {
            playerInputBlocked = true;
            StartCoroutine(MoveEnemy());
        }        
    }
    
    public void MovePlayer()
    {
        if (playerInputBlocked == false)
        {
            panel.SetActive(true);            
        }
        else
        {
            panel.SetActive(false);
        }
    }
   
    public IEnumerator MoveEnemy()
    {
        if (playerInputBlocked == true)
        {
            currentTime = startTime;
            panel.SetActive(false);            

            yield return new WaitForSeconds(3f);
            enemy.GenerateRandomAttack();

            playerInputBlocked = false;
            currentTime = startTime;
            yield break;
        }
    }

    public void ResetTimerAndMoveEnemy()
    {
        currentTime = startTime;
        panel.SetActive(false);
        playerInputBlocked = true;
        StartCoroutine(MoveEnemy());
    }
}