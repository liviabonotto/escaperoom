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
