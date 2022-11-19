using UnityEngine;

public class NormalUpdate : MonoBehaviour
{
    [SerializeField] private Mover m_mover;

    private void Update()
    {
        m_mover.Move();
    }
}
