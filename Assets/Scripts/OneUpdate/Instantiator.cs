using System;
using System.Collections;
using UnityEngine;

public class Instantiator : MonoBehaviour
{
    public enum Mode
    {
        NORMAL_UPDATE,
        ONE_UPDATE
    }

    [SerializeField] private GameObject m_normalUpdateObject;
    [SerializeField] private GameObject m_oneUpdateObject;
    
    private Mode m_mode;
    private int m_count;

    private void Start()
    {
    }

    public void Simulate(Mode mode, int count)
    {
        m_mode = mode;
        m_count = count;

        if (m_mode == Mode.NORMAL_UPDATE)
        {
            OneUpdater.Instance.Disable();
        }
        else if(m_mode == Mode.ONE_UPDATE)
        {
            OneUpdater.Instance.Enable();
        }

        StartCoroutine(DelayProcess());
    }

    private IEnumerator DelayProcess()
    {
        CleanUpGrid();
        yield return null;
        InstantiateCubeGrid();
    }

    private void CleanUpGrid()
    {
        foreach (Transform childTransform in transform)
        {
            Destroy(childTransform.gameObject);
        }
    }

    private void InstantiateCubeGrid()
    {
        int row = (int)Mathf.Sqrt(m_count);
        float offset = 1.5f;
        int currentRow = 0;
        int currentCol = 0;

        for (int i = 0; i < m_count; i++)
        {
            if (currentRow >= row)
            {
                currentRow = 0;
                currentCol += 1;
            }

            GameObject currentCube = Instantiate(m_mode == Mode.NORMAL_UPDATE ? m_normalUpdateObject : m_oneUpdateObject, transform);
            currentCube.transform.position = new Vector3(currentRow * offset, 0, currentCol * offset);
            currentCube.GetComponent<Mover>().SetInitialPoint();
            currentRow += 1;
        }
    }
}
