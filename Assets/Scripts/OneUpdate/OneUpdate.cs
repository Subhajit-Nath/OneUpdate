using UnityEngine;

public class OneUpdate : MonoBehaviour, IUpdateable
{
    [SerializeField] private Mover m_mover;

    private void Start()
    {
        OneUpdater.Instance.Register(this);
    }

    public void UpdateMe()
    {
        m_mover.Move();
    }
}
