using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParkingManager : MonoBehaviour
{
    public GameObject car;
    public GameObject parkingSpot;
    public GameObject panel;
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    public GameObject menuButton1;
    public GameObject menuButton2;
    public GameObject nextButton;
    public Text timeText;
    public Text winText;
    public Text chancesText;
    private Rigidbody rb;
    public AudioSource carCrash;
    public AudioSource carEngineSound;


    private int wheelsOnPlane;
    private int remainingChances;
    public int maxChances = 5;
    public float maxTimeLimit = 60f;
    private float elapsedTime = 1f;
    public float collisionThreshold = 0.5f;
    public int requiredWheels = 4;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        remainingChances = maxChances;
        UpdateChancesText();
        Time.timeScale = 1.0f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            float collisionSpeed = collision.relativeVelocity.magnitude;

            if(collisionSpeed >= collisionThreshold)
            {
                //if(!carCrash.isPlaying){
                    carCrash.Play();
                //}
                remainingChances--;
                UpdateChancesText();

                if (remainingChances <= 0)
                {
                    LoseGame();
                }
            }
        }
    }

    void FixedUpdate()
    {
        wheelsOnPlane = 0;

        BoxCollider[] boxColliders = GetComponentsInChildren<BoxCollider>();
        foreach (BoxCollider boxCollider in boxColliders)
        {
            Collider[] colliders = Physics.OverlapBox(boxCollider.bounds.center, boxCollider.bounds.extents, boxCollider.transform.rotation);
            foreach (Collider collider in colliders)
            {
                if (collider.CompareTag("Wheel"))
                {
                    wheelsOnPlane++;
                }
            }
        }

        if (wheelsOnPlane >= requiredWheels)
        {
            WinGame();
        }
    }

    private void LoseGame()
    {
        winText.text = "GAME OVER";
        Time.timeScale = 0f;
        carEngineSound.mute = true;
        carEngineSound.loop = false;
        carEngineSound.Stop();
        panel.SetActive(true);
        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);
        nextButton.SetActive(false);
        menuButton1.SetActive(false);
        menuButton2.SetActive(true);
    }

    private void WinGame()
    {
        winText.text = "YOU WIN";
        Time.timeScale = 0f;
        carEngineSound.mute = true;
        carEngineSound.Stop();
        panel.SetActive(true);
        if(remainingChances == 5){
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(true);
        } else if(remainingChances <= 4 && remainingChances >= 2 ){
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(false);
        }else if(remainingChances ==1 ){
            star1.SetActive(true);
            star2.SetActive(false);
            star3.SetActive(false);
        }
        
    }

    private void UpdateChancesText()
    {
        chancesText.text = remainingChances + "/" + maxChances;

        if (remainingChances == 0)
        {
            LoseGame();
        }
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        float remainingTime = maxTimeLimit - elapsedTime;
        string formattedTime = FormatTime(remainingTime);

        timeText.text = formattedTime;

        if (maxTimeLimit < elapsedTime)
        {
            LoseGame();
            timeText.text = "00:00";
        }
    }

    private string FormatTime(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60f);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60f);

        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
