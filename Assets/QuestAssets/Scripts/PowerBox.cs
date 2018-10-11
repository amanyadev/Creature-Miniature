using UnityEngine;

public class PowerBox : Interactable {

    [SerializeField]
    public Button[] buttons;
    [SerializeField]
    private bool hasPower = false;
    private Animator animator = null;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].ChangePower(hasPower);
        }
        Animate();
    }

    public override void Interact()
    {
        hasPower = !hasPower;
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].ChangePower(hasPower);
        }
        Animate();
    }

    void Animate()
    {
        animator.SetBool("On", hasPower);
    }
}
