using System.Collections;
using TMPro;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    public float missionDuration = 300.0f;
    private bool missionCompleted = false;
    private float timer;
    public int stressPoint;
    public Color Red; // Define the red color here
    public TMP_Text timerText;
    public AudioSource audioSource;

    //void Start()
    //{
    //    MissionStart();
    //}

    void MissionStart()
    {
        timer = missionDuration;
        StartCoroutine(MissionCountdown());
        StartCoroutine(ChangeTextColorAndPlayAudio());
    }

    void MissionComplete()
    {
        Debug.Log("Mission Completed!");
    }

    IEnumerator MissionCountdown()
    {
        while (timer > 0 && !missionCompleted)
        {
            yield return new WaitForSeconds(1.0f);
            timer--;

            if (timerText != null)
            {
                timerText.text = timer.ToString();
            }

            // Check if timer is under 30 seconds
            if (timer <= 30)
            {
                // Beep every second
                if (audioSource != null)
                {
                    audioSource.Play();
                }

                // Change color to red every second
                if (timerText != null)
                {
                    timerText.color = Red;
                }
            }

            if (missionCompleted)
            {
                MissionComplete();
                yield break;
            }
        }

        MissionComplete();
    }

    IEnumerator ChangeTextColorAndPlayAudio()
    {
        float elapsedTime = 0f;

        while (timer > 0 && !missionCompleted)
        {
            elapsedTime += Time.deltaTime;

            // Change color to red every second when the timer is under 30 seconds
            if (timer <= stressPoint && elapsedTime >= 1.0f)
            {
                if (timerText != null)
                {
                    timerText.color = Red;
                }

                if (audioSource != null)
                {
                    audioSource.Play();
                }

                elapsedTime = 0f; // Reset the elapsed time
            }

            // Wait for the next frame
            yield return null;
        }
    }

    public void CompleteMission()
    {
        missionCompleted = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered by: " + other.name);

        if (other.CompareTag("Player")) // Change "Player" to the tag of the object you want to trigger the mission
        {
            MissionStart();
        }
    }
}
