using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Verifica se a mão colidiu com a mesa
        if (collision.gameObject.CompareTag("TableOffice"))
        {
            Debug.Log("Hand touched the table!");
        }
    }
}
