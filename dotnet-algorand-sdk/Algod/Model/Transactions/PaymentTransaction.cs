﻿

using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Text;
using System.Runtime.CompilerServices;

namespace Algorand.Algod.Model.Transactions
{
    public partial class PaymentTransaction : Transaction
    {
        [JsonProperty(PropertyName = "type")]
        public string type => "pay";

     

        public PaymentTransaction() { }


        /// <summary>
        /// Flat Fee Payment Transaction
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="amount"></param>
        /// <param name="message"></param>
        /// <param name="flatFee"></param>
        /// <param name="lastRound"></param>
        /// <param name="genesisId"></param>
        /// <param name="genesishashb64"></param>
        /// <returns></returns>
        public PaymentTransaction(Address from, Address to, ulong? amount, string message, ulong flatFee, ulong? lastRound, string genesisId, string genesishashb64)
        {
            var notes = message is null ? null : Encoding.UTF8.GetBytes(message);

            Sender = from;
            Fee = flatFee;
            FirstValid = lastRound;
            LastValid = lastRound + 1000;
            Note = notes;
            Amount = amount;
            Receiver = to;
            GenesisID = genesisId;

            if (String.IsNullOrWhiteSpace(genesishashb64)) {
                GenesisHash = null;
            }
            else
            {
                GenesisHash = new Digest(genesishashb64);
            }
        }

        /// <summary>
        /// Get a payment transaction
        /// </summary>
        /// <param name="from">from address</param>
        /// <param name="to">to address</param>
        /// <param name="amount">amount(Unit:MicroAlgo)</param>
        /// <param name="message">message</param>
        /// <param name="trans">Transaction Params(use AlgodApi.TransactionParams() function to get the params)</param>
        /// <returns>payment transaction</returns>
        public static PaymentTransaction GetPaymentTransactionFromNetworkTransactionParameters(Address from, Address to, ulong amount, string message, TransactionParametersResponse trans)
        {
            if (trans is null) throw new Exception("The Transaction Params can not be null!");
            return GetPaymentTransactionWithSuggestedFee(from, to, amount, message, trans.Fee, trans.LastRound, trans.GenesisId, Convert.ToBase64String(trans.GenesisHash));
        }


        /// <summary>
        /// Get a transaction with the fee set to a suggested fee per txn size
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="amount"></param>
        /// <param name="message"></param>
        /// <param name="suggestedFeePerByte"></param>
        /// <param name="lastRound"></param>
        /// <param name="genesisId"></param>
        /// <param name="genesishashb64"></param>
        /// <returns></returns>
        public static PaymentTransaction GetPaymentTransactionWithSuggestedFee(Address from, Address to, ulong amount, string message, ulong suggestedFeePerByte, ulong lastRound, string genesisId, string genesishashb64)
        {
            var tx = new PaymentTransaction(from, to, amount, message, 0, lastRound, genesisId, genesishashb64);

            tx.SetFeeByFeePerByte( suggestedFeePerByte);
            return tx;
        }

    }
}
