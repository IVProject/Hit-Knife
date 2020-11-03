using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proekt.FinanceManagement;

namespace Proekt.GiftBoxes
{
    public class StandartBox : GiftBox
    {
        [SerializeField] private uint m_DiamondsAmount;

        protected override void Give()
        {
            Wallet wallet = Wallet.GetInstance();

            wallet.Put(diamondsAmount);
        }

        public uint diamondsAmount { get => m_DiamondsAmount; }
    }
}
