using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public float countdownTime = 600f; // 10 minutos em segundos
    public Text countdownText; // Texto UI para exibir o tempo (opcional)
    public AudioSource voiceClip; // Referência ao áudio (opcional)
    
    private bool isCountingDown = false;

    void Start()
    {
        StartCountdown();
    }

    public void StartCountdown()
    {
        if (!isCountingDown)
        {
            isCountingDown = true;
            StartCoroutine(CountdownCoroutine());
        }
    }

    private IEnumerator CountdownCoroutine()
    {
        float remainingTime = countdownTime;

        while (remainingTime > 0)
        {
            // Atualiza o texto, se aplicável
            if (countdownText != null)
            {
                countdownText.text = FormatTime(remainingTime);
            }

            // Eventos personalizados (exemplo: voz em determinados minutos)
            if (Mathf.Approximately(remainingTime, 595f)) // Faltam 5 minutos
            {
                TriggerEvent("Faltam 5 minutos!", 0);
            }
            else if (Mathf.Approximately(remainingTime, 60f)) // Faltam 1 minuto
            {
                TriggerEvent("Falta 1 minuto!", 2);
            }

            // Aguarda 1 segundo
            yield return new WaitForSeconds(1f);

            // Decrementa o tempo restante
            remainingTime--;
        }

        // Countdown terminou
        CountdownFinished();
    }

    private void TriggerEvent(string message, int newEvent)
    {
        var _event = newEvent;
        if (_event == 0)
        {
            if (voiceClip != null && !voiceClip.isPlaying)
            {
                voiceClip.Play();
            }
        }
    }

    private void CountdownFinished()
    {
        Debug.Log("Countdown terminado!");
        if (countdownText != null)
        {
            countdownText.text = "Tempo Esgotado!";
        }

        // Adicione lógica adicional aqui, como iniciar outro evento
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        return $"{minutes:00}:{seconds:00}";
    }
}