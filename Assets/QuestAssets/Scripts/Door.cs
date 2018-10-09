using UnityEngine;

public class Door : MonoBehaviour {

    private bool opened = false;
    private Animator animator = null;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void UseDoor() {
        if (opened)
        {
            opened = false;
            animator.SetBool("Open", opened);
        }
        else
        {
            opened = true;
            animator.SetBool("Open", opened);
        }
    }
}
