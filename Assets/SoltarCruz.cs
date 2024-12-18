// using UnityEngine;
// using UnityEngine.XR.Interaction.Toolkit;

// public class SoltarCruz : MonoBehaviour
// {
//     private Rigidbody rb;

//     private void Start()
//     {
//         rb = GetComponent<Rigidbody>();
//     }

//     private void OnEnable()
//     {
//         // Listener para liberar a cruz quando for pega
//         GetComponent<XRGrabInteractable>().selectEntered.AddListener(OnCruzPega);
//     }

//     private void OnDisable()
//     {
//         GetComponent<XRGrabInteractable>().selectEntered.RemoveListener(OnCruzPega);
//     }

//     private void OnCruzPega(SelectEnterEventArgs args)
//     {
//         // Ativa a física ao pegar a cruz
//         rb.isKinematic = false;
//     }
// }


using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SoltarCruz : MonoBehaviour
{
    private FixedJoint fixedJoint;
    public XRGrabInteractable chaveGrabInteractable; // Referência ao XRGrabInteractable da chave

    private void Start()
    {
        // Obtém referência ao Fixed Joint
        fixedJoint = GetComponent<FixedJoint>();

        // Garante que a chave comece desativada
        if (chaveGrabInteractable != null)
        {
            chaveGrabInteractable.enabled = false;
        }
    }

    private void OnEnable()
    {
        // Adiciona o evento de interação
        GetComponent<XRGrabInteractable>().selectEntered.AddListener(OnCruzPega);
    }

    private void OnDisable()
    {
        GetComponent<XRGrabInteractable>().selectEntered.RemoveListener(OnCruzPega);
    }

    private void OnCruzPega(SelectEnterEventArgs args)
    {
        // Destrói o Fixed Joint ao pegar a cruz
        if (fixedJoint != null)
        {
            Destroy(fixedJoint);
        }

        // Ativa o XRGrabInteractable da chave
        if (chaveGrabInteractable != null)
        {
            chaveGrabInteractable.enabled = true;
            Debug.Log("Chave agora pode ser interagida!");
        }
    }
}
