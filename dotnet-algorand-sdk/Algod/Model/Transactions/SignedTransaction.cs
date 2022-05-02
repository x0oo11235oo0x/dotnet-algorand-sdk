﻿
#nullable enable

using Algorand.Utils;
using Newtonsoft.Json;
using System;

namespace Algorand.V2.Algod.Model
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class SignedTransaction
    {
        [JsonProperty(PropertyName = "txn")]
        public Transaction Tx;

        [JsonProperty(PropertyName = "sig")]
        public Signature? Sig; 

        [JsonProperty(PropertyName = "msig")]
        public MultisigSignature? MSig;

        [JsonProperty(PropertyName = "lsig")]
        public LogicsigSignature? LSig;

        [JsonProperty(PropertyName = "sgnr")]
        public Address AuthAddr = new Address();
        public void SetAuthAddr(byte[] sigAddr)
        {
            AuthAddr = new Address(sigAddr);
        }

        [JsonIgnore]
        public string transactionID = "";

        public SignedTransaction(Transaction tx, Signature sig, MultisigSignature mSig, LogicsigSignature lSig, string transactionID)
        {
            this.Tx = tx;
            this.MSig = mSig;
            this.Sig = sig;
            this.LSig = lSig;
            this.TransactionID = transactionID;
        }

        public SignedTransaction(Transaction tx, Signature sig, string txId) :
            this(tx, sig, new MultisigSignature(), new LogicsigSignature(), txId)
        { }

        public SignedTransaction(Transaction tx, MultisigSignature mSig, string txId) :
            this(tx, new Signature(), mSig, new LogicsigSignature(), txId)
        { }

        public SignedTransaction(Transaction tx, LogicsigSignature lSig, string txId) :
            this(tx, new Signature(), new MultisigSignature(), lSig, txId)
        { }

        public SignedTransaction() { }

        [JsonConstructor]
        public SignedTransaction(Transaction txn, byte[] sig, MultisigSignature msig, LogicsigSignature lsig, byte[] sgnr)
        {
            if (txn != null) Tx = txn;
            if (sig != null) Sig = new Signature(sig);
            if (msig != null) MSig = msig;
            if (lsig != null) LSig = lsig;
            if (sgnr != null) AuthAddr = new Address(sgnr);
            // don't recover the txid yet
        }



        /// <summary>
        /// MergeMultisigTransactions merges the given (partially) signed multisig transactions.
        /// </summary>
        /// <param name="txs">partially signed multisig transactions to merge. Underlying transactions may be mutated.</param>
        /// <returns>merged multisig transaction</returns>
        public static SignedTransaction MergeMultisigTransactions(params SignedTransaction[] txs)
        {
            if (txs.Length < 2)
            {
                throw new ArgumentException("cannot merge a single transaction");
            }
            SignedTransaction merged = txs[0];
            for (int i = 0; i < txs.Length; i++)
            {
                // check that multisig parameters match
                SignedTransaction tx = txs[i];
                if (tx.MSig.version != merged.MSig.version ||
                        tx.MSig.threshold != merged.MSig.threshold)
                {
                    throw new ArgumentException("transaction msig parameters do not match");
                }
                for (int j = 0; j < tx.MSig.subsigs.Count; j++)
                {
                    MultisigSubsig myMsig = merged.MSig.subsigs[j];
                    MultisigSubsig theirMsig = tx.MSig.subsigs[j];
                    if (!theirMsig.key.Equals(myMsig.key))
                    {
                        throw new ArgumentException("transaction msig public keys do not match");
                    }
                    if (myMsig.sig.Equals(new Signature()))
                    {
                        myMsig.sig = theirMsig.sig;
                    }
                    else if (!myMsig.sig.Equals(theirMsig.sig) &&
                          !theirMsig.sig.Equals(new Signature()))
                    {
                        throw new ArgumentException("transaction msig has mismatched signatures");
                    }
                    merged.MSig.subsigs[j] = myMsig;
                }
            }
            return merged;
        }

        /// <summary>
        /// a convenience method for working directly with raw transaction files.
        /// </summary>
        /// <param name="txsBytes">list of multisig transactions to merge</param>
        /// <returns>an encoded, merged multisignature transaction</returns>
        public static byte[] MergeMultisigTransactionBytes(params byte[][] txsBytes)
        {

            SignedTransaction[] sTxs = new SignedTransaction[txsBytes.Length];
            for (int i = 0; i < txsBytes.Length; i++)
            {
                sTxs[i] = Encoder.DecodeFromMsgPack<SignedTransaction>(txsBytes[i]);
            }
            SignedTransaction merged = MergeMultisigTransactions(sTxs);
            return Encoder.EncodeToMsgPack(merged);
        }

        /// <summary>
        /// AppendMultisigTransaction appends our signature to the given multisig transaction.
        /// </summary>
        /// <param name="from">the multisig public identity we are signing for</param>
        /// <param name="signedTx">the partially signed msig tx to which to append signature</param>
        /// <returns>merged multisig transaction</returns>
        public SignedTransaction AppendMultisigTransaction(MultisigAddress from,Account signingAccount)
        {
            SignedTransaction sTx = Tx.Sign(from,signingAccount);
            return MergeMultisigTransactions(sTx);
        }


        public override bool Equals(object obj)
        {
            if (obj is SignedTransaction actual)
            {
                if (!Tx.Equals(actual.Tx)) return false;
                if (!Sig.Equals(actual.Sig)) return false;
                if (!LSig.Equals(actual.LSig)) return false;
                if (!AuthAddr.Equals(actual.AuthAddr)) return false;
                return MSig.Equals(actual.MSig);
            }
            return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

     
    }
}
