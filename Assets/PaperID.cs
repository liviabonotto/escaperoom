using UnityEngine;

public class PaperID : MonoBehaviour
{
    [SerializeField] // Torna visível no Inspector mesmo sendo privada
    private int paperID; 

    // Getter para o paperID
    public int PaperIDValue => paperID;
}
