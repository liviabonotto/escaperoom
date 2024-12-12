using UnityEngine;

public class MenuTrack : MonoBehaviour
{
    private AudioManager audioManager;

    // Start é chamado no início da cena
    void Start()
    {
        // Obtém o AudioManager (certifique-se de que ele está na cena)
        audioManager = AudioManager.instance;

        if (audioManager != null)
        {
            // Toca a música do menu track
            audioManager.Play("menutrack");
        }
        else
        {
            Debug.LogWarning("AudioManager não encontrado!");
        }
    }

    // OnDestroy é chamado ao sair da cena
    void OnDestroy()
    {
        if (audioManager != null)
        {
            // Para a música do menu track
            audioManager.Stop("menutrack");
        }
    }
}
