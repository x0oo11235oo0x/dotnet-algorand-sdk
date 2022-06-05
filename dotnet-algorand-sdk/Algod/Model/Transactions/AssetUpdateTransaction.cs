﻿using JsonSubTypes;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Algorand.Algod.Model.Transactions
{
    [JsonConverter(typeof(JsonSubtypes))]
    [JsonSubtypes.KnownSubTypeWithProperty(typeof(AssetUpdateTransaction),"apar")]
    [JsonSubtypes.FallBackSubType(typeof(AssetDestroyTransaction))]

    public partial class AssetUpdateTransaction : AssetChangeTransaction
    {
    


    }
}
