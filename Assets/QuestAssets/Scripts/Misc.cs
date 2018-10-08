using UnityEngine;

public class Misc : MonoBehaviour {

    public void ToggleEnabled()
    {
        if (gameObject.activeInHierarchy)
            gameObject.SetActive(false);
        else
            gameObject.SetActive(true);
    }
}
