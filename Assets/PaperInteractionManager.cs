using UnityEngine;
using UnityEngine.Video;

public class PaperInteractionManager : MonoBehaviour
{
    public AudioManager audioManager; // Referência ao AudioManager
    public string narrationClipName = "VozPapel"; // Nome do áudio de narração configurado no AudioManager
    public GameObject videoPlayerObject; // Referência ao GameObject com o Video Player
    public float delayForCredits = 30f; // Tempo de espera antes de iniciar o vídeo de créditos
    private bool isPaperPickedUp = false; // Controle para evitar múltiplas ativações

    // Método chamado quando o jogador pega o papel
    public void OnPaperPickedUp()
    {
        if (!isPaperPickedUp)
        {
            isPaperPickedUp = true;

            // Toca o áudio de narração via AudioManager
            if (audioManager != null)
            {
                audioManager.Play(narrationClipName);
                Debug.Log("Narração iniciada!");
            }
            else
            {
                Debug.LogWarning("AudioManager não configurado no Inspector!");
            }

            // Inicia a transição para os créditos após o tempo de delay
            Invoke("PlayCredits", delayForCredits);
        }
    }

    void PlayCredits()
    {
        if (videoPlayerObject != null)
        {
            videoPlayerObject.SetActive(true); // Ativa o GameObject do vídeo
            VideoPlayer videoPlayer = videoPlayerObject.GetComponent<VideoPlayer>();
            if (videoPlayer != null)
            {
                videoPlayer.Play(); // Reproduz o vídeo
                Debug.Log("Vídeo de créditos iniciado!");
            }
            else
            {
                Debug.LogWarning("Video Player não encontrado no GameObject!");
            }
        }
        else
        {
            Debug.LogWarning("Objeto do Video Player não está atribuído!");
        }
    }
}
