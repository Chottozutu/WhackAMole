using UnityEngine;

public class Hole : MonoBehaviour
{
    private Mole mole;

    private void Awake()
    {
        mole = GetComponentInChildren<Mole>();
    }

    public void Show()
    {
        mole.Show();
    }

    public void Hide()
    {
        mole.Hide();
    }
}