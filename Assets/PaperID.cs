using UnityEngine;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PaperID : MonoBehaviour
{
    [SerializeField] // Torna visível no Inspector mesmo sendo privada
    private int paperID; 

    // Getter para o paperID
    public int PaperIDValue => paperID;

        private void Start()
    {
        //
    }

    // Método chamado quando o papel é pego
    public void OnGrab()
    {
        PlaySoundForPaper(paperID);
        Debug.Log($"Papel {paperID} foi pego!");
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
            case 2: // ID do papel do abdômen
                FindObjectOfType<AudioManager>().Play("SomAbdomen");
                break;
            case 3: // ID do papel das pernas
                FindObjectOfType<AudioManager>().Play("SomPernas");
                break;
            // Adicione outros casos conforme necessário
            default:
                Debug.LogWarning($"Nenhum som configurado para o ID de papel {paperID}");
                break;
        }
    }

}