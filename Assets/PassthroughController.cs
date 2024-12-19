using UnityEngine;

public class PassthroughController : MonoBehaviour
{
    public GameObject virtualEnvironment; // O ambiente virtual a ser desativado

    public void EnablePassthrough()
    {
        if (virtualEnvironment != null)
        {
            virtualEnvironment.SetActive(false); // Esconde o ambiente virtual
        }

        Debug.Log("Passthrough ativado!");
    }

    public void DisablePassthrough()
    {
        if (virtualEnvironment != null)
        {
            virtualEnvironment.SetActive(true); // Restaura o ambiente virtual
        }

        Debug.Log("Passthrough desativado!");
    }
}
