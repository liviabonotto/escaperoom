using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LiberarObjetos : MonoBehaviour
{
    public Rigidbody chaveRigidbody;

    private Rigidbody cruzRigidbody;

    private void Start()
    {
        // Referência ao Rigidbody da cruz
        cruzRigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        // Adiciona o evento de pegar a cruz
        GetComponent<XRGrabInteractable>().selectEntered.AddListener(OnCruzPega);
    }

    private void OnDisable()
    {
        GetComponent<XRGrabInteractable>().selectEntered.RemoveListener(OnCruzPega);
    }

    private void OnCruzPega(SelectEnterEventArgs args)
    {
        // Libera a cruz (ativa a física)
        cruzRigidbody.isKinematic = false;

        // Libera a chave para ser interativa
        chaveRigidbody.isKinematic = false;
    }
}
