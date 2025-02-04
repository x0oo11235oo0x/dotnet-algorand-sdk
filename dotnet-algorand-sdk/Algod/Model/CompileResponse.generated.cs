
namespace Algorand.Algod.Model
{

using System = global::System;


public partial class CompileResponse{

    [Newtonsoft.Json.JsonProperty("hash", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string Hash {get;set;}


    [Newtonsoft.Json.JsonProperty("result", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string Result {get;set;}

    
}


}
