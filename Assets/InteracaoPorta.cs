using UnityEngine;

public class KeyInteraction : MonoBehaviour
{
    // Referência para o BoxCollider da maçaneta da porta
    public Collider maçanetaCollider;

    private void OnTriggerEnter(Collider other)
    {
        // Verifica se a colisão foi com o Collider da maçaneta (especificamente configurado no Editor)
        if (other == maçanetaCollider)
        {
            // Chama a função de abrir a porta ou qualquer outra ação
            StartGame();
        }
    }

    public void StartGame()
    {
        // É AQUI QUE REFERENCIAMOS A CENA!!!!!!
        SceneTransitionManager.singleton.GoToSceneAsync(0); 
        Debug.Log("Porta aberta!");
    }

    void AbrirPorta()
    {
        // Exemplo de ação: Ativa a animação ou desativa o objeto da porta
        Debug.Log("Porta aberta!");
    }
}
