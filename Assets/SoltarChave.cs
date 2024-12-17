using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SoltarChave : MonoBehaviour
{
    private FixedJoint fixedJoint;

    private void Start()
    {
        // Obtém referência ao Fixed Joint
        fixedJoint = GetComponent<FixedJoint>();
    }

    private void OnEnable()
    {
        // Adiciona o evento de interação
        GetComponent<XRGrabInteractable>().selectEntered.AddListener(OnChavePega);
    }

    private void OnDisable()
    {
        GetComponent<XRGrabInteractable>().selectEntered.RemoveListener(OnChavePega);
    }

    private void OnChavePega(SelectEnterEventArgs args)
    {
        // Destrói o Fixed Joint ao pegar a chave
        if (fixedJoint != null)
        {
            Destroy(fixedJoint);
        }
    }
}
