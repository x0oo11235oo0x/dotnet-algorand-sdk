
namespace Algorand.Indexer.Model
{

using System = global::System;


public partial class AccountsResponse{

    [Newtonsoft.Json.JsonProperty("accounts", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public System.Collections.Generic.ICollection<Account> Accounts {get;set;} = new System.Collections.ObjectModel.Collection<Account>();


    [Newtonsoft.Json.JsonProperty("current-round", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong CurrentRound {get;set;}

    [Newtonsoft.Json.JsonProperty("next-token", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string NextToken {get;set;}

    
}


}
