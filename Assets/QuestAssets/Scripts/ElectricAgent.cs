using UnityEngine;

public abstract class ElectricAgent : MonoBehaviour {
    public abstract void ChangePower(bool status);
    public abstract void ButtonUse();
}
