using UnityEngine;

public class PlayerInteractions : MonoBehaviour {

    public delegate void Actions();
    public Actions actions;
	
	void Update () {
		if (Input.GetKeyDown("e"))
        {
            if (actions != null)
                actions();
        }
    }
}
