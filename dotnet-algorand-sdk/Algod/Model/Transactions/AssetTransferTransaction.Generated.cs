﻿
using JsonSubTypes;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Algorand.Algod.Model.Transactions
{

  
    public partial class AssetTransferTransaction : AssetMovementsTransaction
    {


        /// <summary>
        /// The amount of asset to transfer. A zero amount transferred to self
        /// allocates that asset in the account's Assets map.
        /// </summary>
        [JsonProperty(PropertyName = "aamt", Required = Required.Always)]
        [DefaultValue(0)]
        public ulong AssetAmount { get; set; } = 0;



        /// <summary>
        /// The receiver of the transfer.
        /// </summary>
        [JsonProperty(PropertyName = "arcv", Required = Required.Always)]
        public Address AssetReceiver { get; set; }

        /// <summary>
        /// Indicates that the asset should be removed from the account's Assets map,
        /// and specifies where the remaining asset holdings should be transferred.
        /// It's always valid to transfer remaining asset holdings to the AssetID account.
        /// </summary>
        [JsonProperty(PropertyName = "aclose")]
        public Address AssetCloseTo { get; set; }



        [JsonIgnore]
        public ulong? AssetClosingAmount { get; internal set; }





    }
}
