using UnityEngine;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PaperID : MonoBehaviour
{
    [SerializeField] // Torna visível no Inspector mesmo sendo privada
    private int paperID; 
    private bool soundPlayed = false;
    // Getter para o paperID
    public int PaperIDValue => paperID;

        private void Start()
    {
        //
    }

    // Método chamado quando o papel é pego
    public void OnGrab()
    {
        if (!soundPlayed) // Verifica se o som ainda não foi tocado
        {
            PlaySoundForPaper(paperID);
            soundPlayed = true; // Marca que o som foi tocado
            Debug.Log($"Papel {paperID} foi pego pela primeira vez!");
        }
        else
        {
            Debug.Log($"Papel {paperID} já foi pego antes, som não será reproduzido.");
        }
    }


    // Método chamado quando o papel é solto
    public void OnRelease()
    {
        Debug.Log($"Papel {paperID} foi solto!");
    }

    private void PlaySoundForPaper(int paperID)
    {
        switch (paperID)
        {
            case 4: // ID do papel da cabeça
                FindObjectOfType<AudioManager>().Play("SomCabeca");
                break;
            case 8: // ID do papel do abdômen
                FindObjectOfType<AudioManager>().Play("SomBracoDireito");
                break;
            case 7: // ID do papel das pernas
                FindObjectOfType<AudioManager>().Play("SomPes");
                break;
            case 6: // ID do papel das pernas
                FindObjectOfType<AudioManager>().Play("SomPernas");
                break;
            case 9: // ID do papel das pernas
                FindObjectOfType<AudioManager>().Play("SomBracoEsquerdo");
                break;
            default:
                Debug.LogWarning($"Nenhum som configurado para o ID de papel {paperID}");
                break;
        }
    }

}