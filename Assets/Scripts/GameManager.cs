using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Game")]
    public Transform playerTransform;
    public Ball ballPrefab;
    public List<Ball> ballsActive;

    public int currentHealth;

    public int destroyedBricks;
    public int bricksCount;
    
    public int ballActiveCount;
    public float totalSpeed;

    public float ballSpeed;

    public GameObject[] boosterPrefabs;

    [SerializeField] private GameObject[] healthSprites; // Массив для хранения спрайтов сердечек
    [SerializeField] private Sprite inactiveHeartSprite; // Спрайт для неактивного сердца
    public TextMeshProUGUI bricksText; // Изменено на TextMeshProUGUI

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("One more GameManager by name: " + gameObject.name);
        }
    }

    private void Start()
    {
        SpawnBall();
    }

    public void SpawnBall()
    {
        Ball ballSpawned = Instantiate(ballPrefab);
        ballSpawned.gameObject.transform.position = new Vector3(0f, -18f, 0f);
        playerTransform.GetComponent<PlatformMovement>().ballStart = ballSpawned;
        ballsActive.Add(ballSpawned);

        playerTransform.GetComponent<PlatformMovement>().movedYet = false;
        playerTransform.GetComponent<PlatformMovement>().mouseWasDown = false;
        playerTransform.GetComponent<PlatformMovement>().deltaMovement = 0;
    }

    public void TakeHealth(int count)
    {
        currentHealth -= count;
        UpdateHealthSprites();
        SoundsBaseCollection.Instance.damageSound.Play();
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Death();
        }
        else
        {
            SpawnBall();
        }
    }

    private void UpdateHealthSprites()
    {
        for (int i = 0; i < healthSprites.Length; i++)
        {
            if (i < currentHealth)
            {
                healthSprites[i].SetActive(true);
            }
            else
            {
                healthSprites[i].SetActive(true);
                healthSprites[i].GetComponent<Image>().sprite = inactiveHeartSprite; // Неактивное сердце
            }
        }
    }

    public void Death()
    {
        UIManager.Instance.LoseWindow.SetActive(true);
        SoundsBaseCollection.Instance.loseSound.Play();
    }

    public async void Win()
    {
        foreach (var ball in ballsActive)
        {
            ball.gameObject.SetActive(false);
        }
        
        await UniTask.Delay(TimeSpan.FromSeconds(1f));
        
        UIManager.Instance.WinWindow.SetActive(true);
        SoundsBaseCollection.Instance.soundtrack.Pause();
        SoundsBaseCollection.Instance.winSound.Play();
    }
}