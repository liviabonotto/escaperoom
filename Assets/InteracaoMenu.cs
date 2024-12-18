using UnityEngine;

public class PenInteraction : MonoBehaviour
{
    // Referência para o BoxCollider da maçaneta da porta
    public Collider startCollider;

    private void OnTriggerEnter(Collider other)
    {
        // Verifica se a colisão foi com o Collider da maçaneta (especificamente configurado no Editor)
        if (other == startCollider)
        {
            // Chama a função de abrir a porta ou qualquer outra ação
            StartGame();
        }
    }

    public void StartGame()
    {
        // É AQUI QUE REFERENCIAMOS A CENA!!!!!!
        SceneTransitionManager.singleton.GoToSceneAsync(1); 
        Debug.Log("Jogo iniciado!");
    }

}
