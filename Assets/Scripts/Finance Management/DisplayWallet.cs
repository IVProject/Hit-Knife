using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Proekt.FinanceManagement
{
    [RequireComponent(typeof(Text))]
    public class DisplayWallet : MonoBehaviour
    {
        [SerializeField] private float m_SpeedAnimation;
 
        private Wallet m_Wallet;
        private Text m_Label;

        private void OnEnable()
        {
            m_Label = GetComponent<Text>();
            m_Wallet = Wallet.GetInstance();
            m_Wallet.onChangeAmount += Show;
        }

        private void OnDisable()
        {
            m_Wallet.onChangeAmount -= Show;
        }

        private void Show(uint value)
        {
            m_Label.text = value.ToString();
        }
    }
}
