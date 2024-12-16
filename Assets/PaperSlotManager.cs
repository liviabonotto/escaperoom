// ÚLTIMA VERSÃO COM ERRO -> PRINTA APENAS O SLOT 4 COM ERRO
    

// using UnityEngine;

// public class PaperSlotManager : MonoBehaviour
// {
//     public SlotChecker[] slots; // Array com todos os slots
//     public Light lampLight; // Referência à lâmpada que apagará

//     private bool isLightOff = false;

//     void Update()
//     {
//         // Verifica se todos os papéis estão nos slots corretos
//         if (!isLightOff && CheckAllSlots())
//         {
//             Debug.Log("Todos os slots estão corretos!"); // Log de confirmação
//             if (lampLight != null)
//             {
//                 lampLight.enabled = false; // Apaga a luz
//                 isLightOff = true; // Evita verificações desnecessárias
//                 Debug.Log("A luz apagou!"); // Confirma que a luz foi apagada
//             }
//             else
//             {
//                 Debug.LogWarning("Lamp Light não está atribuído no Inspector!");
//             }
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




// ÚLTIMA VERSÃO FUNCIONADO, MAS ELE TRIGGA SÓ DE ENCOSTAR NO SLOT 

using UnityEngine;

public class PaperSlotManager : MonoBehaviour
{
    public SlotChecker[] slots; // Array com todos os slots
    public Light lampLight; // Referência à lâmpada que apagará

    private bool isLightOff = false;

    void Update()
    {
        // Verifica se todos os papéis estão nos slots corretos
        if (!isLightOff && CheckAllSlots())
        {
            Debug.Log("Todos os slots estão corretos!"); // Log de confirmação
            if (lampLight != null)
            {
                lampLight.enabled = false; // Apaga a luz
                isLightOff = true; // Evita verificações desnecessárias
                Debug.Log("A luz apagou!"); // Confirma que a luz foi apagada
            }
            else
            {
                Debug.LogWarning("Lamp Light não está atribuído no Inspector!");
            }
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