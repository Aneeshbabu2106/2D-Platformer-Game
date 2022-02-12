using UnityEngine;

public class PopUpMessage : MonoBehaviour
{
    public void enableMessage()
    {
        this.gameObject.SetActive(true);
    }
    public void disableMesage()
    {
        this.gameObject.SetActive(false);
    }
}
