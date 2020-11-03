using System;
using Proekt.SaveManagement;

namespace Proekt.FinanceManagement
{
    /// <summary>
    /// Responsible for keeping money.
    /// </summary>
    public class Wallet
    {
        private static Wallet m_Instance;

        #region Propertys
        public Action<uint> onChangeAmount { get; set; }
        public Action<uint> onPut { get; set; }
        public Action<uint> onSpend { get; set; }
        public uint amount { get; private set; }
        #endregion

        protected Wallet(uint amount)
        {
            this.amount = amount;
        }

        #region Methods
        /// <summary>
        /// Returns a wallet instance. Use to initialize the class.
        /// </summary>
        /// <returns></returns>
        public static Wallet GetInstance(uint amount = 0)
        {
            if (m_Instance == null)
            {
                m_Instance = new Wallet(amount);
            }

            return m_Instance;
        }

        /// <summary>
        /// Put money in your wallet.
        /// </summary>
        /// <param name="value">money</param>
        public void Put(uint value)
        {
            SetAmount(amount + value);

            if (onPut != null)
            {
                onPut.Invoke(amount);
            }
        }

        /// <summary>
        /// Try spend money from wallet.
        /// </summary>
        /// <param name="value">money</param>
        public void TrySpend(uint value)
        {
            if (amount >= value)
            {
                SetAmount(amount - value);

                if (onSpend != null)
                {
                    onSpend.Invoke(amount);
                }
            }
        }

        /// <summary>
        /// Set the amount of money.
        /// </summary>
        /// <param name="value">money</param>
        private void SetAmount(uint value)
        {
            amount = value;

            if (onChangeAmount != null)
            {
                onChangeAmount.Invoke(value);
            }
        }
        #endregion
    }
}
