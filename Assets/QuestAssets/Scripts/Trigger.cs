using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour {
    public bool interactable = true;
    protected bool interacted = false;
    protected PlayerInteractions player = null;
    [SerializeField]
    protected UnityEvent[] actions;

    public virtual void OnTrigger(PlayerInteractions player)
    {
        Debug.Log("Trigger function is not set-up.");
        for (int i = 0; i < actions.Length; i++)
        {
            actions[i].Invoke();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        player = other.GetComponent<PlayerInteractions>();
        if (interactable && player != null)
        {
            OnTrigger(player);
        }
    }
}
