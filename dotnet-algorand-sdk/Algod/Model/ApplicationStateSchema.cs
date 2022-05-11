﻿namespace Algorand.Algod.Model
{
    using System = global::System;


    /// <summary>Specifies maximums on the number of each type that may be stored.</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class ApplicationStateSchema
    {
        /// <summary>\[nui\] num of uints.</summary>
        [Newtonsoft.Json.JsonProperty("nui", Required = Newtonsoft.Json.Required.Always)]
        public ulong NumUint { get; private set; }

        /// <summary>\[nui\] num of uints.</summary>
        [Newtonsoft.Json.JsonProperty("num-uint", Required = Newtonsoft.Json.Required.Always)]
        private ulong numUint { set { NumUint = value; } }

        /// <summary>\[nbs\] num of byte slices.</summary>
        [Newtonsoft.Json.JsonProperty("nbs", Required = Newtonsoft.Json.Required.Always)]
        public ulong NumByteSlice { get; private set; }

        /// <summary>\[nbs\] num of byte slices.</summary>
        [Newtonsoft.Json.JsonProperty("num-byte-slice", Required = Newtonsoft.Json.Required.Always)]
        private ulong numByteSlice { set { NumByteSlice = value; } }


    }

}
