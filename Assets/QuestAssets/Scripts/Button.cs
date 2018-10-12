using UnityEngine;

public class Button : Interactable
{

    [SerializeField]
    private ElectricAgent[] objects;
    [SerializeField]
    private bool hasPower = false;
    [SerializeField]
    private bool turnedOn = false;
    private Animator animator = null;
    [SerializeField]
    private Material[] statusColors = new Material[3];

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start() 
    {
        for (int i = 0; i < objects.Length; i++)
        {
            if (turnedOn)
                objects[i].ButtonUse();
            objects[i].ChangePower(hasPower);
        }
        Animate();
    }

    public override void Interact()
    {
        turnedOn = !turnedOn;
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].ButtonUse();
        }
        Animate();
    }

    public void ChangePower(bool status)
    {
        hasPower = status;
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].ChangePower(status);
        }
        Animate();
    }

    void Animate()
    {
        Material mat;
        animator.SetBool("On", turnedOn);
        if (!hasPower)
            mat = statusColors[0];
        else if (!turnedOn)
            mat = statusColors[1];
        else
            mat = statusColors[2];
        transform.GetChild(1).GetComponent<MeshRenderer>().material = mat;
    }
}
