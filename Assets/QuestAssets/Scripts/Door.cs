using UnityEngine;

public class Door : ElectricAgent
{
    [SerializeField]
    private bool hasPower = false;
    [SerializeField]
    private bool opened = false;
    private Animator animator = null;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public override void ChangePower(bool status)
    {
        hasPower = status;
        if (hasPower && opened)
            OpenDoor();
        else if (!hasPower)
            CloseDoor();
    }

    public override void ButtonUse()
    {
        opened = !opened;
        if (!hasPower)
            return;
        if (opened)
            OpenDoor();
        else
            CloseDoor();
    }

    void OpenDoor()
    {
        animator.SetBool("Open", true);
    }

    void CloseDoor()
    {
        animator.SetBool("Open", false);
    }
}
