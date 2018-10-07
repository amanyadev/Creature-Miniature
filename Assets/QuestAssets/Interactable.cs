using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class Interactable : MonoBehaviour 
{
    public bool interactable = true;
    protected bool interacted = false;
    protected PlayerInteractions player = null;
    [SerializeField]
    protected UnityEvent[] actions;

    public virtual void Interact()
    {
        Debug.Log("Interact function is not set-up.");
        for (int i = 0; i < actions.Length; i++)
        {
            actions[i].Invoke();
        }
    }

    void OnTriggerEnter(Collider other) {
        player = other.GetComponent<PlayerInteractions>();
        if (interactable && player != null)
        {
            interacted = true;
            player.actions += Interact;
        }
    }

    void OnTriggerExit()
    {
        if (interacted)
            player.actions -= Interact;
    }
}
