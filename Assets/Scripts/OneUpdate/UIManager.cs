using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField m_amountText;
    [SerializeField] private TMP_Dropdown m_modeDropdown;
    [SerializeField] private Instantiator m_instantiator;

    private void Start()
    {
        ButtonSimulateClicked();
    }

    public void ButtonSimulateClicked()
    {
        if (int.TryParse(m_amountText.text, out int amount))
        {
            m_instantiator.Simulate((Instantiator.Mode)m_modeDropdown.value, amount);
        }
    }
}
