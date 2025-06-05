using System;

namespace Bank.Domain
{
    /// <summary>
    /// Representa una cuenta bancaria de un cliente.
    /// </summary>
    public class BankAccount
    {
        /// <summary>
        /// Mensaje mostrado cuando el monto del débito excede el saldo.
        /// </summary>
        public const string DebitAmountExceedsBalanceMessage = "Debit amount exceeds balance";

        /// <summary>
        /// Mensaje mostrado cuando el monto del débito es menor a cero.
        /// </summary>
        public const string DebitAmountLessThanZeroMessage = "Debit amount is less than zero";

        private readonly string m_customerName;
        private double m_balance;

        /// <summary>
        /// Constructor privado para evitar instanciación sin parámetros.
        /// </summary>
        private BankAccount() { }

        /// <summary>
        /// Crea una nueva cuenta bancaria.
        /// </summary>
        /// <param name="customerName">Nombre del cliente.</param>
        /// <param name="balance">Saldo inicial de la cuenta.</param>
        public BankAccount(string customerName, double balance)
        {
            m_customerName = customerName;
            m_balance = balance;
        }

        /// <summary>
        /// Nombre del cliente.
        /// </summary>
        public string CustomerName { get { return m_customerName; } }

        /// <summary>
        /// Saldo actual de la cuenta.
        /// </summary>
        public double Balance { get { return m_balance; } }

        /// <summary>
        /// Debita una cantidad del saldo de la cuenta.
        /// </summary>
        /// <param name="amount">Cantidad a debitar.</param>
        /// <exception cref="ArgumentOutOfRangeException">Si el monto es mayor al saldo o menor que cero.</exception>
        public void Debit(double amount)
        {
            if (amount > m_balance)
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountExceedsBalanceMessage);
            if (amount < 0)
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountLessThanZeroMessage);

            m_balance -= amount;
        }

        /// <summary>
        /// Acredita una cantidad al saldo de la cuenta.
        /// </summary>
        /// <param name="amount">Cantidad a acreditar.</param>
        /// <exception cref="ArgumentOutOfRangeException">Si el monto es negativo.</exception>
        public void Credit(double amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException("amount");
            m_balance += amount;
        }
    }
}
