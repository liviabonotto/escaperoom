using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public float countdownTime = 600f; 
    public TextMeshPro countdownText; 
    public AudioSource voiceClip;  
    private bool isCountingDown = false;

    void Start()
    {
        FindObjectOfType<AudioManager>().Play("tema");
        StartCoroutine(TriggerEventWithDelay(CountdownEvent.Narracao1, 3f));
    }

    public void StartCountdown()
    {
        if (!isCountingDown)
        {
            isCountingDown = true;
            StartCoroutine(CountdownCoroutine());
        }
    }

    IEnumerator TriggerEventWithDelay(CountdownEvent countdownEvent, float delay)
    {
        yield return new WaitForSeconds(delay);
        TriggerEvent(countdownEvent);
    }

    private IEnumerator QuitGame()
{
    yield return new WaitForSeconds(2f);
    
    Application.Quit();

    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #endif
}


    public enum CountdownEvent
    {
        Narracao1,
        Relogio,
        FimCountdown,
        Countdown,
        PersonagemLevanta
    }

    private IEnumerator CountdownCoroutine()
    {
        float remainingTime = countdownTime;

        while (remainingTime > 0)
        {
            if (countdownText != null)
            {
                countdownText.text = FormatTime(remainingTime);
            }

            yield return new WaitForSeconds(1f);

            remainingTime--;
        }

        CountdownFinished();
    }

    private void TriggerEvent(CountdownEvent countdownEvent)
    {
        switch (countdownEvent)
        {
            case CountdownEvent.Narracao1:
                FindObjectOfType<AudioManager>().Play("narracao-1");
                StartCoroutine(TriggerEventWithDelay(CountdownEvent.Countdown, 6f));
                StartCoroutine(TriggerEventWithDelay(CountdownEvent.Relogio, 5f));
                break;

            case CountdownEvent.Countdown:
                StartCountdown();
                break;

            case CountdownEvent.Relogio:
                FindObjectOfType<AudioManager>().Play("relogio");
                StartCoroutine(TriggerEventWithDelay(CountdownEvent.PersonagemLevanta, 10f));
                break;

            case CountdownEvent.PersonagemLevanta:
                FindObjectOfType<AudioManager>().Play("personagem-levanta");
                break;


            case CountdownEvent.FimCountdown:
                Debug.Log("Evento final executado.");
                break;
        }
    }

    private void CountdownFinished()
{
    Debug.Log("Countdown terminado!");

    if (countdownText != null)
    {
        countdownText.text = "Game Over";
    }

    StartCoroutine(QuitGame());
}


    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        return $"{minutes:00}:{seconds:00}";
    }
}