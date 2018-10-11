using UnityEngine;

public class ElectricField : ElectricAgent
{
    [SerializeField]
    private bool hasPower = false;
    [SerializeField]
    private bool turnedOn = false;
    private GameObject field = null;

    void Start()
    {
        field = transform.GetChild(0).gameObject;
        ToggleActivate();
    }

    private void ToggleActivate()
    {
        if (!hasPower)
            field.SetActive(false);
        else
            field.SetActive(turnedOn);
    }

    public override void ButtonUse()
    {
        turnedOn = !turnedOn;
        ToggleActivate();
    }

    public override void ChangePower(bool status)
    {
        hasPower = !hasPower;
        ToggleActivate();
    }
}
