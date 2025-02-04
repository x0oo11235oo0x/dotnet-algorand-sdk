﻿


using JsonSubTypes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Algorand.Algod.Model.Transactions
{

  


    public abstract partial class ApplicationCallTransaction : Transaction
    {




        [JsonProperty(PropertyName = "apat")]
        public List<Address> Accounts { get; set; } = new List<Address>();

        [JsonProperty(PropertyName = "apaa")]
        public List<byte[]> ApplicationArgs { get; set; } = new List<byte[]>();

        [JsonProperty(PropertyName = "apfa")]
        public List<ulong> ForeignApps { get; set; } = new List<ulong>();

        [JsonProperty(PropertyName = "apas")]
        public List<ulong> ForeignAssets { get; set; } = new List<ulong>();

        public bool ShouldSerializeAccounts() { return Accounts?.Count > 0; }
        public bool ShouldSerializeApplicationArgs() { return ApplicationArgs?.Count > 0; }
        public bool ShouldSerializeForeignApps() { return ForeignApps?.Count > 0; }
        public bool ShouldSerializeForeignAssets() { return ForeignAssets?.Count > 0; }

        [JsonIgnore]
        public ICollection<IReturnableTransaction> InnerTxns { get; internal set; }

        [JsonIgnore]
        public ICollection<byte[]> Logs { get; internal set; }

        [JsonIgnore]
        public StateDelta GlobalStateDelta { get; internal set; }
        [JsonIgnore]
        public ICollection<AccountStateDelta> LocalStateDelta { get; internal set; }

    }
}
