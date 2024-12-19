using UnityEngine;

public class TriggerPassthrough : MonoBehaviour
{
    public PassthroughController passthroughController; // Referência ao controlador de passthrough
    public float delayBeforeTransition = 20f; // Tempo antes de ativar o passthrough

    private bool isActivated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!isActivated && other.CompareTag("Player"))
        {
            isActivated = true;
            Invoke("ActivatePassthrough", delayBeforeTransition);
        }
    }

    private void ActivatePassthrough()
    {
        if (passthroughController != null)
        {
            passthroughController.EnablePassthrough();
        }
    }
}
