using System;
using System.Collections.Generic;
using UnityEngine;

public class OneUpdater : MonoBehaviour
{
    public static OneUpdater Instance { get; private set; }

    private List<IUpdateable> m_updates = new List<IUpdateable>();

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Register(IUpdateable updateable)
    {
        m_updates.Add(updateable);
    }

    private void Update()
    {
        foreach (IUpdateable updateable in m_updates)
        {
            updateable.UpdateMe();
        }
    }

    internal void Disable()
    {
        m_updates.Clear();
        enabled = false;
    }

    internal void Enable()
    {
        m_updates.Clear();
        enabled = true;
    }
}
