// ÚLTIMA VERSÃO COM ERRO -> PRINTA APENAS O SLOT 4 COM ERRO


// using UnityEngine;
// using UnityEngine.XR.Interaction.Toolkit;

// public class SlotChecker : MonoBehaviour
// {
//     [SerializeField]
//     private int correctPaperID; // ID correto do papel para este slot
//     public int currentPaperID = -1; // ID do papel atualmente neste slot

//     private void OnTriggerStay(Collider other)
//     {
//         PaperID paper = other.GetComponent<PaperID>();
//         XRGrabInteractable interactable = other.GetComponent<XRGrabInteractable>();

//         // Verifica se é um papel e ele foi solto
//         if (paper != null && (interactable == null || !interactable.isSelected))
//         {
//             if (currentPaperID != paper.PaperIDValue) // Atualiza apenas se necessário
//             {
//                 currentPaperID = paper.PaperIDValue;
//                 Debug.Log($"Papel {currentPaperID} colocado no slot {name}");
//             }
//         }
//     }

//     private void OnTriggerExit(Collider other)
//     {
//         PaperID paper = other.GetComponent<PaperID>();
//         if (paper != null && currentPaperID == paper.PaperIDValue)
//         {
//             currentPaperID = -1; // Slot vazio
//             Debug.Log($"Papel {paper.PaperIDValue} removido do slot {name}");
//         }
//     }

//     public int CorrectPaperID => correctPaperID; // Getter para o GameManager
// }



// ÚLTIMA VERSÃO FUNCIONADO, MAS ELE TRIGGA SÓ DE ENCOSTAR NO SLOT 

using UnityEngine;

public class SlotChecker : MonoBehaviour
{
    [SerializeField]
    private int correctPaperID; // ID correto do papel para este slot
    public int currentPaperID = -1; // ID do papel atualmente neste slot
    private bool isPaperRegistered = false; // Flag para registrar apenas uma vez

    private void OnTriggerStay(Collider other)
    {
        PaperID paper = other.GetComponent<PaperID>();
        Rigidbody rb = other.GetComponent<Rigidbody>();

        // Verifica se é um papel e se ele está parado
        if (paper != null && rb != null && rb.velocity.magnitude < 0.01f && !isPaperRegistered)
        {
            currentPaperID = paper.PaperIDValue; // Armazena o ID do papel
            isPaperRegistered = true; // Marca que o papel foi registrado
            Debug.Log($"Papel {currentPaperID} colocado no slot {name}");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PaperID paper = other.GetComponent<PaperID>();
        if (paper != null && currentPaperID == paper.PaperIDValue)
        {
            currentPaperID = -1; // Slot vazio
            isPaperRegistered = false; // Libera para registrar novamente
            Debug.Log($"Papel {paper.PaperIDValue} removido do slot {name}");
        }
    }

    public int CorrectPaperID => correctPaperID; // Getter para o GameManager
}

