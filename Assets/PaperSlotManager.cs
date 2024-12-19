
// VERSÃO PARA TRIGGAR SOLTAR A CRUZ

// using UnityEngine;
// using UnityEngine.XR.Interaction.Toolkit;

// public class PaperSlotManager : MonoBehaviour
// {
//     public SlotChecker[] slots; // Array com todos os slots
//     public Light lampLight; // Referência à lâmpada que apagará
//     public XRGrabInteractable cruzInteractable; // Referência ao componente XRGrabInteractable da cruz

//     private bool isLightOff = false;

//     void Update()
//     {
//         // Verifica se todos os papéis estão nos slots corretos
//         if (!isLightOff && CheckAllSlots())
//         {
//             Debug.Log("Todos os slots estão corretos!"); // Log de confirmação

//             // Apagar a luz
//             if (lampLight != null)
//             {
//                 lampLight.enabled = false;
//                 Debug.Log("A luz apagou!");
//             }
//             else
//             {
//                 Debug.LogWarning("Lamp Light não está atribuído no Inspector!");
//             }

//             // Ativar o XRGrabInteractable da Cruz
//             if (cruzInteractable != null)
//             {
//                 cruzInteractable.enabled = true; // Habilita o XRGrabInteractable
//                 Debug.Log("A cruz agora está interagível!");
//             }
//             else
//             {
//                 Debug.LogWarning("XRGrabInteractable da cruz não foi configurado no Inspector!");
//             }

//             isLightOff = true; // Evita verificações desnecessárias
//         }
//     }

//     bool CheckAllSlots()
//     {
//         foreach (SlotChecker slot in slots)
//         {
//             if (slot.currentPaperID != slot.CorrectPaperID)
//             {
//                 Debug.Log($"Slot {slot.name} incorreto: esperado {slot.CorrectPaperID}, mas tem {slot.currentPaperID}");
//                 return false; // Algum slot está incorreto
//             }
//         }
//         Debug.Log("Todos os IDs de slots estão corretos!"); // Log de confirmação
//         return true; // Todos os slots estão corretos
//     }
// }


using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PaperSlotManager : MonoBehaviour
{
    public SlotChecker[] slots; // Array com todos os slots
    public Light lampLight; // Referência à lâmpada que apagará
    public XRGrabInteractable cruzInteractable; // Referência ao componente XRGrabInteractable da cruz
    public AudioManager audioManager; // Referência ao AudioManager

    private bool isLightOff = false;

    void Update()
    {
        // Verifica se todos os papéis estão nos slots corretos
        if (!isLightOff && CheckAllSlots())
        {
            Debug.Log("Todos os slots estão corretos!"); // Log de confirmação

            // Apagar a luz
            if (lampLight != null)
            {
                lampLight.enabled = false;
                Debug.Log("A luz apagou!");
            }
            else
            {
                Debug.LogWarning("Lamp Light não está atribuído no Inspector!");
            }

            // Ativar o XRGrabInteractable da Cruz
            if (cruzInteractable != null)
            {
                cruzInteractable.enabled = true; // Habilita o XRGrabInteractable
                Debug.Log("A cruz agora está interagível!");
            }
            else
            {
                Debug.LogWarning("XRGrabInteractable da cruz não foi configurado no Inspector!");
            }

            // Tocar o áudio de Glitch
            if (audioManager != null)
            {
                audioManager.Play("Glitch");
                Debug.Log("Áudio de Glitch tocado!");
            }
            else
            {
                Debug.LogWarning("AudioManager não está atribuído no Inspector!");
            }

            isLightOff = true; // Evita verificações desnecessárias
        }
    }

    bool CheckAllSlots()
    {
        foreach (SlotChecker slot in slots)
        {
            if (slot.currentPaperID != slot.CorrectPaperID)
            {
                Debug.Log($"Slot {slot.name} incorreto: esperado {slot.CorrectPaperID}, mas tem {slot.currentPaperID}");
                return false; // Algum slot está incorreto
            }
        }
        Debug.Log("Todos os IDs de slots estão corretos!"); // Log de confirmação
        return true; // Todos os slots estão corretos
    }
}
