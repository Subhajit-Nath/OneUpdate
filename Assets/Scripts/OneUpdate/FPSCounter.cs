using UnityEngine;
using TMPro;

public class FPSCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text m_fpsText;
    [SerializeField] private float m_hudRefreshRate = 1f;

    private float m_timer;

    private void Update()
    {
        if (Time.unscaledTime > m_timer)
        {
            int fps = (int)(1f / Time.unscaledDeltaTime);
            m_fpsText.text = "FPS: " + fps;
            m_timer = Time.unscaledTime + m_hudRefreshRate;
        }
    }
}