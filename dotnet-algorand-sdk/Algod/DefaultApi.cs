









namespace Algorand.Algod
{
    using Algorand.Utils;
    using Algorand.Algod.Model;
    using Algorand.Algod.Model.Transactions;
    using System.Collections.Generic;
    using System.IO;
    using System = global::System;
    using Newtonsoft.Msgpack;


    public partial interface IDefaultApi
    {
       /// <summary>Given a specific account public key, this call returns the accounts status,
/// balance and spendable amounts
       /// </summary>
       /// <param name="exclude">When set to `all` will exclude asset holdings, application local state, created asset parameters, any created application parameters. Defaults to `none`.</param>
       /// <param name="format">Configures whether the response object is JSON or MessagePack encoded.</param>
       /// <param name="address">An account public key</param>
       /// <exception cref="ApiException<ErrorResponse>">A server side error occurred.</exception>
       System.Threading.Tasks.Task<Account> AccountInformationAsync(string address, string? exclude,  Format? format);

       /// <param name="exclude">When set to `all` will exclude asset holdings, application local state, created asset parameters, any created application parameters. Defaults to `none`.</param>
       /// <param name="format">Configures whether the response object is JSON or MessagePack encoded.</param>
       /// <param name="address">An account public key</param>
       /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
       System.Threading.Tasks.Task<Account> AccountInformationAsync(string address, string? exclude,  Format? format, System.Threading.CancellationToken cancellationToken);

       /// <summary>Given a specific account public key and asset ID, this call returns the
/// account's asset holding and asset parameters (if either exist). Asset parameters
/// will only be returned if the provided address is the asset's creator.
       /// </summary>
       /// <param name="format">Configures whether the response object is JSON or MessagePack encoded.</param>
       /// <param name="address">An account public key</param>
       /// <param name="asset-id">An asset identifier</param>
       /// <exception cref="ApiException<ErrorResponse>">A server side error occurred.</exception>
       System.Threading.Tasks.Task<AccountAssetResponse> AccountAssetInformationAsync(string address, ulong assetId,  Format? format);

       /// <param name="format">Configures whether the response object is JSON or MessagePack encoded.</param>
       /// <param name="address">An account public key</param>
       /// <param name="asset-id">An asset identifier</param>
       /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
       System.Threading.Tasks.Task<AccountAssetResponse> AccountAssetInformationAsync(string address, ulong assetId,  Format? format, System.Threading.CancellationToken cancellationToken);

       /// <summary>Given a specific account public key and application ID, this call returns the
/// account's application local state and global state (AppLocalState and AppParams,
/// if either exists). Global state will only be returned if the provided address is
/// the application's creator.
       /// </summary>
       /// <param name="format">Configures whether the response object is JSON or MessagePack encoded.</param>
       /// <param name="address">An account public key</param>
       /// <param name="application-id">An application identifier</param>
       /// <exception cref="ApiException<ErrorResponse>">A server side error occurred.</exception>
       System.Threading.Tasks.Task<AccountApplicationResponse> AccountApplicationInformationAsync(string address, ulong applicationId,  Format? format);

       /// <param name="format">Configures whether the response object is JSON or MessagePack encoded.</param>
       /// <param name="address">An account public key</param>
       /// <param name="application-id">An application identifier</param>
       /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
       System.Threading.Tasks.Task<AccountApplicationResponse> AccountApplicationInformationAsync(string address, ulong applicationId,  Format? format, System.Threading.CancellationToken cancellationToken);

       /// <summary>Get the list of pending transactions by address, sorted by priority, in
/// decreasing order, truncated at the end at MAX. If MAX = 0, returns all pending
/// transactions.
       /// </summary>
       /// <param name="format">Configures whether the response object is JSON or MessagePack encoded.</param>
       /// <param name="max">Truncated number of transactions to display. If max=0, returns all pending txns.</param>
       /// <param name="address">An account public key</param>
       /// <exception cref="ApiException<ErrorResponse>">A server side error occurred.</exception>
       System.Threading.Tasks.Task<PendingTransactions> GetPendingTransactionsByAddressAsync(string address,  Format? format, ulong? max);

       /// <param name="format">Configures whether the response object is JSON or MessagePack encoded.</param>
       /// <param name="max">Truncated number of transactions to display. If max=0, returns all pending txns.</param>
       /// <param name="address">An account public key</param>
       /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
       System.Threading.Tasks.Task<PendingTransactions> GetPendingTransactionsByAddressAsync(string address,  Format? format, ulong? max, System.Threading.CancellationToken cancellationToken);

       /// <summary>Get the block for the given round.
       /// </summary>
       /// <param name="format">Configures whether the response object is JSON or MessagePack encoded.</param>
       /// <param name="round">The round from which to fetch block information.</param>
       /// <exception cref="ApiException<ErrorResponse>">A server side error occurred.</exception>
       System.Threading.Tasks.Task<CertifiedBlock> GetBlockAsync(ulong round,  Format? format);

       /// <param name="format">Configures whether the response object is JSON or MessagePack encoded.</param>
       /// <param name="round">The round from which to fetch block information.</param>
       /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
       System.Threading.Tasks.Task<CertifiedBlock> GetBlockAsync(ulong round,  Format? format, System.Threading.CancellationToken cancellationToken);

       /// <summary>Get a Merkle proof for a transaction in a block.
       /// </summary>
       /// <param name="format">Configures whether the response object is JSON or MessagePack encoded.</param>
       /// <param name="round">The round in which the transaction appears.</param>
       /// <param name="txid">The transaction ID for which to generate a proof.</param>
       /// <exception cref="ApiException<ErrorResponse>">A server side error occurred.</exception>
       System.Threading.Tasks.Task<ProofResponse> GetProofAsync(ulong round, string txid,  Format? format);

       /// <param name="format">Configures whether the response object is JSON or MessagePack encoded.</param>
       /// <param name="round">The round in which the transaction appears.</param>
       /// <param name="txid">The transaction ID for which to generate a proof.</param>
       /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
       System.Threading.Tasks.Task<ProofResponse> GetProofAsync(ulong round, string txid,  Format? format, System.Threading.CancellationToken cancellationToken);

       /// <summary>Get the current supply reported by the ledger.
       /// </summary>
       /// <exception cref="ApiException<ErrorResponse>">A server side error occurred.</exception>
       System.Threading.Tasks.Task<SupplyResponse> GetSupplyAsync();

       /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
       System.Threading.Tasks.Task<SupplyResponse> GetSupplyAsync(System.Threading.CancellationToken cancellationToken);

       /// <summary>Gets the current node status.
       /// </summary>
       /// <exception cref="ApiException<ErrorResponse>">A server side error occurred.</exception>
       System.Threading.Tasks.Task<NodeStatusResponse> GetStatusAsync();

       /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
       System.Threading.Tasks.Task<NodeStatusResponse> GetStatusAsync(System.Threading.CancellationToken cancellationToken);

       /// <summary>Waits for a block to appear after round {round} and returns the node's status at
/// the time.
       /// </summary>
       /// <param name="round">The round to wait until returning status</param>
       /// <exception cref="ApiException<ErrorResponse>">A server side error occurred.</exception>
       System.Threading.Tasks.Task<NodeStatusResponse> WaitForBlockAsync(ulong round);

       /// <param name="round">The round to wait until returning status</param>
       /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
       System.Threading.Tasks.Task<NodeStatusResponse> WaitForBlockAsync(ulong round, System.Threading.CancellationToken cancellationToken);

       /// <summary>Broadcasts a raw transaction to the network.
       /// </summary>
       /// <param name="rawtxn">The byte encoded signed transaction to broadcast to network</param>
       /// <exception cref="ApiException<ErrorResponse>">A server side error occurred.</exception>
       System.Threading.Tasks.Task<PostTransactionsResponse> TransactionsAsync(List<SignedTransaction> rawtxn);

       /// <param name="rawtxn">The byte encoded signed transaction to broadcast to network</param>
       /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
       System.Threading.Tasks.Task<PostTransactionsResponse> TransactionsAsync(List<SignedTransaction> rawtxn, System.Threading.CancellationToken cancellationToken);

       /// <summary>Get parameters for constructing a new transaction
       /// </summary>
       /// <exception cref="ApiException<ErrorResponse>">A server side error occurred.</exception>
       System.Threading.Tasks.Task<TransactionParametersResponse> TransactionParamsAsync();

       /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
       System.Threading.Tasks.Task<TransactionParametersResponse> TransactionParamsAsync(System.Threading.CancellationToken cancellationToken);

       /// <summary>Get the list of pending transactions, sorted by priority, in decreasing order,
/// truncated at the end at MAX. If MAX = 0, returns all pending transactions.
       /// </summary>
       /// <param name="format">Configures whether the response object is JSON or MessagePack encoded.</param>
       /// <param name="max">Truncated number of transactions to display. If max=0, returns all pending txns.</param>
       /// <exception cref="ApiException<ErrorResponse>">A server side error occurred.</exception>
       System.Threading.Tasks.Task<PendingTransactions> GetPendingTransactionsAsync( Format? format, ulong? max);

       /// <param name="format">Configures whether the response object is JSON or MessagePack encoded.</param>
       /// <param name="max">Truncated number of transactions to display. If max=0, returns all pending txns.</param>
       /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
       System.Threading.Tasks.Task<PendingTransactions> GetPendingTransactionsAsync( Format? format, ulong? max, System.Threading.CancellationToken cancellationToken);

       /// <summary>Given a transaction ID of a recently submitted transaction, it returns
/// information about it. There are several cases when this might succeed:
/// - transaction committed (committed round > 0)
/// - transaction still in the pool (committed round = 0, pool error = "")
/// - transaction removed from pool due to error (committed round = 0, pool error !=
/// "")
/// Or the transaction may have happened sufficiently long ago that the node no
/// longer remembers it, and this will return an error.
       /// </summary>
       /// <param name="format">Configures whether the response object is JSON or MessagePack encoded.</param>
       /// <param name="txid">A transaction ID</param>
       /// <exception cref="ApiException<ErrorResponse>">A server side error occurred.</exception>
       System.Threading.Tasks.Task<IReturnableTransaction> PendingTransactionInformationAsync(string txid,  Format? format);

       /// <param name="format">Configures whether the response object is JSON or MessagePack encoded.</param>
       /// <param name="txid">A transaction ID</param>
       /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
       System.Threading.Tasks.Task<IReturnableTransaction> PendingTransactionInformationAsync(string txid,  Format? format, System.Threading.CancellationToken cancellationToken);

       /// <summary>Given a application ID, it returns application information including creator,
/// approval and clear programs, global and local schemas, and global state.
       /// </summary>
       /// <param name="application-id">An application identifier</param>
       /// <exception cref="ApiException<ErrorResponse>">A server side error occurred.</exception>
       System.Threading.Tasks.Task<Application> GetApplicationByIDAsync(ulong applicationId);

       /// <param name="application-id">An application identifier</param>
       /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
       System.Threading.Tasks.Task<Application> GetApplicationByIDAsync(ulong applicationId, System.Threading.CancellationToken cancellationToken);

       /// <summary>Given a asset ID, it returns asset information including creator, name, total
/// supply and special addresses.
       /// </summary>
       /// <param name="asset-id">An asset identifier</param>
       /// <exception cref="ApiException<ErrorResponse>">A server side error occurred.</exception>
       System.Threading.Tasks.Task<Asset> GetAssetByIDAsync(ulong assetId);

       /// <param name="asset-id">An asset identifier</param>
       /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
       System.Threading.Tasks.Task<Asset> GetAssetByIDAsync(ulong assetId, System.Threading.CancellationToken cancellationToken);

       /// <summary>Given TEAL source code in plain text, return base64 encoded program bytes and
/// base32 SHA512_256 hash of program bytes (Address style). This endpoint is only
/// enabled when a node's configuration file sets EnableDeveloperAPI to true.
       /// </summary>
       /// <param name="source">TEAL source code to be compiled</param>
       /// <exception cref="ApiException<ErrorResponse>">A server side error occurred.</exception>
       System.Threading.Tasks.Task<CompileResponse> TealCompileAsync(System.IO.Stream source);

       /// <param name="source">TEAL source code to be compiled</param>
       /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
       System.Threading.Tasks.Task<CompileResponse> TealCompileAsync(System.IO.Stream source, System.Threading.CancellationToken cancellationToken);

       /// <summary>Executes TEAL program(s) in context and returns debugging information about the
/// execution. This endpoint is only enabled when a node's configuration file sets
/// EnableDeveloperAPI to true.
       /// </summary>
       /// <param name="request">Transaction (or group) and any accompanying state-simulation data.</param>
       /// <exception cref="ApiException<ErrorResponse>">A server side error occurred.</exception>
       System.Threading.Tasks.Task<DryrunResponse> TealDryrunAsync(DryrunRequest request);

       /// <param name="request">Transaction (or group) and any accompanying state-simulation data.</param>
       /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
       System.Threading.Tasks.Task<DryrunResponse> TealDryrunAsync(DryrunRequest request, System.Threading.CancellationToken cancellationToken);

    }

    public partial class DefaultApi : IDefaultApi
    {
       private System.Net.Http.HttpClient _httpClient;
       private System.Lazy<Newtonsoft.Json.JsonSerializerSettings> _settings;

       public DefaultApi(System.Net.Http.HttpClient httpClient)
       {
              _httpClient = httpClient;
              _settings = new System.Lazy<Newtonsoft.Json.JsonSerializerSettings>(CreateSerializerSettings);
       }
       
       private Newtonsoft.Json.JsonSerializerSettings CreateSerializerSettings()
       {
              var settings = new Newtonsoft.Json.JsonSerializerSettings();
              UpdateJsonSerializerSettings(settings);
              return settings;
       }  

       protected Newtonsoft.Json.JsonSerializerSettings JsonSerializerSettings { get { return _settings.Value; } }

       partial void UpdateJsonSerializerSettings(Newtonsoft.Json.JsonSerializerSettings settings);
       partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, string url);
       partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, System.Text.StringBuilder urlBuilder);
       partial void ProcessResponse(System.Net.Http.HttpClient client, System.Net.Http.HttpResponseMessage response);

       

       /// <summary>Given a specific account public key, this call returns the accounts status,
/// balance and spendable amounts
       /// </summary>
       /// <param name="exclude">When set to `all` will exclude asset holdings, application local state, created asset parameters, any created application parameters. Defaults to `none`.</param>
       /// <param name="format">Configures whether the response object is JSON or MessagePack encoded.</param>
       /// <param name="address">An account public key</param>
       /// <exception cref="ApiException">A server side error occurred.</exception>
       public System.Threading.Tasks.Task<Account> AccountInformationAsync(string address, string? exclude,  Format? format)
       {
              return AccountInformationAsync(address, exclude, format, System.Threading.CancellationToken.None);
       }

       /// <summary>>Given a specific account public key, this call returns the accounts status,
/// balance and spendable amounts
       /// </summary>
       /// <param name="exclude">When set to `all` will exclude asset holdings, application local state, created asset parameters, any created application parameters. Defaults to `none`.</param>
       /// <param name="format">Configures whether the response object is JSON or MessagePack encoded.</param>
       /// <param name="address">An account public key</param>
       /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
       /// <exception cref="ApiException<ErrorResponse>">A server side error occurred.</exception>
       public async System.Threading.Tasks.Task<Account> AccountInformationAsync(string address, string? exclude,  Format? format, System.Threading.CancellationToken cancellationToken)
       {
              if (address == null) throw new System.ArgumentNullException("address");
              var urlBuilder_ = new System.Text.StringBuilder();
              urlBuilder_.Append("v2/accounts/{address}?");
              urlBuilder_.Replace("{address}", System.Uri.EscapeDataString(ConvertToString(address, System.Globalization.CultureInfo.InvariantCulture)));
              if (exclude != null)
              {
                     urlBuilder_.Append(System.Uri.EscapeDataString("exclude") + "=").Append(System.Uri.EscapeDataString(ConvertToString(exclude, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
              }
              if (format != null)
              {
                     urlBuilder_.Append(System.Uri.EscapeDataString("format") + "=").Append(System.Uri.EscapeDataString(ConvertToString(format, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
              }
              urlBuilder_.Length--;
              var client_ = _httpClient;
              var disposeClient_ = false;
              try
              {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                     request_.Method = new System.Net.Http.HttpMethod("GET");
                     request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);

                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if (response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach (var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if (status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponseAsync<Account>(response_, headers_, cancellationToken).ConfigureAwait(false);
                            if (objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        //Algorand Generator cannot distinguish between response codes
                        {
                            var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                            if (objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            throw new ApiException<ErrorResponse>("Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                        }
                    }
                    finally
                    {
                        if (disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }

       }


       

       /// <summary>Given a specific account public key and asset ID, this call returns the
/// account's asset holding and asset parameters (if either exist). Asset parameters
/// will only be returned if the provided address is the asset's creator.
       /// </summary>
       /// <param name="format">Configures whether the response object is JSON or MessagePack encoded.</param>
       /// <param name="address">An account public key</param>
       /// <param name="asset-id">An asset identifier</param>
       /// <exception cref="ApiException">A server side error occurred.</exception>
       public System.Threading.Tasks.Task<AccountAssetResponse> AccountAssetInformationAsync(string address, ulong assetId,  Format? format)
       {
              return AccountAssetInformationAsync(address, assetId, format, System.Threading.CancellationToken.None);
       }

       /// <summary>>Given a specific account public key and asset ID, this call returns the
/// account's asset holding and asset parameters (if either exist). Asset parameters
/// will only be returned if the provided address is the asset's creator.
       /// </summary>
       /// <param name="format">Configures whether the response object is JSON or MessagePack encoded.</param>
       /// <param name="address">An account public key</param>
       /// <param name="asset-id">An asset identifier</param>
       /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
       /// <exception cref="ApiException<ErrorResponse>">A server side error occurred.</exception>
       public async System.Threading.Tasks.Task<AccountAssetResponse> AccountAssetInformationAsync(string address, ulong assetId,  Format? format, System.Threading.CancellationToken cancellationToken)
       {
              if (address == null) throw new System.ArgumentNullException("address");
              if (assetId == null) throw new System.ArgumentNullException("assetId");
              var urlBuilder_ = new System.Text.StringBuilder();
              urlBuilder_.Append("v2/accounts/{address}/assets/{asset-id}?");
              urlBuilder_.Replace("{address}", System.Uri.EscapeDataString(ConvertToString(address, System.Globalization.CultureInfo.InvariantCulture)));
              urlBuilder_.Replace("{asset-id}", System.Uri.EscapeDataString(ConvertToString(assetId, System.Globalization.CultureInfo.InvariantCulture)));
              if (format != null)
              {
                     urlBuilder_.Append(System.Uri.EscapeDataString("format") + "=").Append(System.Uri.EscapeDataString(ConvertToString(format, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
              }
              urlBuilder_.Length--;
              var client_ = _httpClient;
              var disposeClient_ = false;
              try
              {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                     request_.Method = new System.Net.Http.HttpMethod("GET");
                     request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);

                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if (response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach (var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if (status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponseAsync<AccountAssetResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                            if (objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        //Algorand Generator cannot distinguish between response codes
                        {
                            var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                            if (objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            throw new ApiException<ErrorResponse>("Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                        }
                    }
                    finally
                    {
                        if (disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }

       }


       

       /// <summary>Given a specific account public key and application ID, this call returns the
/// account's application local state and global state (AppLocalState and AppParams,
/// if either exists). Global state will only be returned if the provided address is
/// the application's creator.
       /// </summary>
       /// <param name="format">Configures whether the response object is JSON or MessagePack encoded.</param>
       /// <param name="address">An account public key</param>
       /// <param name="application-id">An application identifier</param>
       /// <exception cref="ApiException">A server side error occurred.</exception>
       public System.Threading.Tasks.Task<AccountApplicationResponse> AccountApplicationInformationAsync(string address, ulong applicationId,  Format? format)
       {
              return AccountApplicationInformationAsync(address, applicationId, format, System.Threading.CancellationToken.None);
       }

       /// <summary>>Given a specific account public key and application ID, this call returns the
/// account's application local state and global state (AppLocalState and AppParams,
/// if either exists). Global state will only be returned if the provided address is
/// the application's creator.
       /// </summary>
       /// <param name="format">Configures whether the response object is JSON or MessagePack encoded.</param>
       /// <param name="address">An account public key</param>
       /// <param name="application-id">An application identifier</param>
       /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
       /// <exception cref="ApiException<ErrorResponse>">A server side error occurred.</exception>
       public async System.Threading.Tasks.Task<AccountApplicationResponse> AccountApplicationInformationAsync(string address, ulong applicationId,  Format? format, System.Threading.CancellationToken cancellationToken)
       {
              if (address == null) throw new System.ArgumentNullException("address");
              if (applicationId == null) throw new System.ArgumentNullException("applicationId");
              var urlBuilder_ = new System.Text.StringBuilder();
              urlBuilder_.Append("v2/accounts/{address}/applications/{application-id}?");
              urlBuilder_.Replace("{address}", System.Uri.EscapeDataString(ConvertToString(address, System.Globalization.CultureInfo.InvariantCulture)));
              urlBuilder_.Replace("{application-id}", System.Uri.EscapeDataString(ConvertToString(applicationId, System.Globalization.CultureInfo.InvariantCulture)));
              if (format != null)
              {
                     urlBuilder_.Append(System.Uri.EscapeDataString("format") + "=").Append(System.Uri.EscapeDataString(ConvertToString(format, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
              }
              urlBuilder_.Length--;
              var client_ = _httpClient;
              var disposeClient_ = false;
              try
              {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                     request_.Method = new System.Net.Http.HttpMethod("GET");
                     request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);

                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if (response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach (var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if (status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponseAsync<AccountApplicationResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                            if (objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        //Algorand Generator cannot distinguish between response codes
                        {
                            var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                            if (objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            throw new ApiException<ErrorResponse>("Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                        }
                    }
                    finally
                    {
                        if (disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }

       }


       

       /// <summary>Get the list of pending transactions by address, sorted by priority, in
/// decreasing order, truncated at the end at MAX. If MAX = 0, returns all pending
/// transactions.
       /// </summary>
       /// <param name="format">Configures whether the response object is JSON or MessagePack encoded.</param>
       /// <param name="max">Truncated number of transactions to display. If max=0, returns all pending txns.</param>
       /// <param name="address">An account public key</param>
       /// <exception cref="ApiException">A server side error occurred.</exception>
       public System.Threading.Tasks.Task<PendingTransactions> GetPendingTransactionsByAddressAsync(string address,  Format? format, ulong? max)
       {
              return GetPendingTransactionsByAddressAsync(address, format, max, System.Threading.CancellationToken.None);
       }

       /// <summary>>Get the list of pending transactions by address, sorted by priority, in
/// decreasing order, truncated at the end at MAX. If MAX = 0, returns all pending
/// transactions.
       /// </summary>
       /// <param name="format">Configures whether the response object is JSON or MessagePack encoded.</param>
       /// <param name="max">Truncated number of transactions to display. If max=0, returns all pending txns.</param>
       /// <param name="address">An account public key</param>
       /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
       /// <exception cref="ApiException<ErrorResponse>">A server side error occurred.</exception>
       public async System.Threading.Tasks.Task<PendingTransactions> GetPendingTransactionsByAddressAsync(string address,  Format? format, ulong? max, System.Threading.CancellationToken cancellationToken)
       {
              if (address == null) throw new System.ArgumentNullException("address");
              var urlBuilder_ = new System.Text.StringBuilder();
              urlBuilder_.Append("v2/accounts/{address}/transactions/pending?");
              urlBuilder_.Replace("{address}", System.Uri.EscapeDataString(ConvertToString(address, System.Globalization.CultureInfo.InvariantCulture)));
              if (format != null)
              {
                     urlBuilder_.Append(System.Uri.EscapeDataString("format") + "=").Append(System.Uri.EscapeDataString(ConvertToString(format, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
              }
              if (max != null)
              {
                     urlBuilder_.Append(System.Uri.EscapeDataString("max") + "=").Append(System.Uri.EscapeDataString(ConvertToString(max, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
              }
              urlBuilder_.Length--;
              var client_ = _httpClient;
              var disposeClient_ = false;
              try
              {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                     request_.Method = new System.Net.Http.HttpMethod("GET");
                     request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);

                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if (response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach (var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if (status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponseAsync<PendingTransactions>(response_, headers_, cancellationToken).ConfigureAwait(false);
                            if (objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        //Algorand Generator cannot distinguish between response codes
                        {
                            var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                            if (objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            throw new ApiException<ErrorResponse>("Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                        }
                    }
                    finally
                    {
                        if (disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }

       }


       

       /// <summary>Get the block for the given round.
       /// </summary>
       /// <param name="format">Configures whether the response object is JSON or MessagePack encoded.</param>
       /// <param name="round">The round from which to fetch block information.</param>
       /// <exception cref="ApiException">A server side error occurred.</exception>
       public System.Threading.Tasks.Task<CertifiedBlock> GetBlockAsync(ulong round,  Format? format)
       {
              return GetBlockAsync(round, format, System.Threading.CancellationToken.None);
       }

       /// <summary>>Get the block for the given round.
       /// </summary>
       /// <param name="format">Configures whether the response object is JSON or MessagePack encoded.</param>
       /// <param name="round">The round from which to fetch block information.</param>
       /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
       /// <exception cref="ApiException<ErrorResponse>">A server side error occurred.</exception>
       public async System.Threading.Tasks.Task<CertifiedBlock> GetBlockAsync(ulong round,  Format? format, System.Threading.CancellationToken cancellationToken)
       {
              if (round == null) throw new System.ArgumentNullException("round");
              var urlBuilder_ = new System.Text.StringBuilder();
              urlBuilder_.Append("v2/blocks/{round}?");
              urlBuilder_.Replace("{round}", System.Uri.EscapeDataString(ConvertToString(round, System.Globalization.CultureInfo.InvariantCulture)));
              if (format != null)
              {
                     urlBuilder_.Append(System.Uri.EscapeDataString("format") + "=").Append(System.Uri.EscapeDataString(ConvertToString(format, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
              }
              urlBuilder_.Length--;
              var client_ = _httpClient;
              var disposeClient_ = false;
              try
              {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                     request_.Method = new System.Net.Http.HttpMethod("GET");
                     request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);

                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if (response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach (var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if (status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponseAsync<CertifiedBlock>(response_, headers_, cancellationToken).ConfigureAwait(false);
                            if (objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        //Algorand Generator cannot distinguish between response codes
                        {
                            var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                            if (objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            throw new ApiException<ErrorResponse>("Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                        }
                    }
                    finally
                    {
                        if (disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }

       }


       

       /// <summary>Get a Merkle proof for a transaction in a block.
       /// </summary>
       /// <param name="format">Configures whether the response object is JSON or MessagePack encoded.</param>
       /// <param name="round">The round in which the transaction appears.</param>
       /// <param name="txid">The transaction ID for which to generate a proof.</param>
       /// <exception cref="ApiException">A server side error occurred.</exception>
       public System.Threading.Tasks.Task<ProofResponse> GetProofAsync(ulong round, string txid,  Format? format)
       {
              return GetProofAsync(round, txid, format, System.Threading.CancellationToken.None);
       }

       /// <summary>>Get a Merkle proof for a transaction in a block.
       /// </summary>
       /// <param name="format">Configures whether the response object is JSON or MessagePack encoded.</param>
       /// <param name="round">The round in which the transaction appears.</param>
       /// <param name="txid">The transaction ID for which to generate a proof.</param>
       /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
       /// <exception cref="ApiException<ErrorResponse>">A server side error occurred.</exception>
       public async System.Threading.Tasks.Task<ProofResponse> GetProofAsync(ulong round, string txid,  Format? format, System.Threading.CancellationToken cancellationToken)
       {
              if (round == null) throw new System.ArgumentNullException("round");
              if (txid == null) throw new System.ArgumentNullException("txid");
              var urlBuilder_ = new System.Text.StringBuilder();
              urlBuilder_.Append("v2/blocks/{round}/transactions/{txid}/proof?");
              urlBuilder_.Replace("{round}", System.Uri.EscapeDataString(ConvertToString(round, System.Globalization.CultureInfo.InvariantCulture)));
              urlBuilder_.Replace("{txid}", System.Uri.EscapeDataString(ConvertToString(txid, System.Globalization.CultureInfo.InvariantCulture)));
              if (format != null)
              {
                     urlBuilder_.Append(System.Uri.EscapeDataString("format") + "=").Append(System.Uri.EscapeDataString(ConvertToString(format, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
              }
              urlBuilder_.Length--;
              var client_ = _httpClient;
              var disposeClient_ = false;
              try
              {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                     request_.Method = new System.Net.Http.HttpMethod("GET");
                     request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);

                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if (response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach (var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if (status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponseAsync<ProofResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                            if (objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        //Algorand Generator cannot distinguish between response codes
                        {
                            var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                            if (objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            throw new ApiException<ErrorResponse>("Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                        }
                    }
                    finally
                    {
                        if (disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }

       }


       

       /// <summary>Get the current supply reported by the ledger.
       /// </summary>
       /// <exception cref="ApiException">A server side error occurred.</exception>
       public System.Threading.Tasks.Task<SupplyResponse> GetSupplyAsync()
       {
              return GetSupplyAsync(System.Threading.CancellationToken.None);
       }

       /// <summary>>Get the current supply reported by the ledger.
       /// </summary>
       /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
       /// <exception cref="ApiException<ErrorResponse>">A server side error occurred.</exception>
       public async System.Threading.Tasks.Task<SupplyResponse> GetSupplyAsync(System.Threading.CancellationToken cancellationToken)
       {
              var urlBuilder_ = new System.Text.StringBuilder();
              urlBuilder_.Append("v2/ledger/supply");
              var client_ = _httpClient;
              var disposeClient_ = false;
              try
              {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                     request_.Method = new System.Net.Http.HttpMethod("GET");
                     request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);

                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if (response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach (var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if (status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponseAsync<SupplyResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                            if (objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        //Algorand Generator cannot distinguish between response codes
                        {
                            var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                            if (objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            throw new ApiException<ErrorResponse>("Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                        }
                    }
                    finally
                    {
                        if (disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }

       }


       

       /// <summary>Gets the current node status.
       /// </summary>
       /// <exception cref="ApiException">A server side error occurred.</exception>
       public System.Threading.Tasks.Task<NodeStatusResponse> GetStatusAsync()
       {
              return GetStatusAsync(System.Threading.CancellationToken.None);
       }

       /// <summary>>Gets the current node status.
       /// </summary>
       /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
       /// <exception cref="ApiException<ErrorResponse>">A server side error occurred.</exception>
       public async System.Threading.Tasks.Task<NodeStatusResponse> GetStatusAsync(System.Threading.CancellationToken cancellationToken)
       {
              var urlBuilder_ = new System.Text.StringBuilder();
              urlBuilder_.Append("v2/status");
              var client_ = _httpClient;
              var disposeClient_ = false;
              try
              {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                     request_.Method = new System.Net.Http.HttpMethod("GET");
                     request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);

                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if (response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach (var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if (status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponseAsync<NodeStatusResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                            if (objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        //Algorand Generator cannot distinguish between response codes
                        {
                            var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                            if (objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            throw new ApiException<ErrorResponse>("Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                        }
                    }
                    finally
                    {
                        if (disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }

       }


       

       /// <summary>Waits for a block to appear after round {round} and returns the node's status at
/// the time.
       /// </summary>
       /// <param name="round">The round to wait until returning status</param>
       /// <exception cref="ApiException">A server side error occurred.</exception>
       public System.Threading.Tasks.Task<NodeStatusResponse> WaitForBlockAsync(ulong round)
       {
              return WaitForBlockAsync(round, System.Threading.CancellationToken.None);
       }

       /// <summary>>Waits for a block to appear after round {round} and returns the node's status at
/// the time.
       /// </summary>
       /// <param name="round">The round to wait until returning status</param>
       /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
       /// <exception cref="ApiException<ErrorResponse>">A server side error occurred.</exception>
       public async System.Threading.Tasks.Task<NodeStatusResponse> WaitForBlockAsync(ulong round, System.Threading.CancellationToken cancellationToken)
       {
              if (round == null) throw new System.ArgumentNullException("round");
              var urlBuilder_ = new System.Text.StringBuilder();
              urlBuilder_.Append("v2/status/wait-for-block-after/{round}");
              urlBuilder_.Replace("{round}", System.Uri.EscapeDataString(ConvertToString(round, System.Globalization.CultureInfo.InvariantCulture)));
              var client_ = _httpClient;
              var disposeClient_ = false;
              try
              {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                     request_.Method = new System.Net.Http.HttpMethod("GET");
                     request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);

                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if (response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach (var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if (status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponseAsync<NodeStatusResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                            if (objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        //Algorand Generator cannot distinguish between response codes
                        {
                            var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                            if (objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            throw new ApiException<ErrorResponse>("Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                        }
                    }
                    finally
                    {
                        if (disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }

       }


       

       /// <summary>Broadcasts a raw transaction to the network.
       /// </summary>
       /// <param name="rawtxn">The byte encoded signed transaction to broadcast to network</param>
       /// <exception cref="ApiException">A server side error occurred.</exception>
       public System.Threading.Tasks.Task<PostTransactionsResponse> TransactionsAsync(List<SignedTransaction> rawtxn)
       {
              return TransactionsAsync(rawtxn, System.Threading.CancellationToken.None);
       }

       /// <summary>>Broadcasts a raw transaction to the network.
       /// </summary>
       /// <param name="rawtxn">The byte encoded signed transaction to broadcast to network</param>
       /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
       /// <exception cref="ApiException<ErrorResponse>">A server side error occurred.</exception>
       public async System.Threading.Tasks.Task<PostTransactionsResponse> TransactionsAsync(List<SignedTransaction> rawtxn, System.Threading.CancellationToken cancellationToken)
       {
              if (rawtxn == null) throw new System.ArgumentNullException("rawtxn");
              var urlBuilder_ = new System.Text.StringBuilder();
              urlBuilder_.Append("v2/transactions");
              var client_ = _httpClient;
              var disposeClient_ = false;
              try
              {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                     request_.Method = new System.Net.Http.HttpMethod("POST");
                     request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));
                     System.Net.Http.ByteArrayContent content_ = new System.Net.Http.ByteArrayContent(Encoder.EncodeToMsgPackOrdered(rawtxn));
                     content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/msgpack");
                     request_.Content = content_;

                    PrepareRequest(client_, request_, urlBuilder_);

                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if (response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach (var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if (status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponseAsync<PostTransactionsResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                            if (objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        //Algorand Generator cannot distinguish between response codes
                        {
                            var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                            if (objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            throw new ApiException<ErrorResponse>("Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                        }
                    }
                    finally
                    {
                        if (disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }

       }


       

       /// <summary>Get parameters for constructing a new transaction
       /// </summary>
       /// <exception cref="ApiException">A server side error occurred.</exception>
       public System.Threading.Tasks.Task<TransactionParametersResponse> TransactionParamsAsync()
       {
              return TransactionParamsAsync(System.Threading.CancellationToken.None);
       }

       /// <summary>>Get parameters for constructing a new transaction
       /// </summary>
       /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
       /// <exception cref="ApiException<ErrorResponse>">A server side error occurred.</exception>
       public async System.Threading.Tasks.Task<TransactionParametersResponse> TransactionParamsAsync(System.Threading.CancellationToken cancellationToken)
       {
              var urlBuilder_ = new System.Text.StringBuilder();
              urlBuilder_.Append("v2/transactions/params");
              var client_ = _httpClient;
              var disposeClient_ = false;
              try
              {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                     request_.Method = new System.Net.Http.HttpMethod("GET");
                     request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);

                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if (response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach (var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if (status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponseAsync<TransactionParametersResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                            if (objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        //Algorand Generator cannot distinguish between response codes
                        {
                            var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                            if (objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            throw new ApiException<ErrorResponse>("Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                        }
                    }
                    finally
                    {
                        if (disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }

       }


       

       /// <summary>Get the list of pending transactions, sorted by priority, in decreasing order,
/// truncated at the end at MAX. If MAX = 0, returns all pending transactions.
       /// </summary>
       /// <param name="format">Configures whether the response object is JSON or MessagePack encoded.</param>
       /// <param name="max">Truncated number of transactions to display. If max=0, returns all pending txns.</param>
       /// <exception cref="ApiException">A server side error occurred.</exception>
       public System.Threading.Tasks.Task<PendingTransactions> GetPendingTransactionsAsync( Format? format, ulong? max)
       {
              return GetPendingTransactionsAsync(format, max, System.Threading.CancellationToken.None);
       }

       /// <summary>>Get the list of pending transactions, sorted by priority, in decreasing order,
/// truncated at the end at MAX. If MAX = 0, returns all pending transactions.
       /// </summary>
       /// <param name="format">Configures whether the response object is JSON or MessagePack encoded.</param>
       /// <param name="max">Truncated number of transactions to display. If max=0, returns all pending txns.</param>
       /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
       /// <exception cref="ApiException<ErrorResponse>">A server side error occurred.</exception>
       public async System.Threading.Tasks.Task<PendingTransactions> GetPendingTransactionsAsync( Format? format, ulong? max, System.Threading.CancellationToken cancellationToken)
       {
              var urlBuilder_ = new System.Text.StringBuilder();
              urlBuilder_.Append("v2/transactions/pending?");
              if (format != null)
              {
                     urlBuilder_.Append(System.Uri.EscapeDataString("format") + "=").Append(System.Uri.EscapeDataString(ConvertToString(format, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
              }
              if (max != null)
              {
                     urlBuilder_.Append(System.Uri.EscapeDataString("max") + "=").Append(System.Uri.EscapeDataString(ConvertToString(max, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
              }
              urlBuilder_.Length--;
              var client_ = _httpClient;
              var disposeClient_ = false;
              try
              {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                     request_.Method = new System.Net.Http.HttpMethod("GET");
                     request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);

                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if (response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach (var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if (status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponseAsync<PendingTransactions>(response_, headers_, cancellationToken).ConfigureAwait(false);
                            if (objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        //Algorand Generator cannot distinguish between response codes
                        {
                            var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                            if (objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            throw new ApiException<ErrorResponse>("Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                        }
                    }
                    finally
                    {
                        if (disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }

       }


       

       /// <summary>Given a transaction ID of a recently submitted transaction, it returns
/// information about it. There are several cases when this might succeed:
/// - transaction committed (committed round > 0)
/// - transaction still in the pool (committed round = 0, pool error = "")
/// - transaction removed from pool due to error (committed round = 0, pool error !=
/// "")
/// Or the transaction may have happened sufficiently long ago that the node no
/// longer remembers it, and this will return an error.
       /// </summary>
       /// <param name="format">Configures whether the response object is JSON or MessagePack encoded.</param>
       /// <param name="txid">A transaction ID</param>
       /// <exception cref="ApiException">A server side error occurred.</exception>
       public System.Threading.Tasks.Task<IReturnableTransaction> PendingTransactionInformationAsync(string txid,  Format? format)
       {
              return PendingTransactionInformationAsync(txid, format, System.Threading.CancellationToken.None);
       }

       /// <summary>>Given a transaction ID of a recently submitted transaction, it returns
/// information about it. There are several cases when this might succeed:
/// - transaction committed (committed round > 0)
/// - transaction still in the pool (committed round = 0, pool error = "")
/// - transaction removed from pool due to error (committed round = 0, pool error !=
/// "")
/// Or the transaction may have happened sufficiently long ago that the node no
/// longer remembers it, and this will return an error.
       /// </summary>
       /// <param name="format">Configures whether the response object is JSON or MessagePack encoded.</param>
       /// <param name="txid">A transaction ID</param>
       /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
       /// <exception cref="ApiException<ErrorResponse>">A server side error occurred.</exception>
       public async System.Threading.Tasks.Task<IReturnableTransaction> PendingTransactionInformationAsync(string txid,  Format? format, System.Threading.CancellationToken cancellationToken)
       {
              if (txid == null) throw new System.ArgumentNullException("txid");
              var urlBuilder_ = new System.Text.StringBuilder();
              urlBuilder_.Append("v2/transactions/pending/{txid}?");
              urlBuilder_.Replace("{txid}", System.Uri.EscapeDataString(ConvertToString(txid, System.Globalization.CultureInfo.InvariantCulture)));
              if (format != null)
              {
                     urlBuilder_.Append(System.Uri.EscapeDataString("format") + "=").Append(System.Uri.EscapeDataString(ConvertToString(format, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
              }
              urlBuilder_.Length--;
              var client_ = _httpClient;
              var disposeClient_ = false;
              try
              {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                     request_.Method = new System.Net.Http.HttpMethod("GET");
                     request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);

                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if (response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach (var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if (status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponseAsync<IReturnableTransaction>(response_, headers_, cancellationToken).ConfigureAwait(false);
                            if (objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        //Algorand Generator cannot distinguish between response codes
                        {
                            var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                            if (objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            throw new ApiException<ErrorResponse>("Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                        }
                    }
                    finally
                    {
                        if (disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }

       }


       

       /// <summary>Given a application ID, it returns application information including creator,
/// approval and clear programs, global and local schemas, and global state.
       /// </summary>
       /// <param name="application-id">An application identifier</param>
       /// <exception cref="ApiException">A server side error occurred.</exception>
       public System.Threading.Tasks.Task<Application> GetApplicationByIDAsync(ulong applicationId)
       {
              return GetApplicationByIDAsync(applicationId, System.Threading.CancellationToken.None);
       }

       /// <summary>>Given a application ID, it returns application information including creator,
/// approval and clear programs, global and local schemas, and global state.
       /// </summary>
       /// <param name="application-id">An application identifier</param>
       /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
       /// <exception cref="ApiException<ErrorResponse>">A server side error occurred.</exception>
       public async System.Threading.Tasks.Task<Application> GetApplicationByIDAsync(ulong applicationId, System.Threading.CancellationToken cancellationToken)
       {
              if (applicationId == null) throw new System.ArgumentNullException("applicationId");
              var urlBuilder_ = new System.Text.StringBuilder();
              urlBuilder_.Append("v2/applications/{application-id}");
              urlBuilder_.Replace("{application-id}", System.Uri.EscapeDataString(ConvertToString(applicationId, System.Globalization.CultureInfo.InvariantCulture)));
              var client_ = _httpClient;
              var disposeClient_ = false;
              try
              {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                     request_.Method = new System.Net.Http.HttpMethod("GET");
                     request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);

                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if (response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach (var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if (status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponseAsync<Application>(response_, headers_, cancellationToken).ConfigureAwait(false);
                            if (objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        //Algorand Generator cannot distinguish between response codes
                        {
                            var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                            if (objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            throw new ApiException<ErrorResponse>("Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                        }
                    }
                    finally
                    {
                        if (disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }

       }


       

       /// <summary>Given a asset ID, it returns asset information including creator, name, total
/// supply and special addresses.
       /// </summary>
       /// <param name="asset-id">An asset identifier</param>
       /// <exception cref="ApiException">A server side error occurred.</exception>
       public System.Threading.Tasks.Task<Asset> GetAssetByIDAsync(ulong assetId)
       {
              return GetAssetByIDAsync(assetId, System.Threading.CancellationToken.None);
       }

       /// <summary>>Given a asset ID, it returns asset information including creator, name, total
/// supply and special addresses.
       /// </summary>
       /// <param name="asset-id">An asset identifier</param>
       /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
       /// <exception cref="ApiException<ErrorResponse>">A server side error occurred.</exception>
       public async System.Threading.Tasks.Task<Asset> GetAssetByIDAsync(ulong assetId, System.Threading.CancellationToken cancellationToken)
       {
              if (assetId == null) throw new System.ArgumentNullException("assetId");
              var urlBuilder_ = new System.Text.StringBuilder();
              urlBuilder_.Append("v2/assets/{asset-id}");
              urlBuilder_.Replace("{asset-id}", System.Uri.EscapeDataString(ConvertToString(assetId, System.Globalization.CultureInfo.InvariantCulture)));
              var client_ = _httpClient;
              var disposeClient_ = false;
              try
              {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                     request_.Method = new System.Net.Http.HttpMethod("GET");
                     request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);

                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if (response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach (var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if (status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponseAsync<Asset>(response_, headers_, cancellationToken).ConfigureAwait(false);
                            if (objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        //Algorand Generator cannot distinguish between response codes
                        {
                            var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                            if (objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            throw new ApiException<ErrorResponse>("Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                        }
                    }
                    finally
                    {
                        if (disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }

       }


       

       /// <summary>Given TEAL source code in plain text, return base64 encoded program bytes and
/// base32 SHA512_256 hash of program bytes (Address style). This endpoint is only
/// enabled when a node's configuration file sets EnableDeveloperAPI to true.
       /// </summary>
       /// <param name="source">TEAL source code to be compiled</param>
       /// <exception cref="ApiException">A server side error occurred.</exception>
       public System.Threading.Tasks.Task<CompileResponse> TealCompileAsync(System.IO.Stream source)
       {
              return TealCompileAsync(source, System.Threading.CancellationToken.None);
       }

       /// <summary>>Given TEAL source code in plain text, return base64 encoded program bytes and
/// base32 SHA512_256 hash of program bytes (Address style). This endpoint is only
/// enabled when a node's configuration file sets EnableDeveloperAPI to true.
       /// </summary>
       /// <param name="source">TEAL source code to be compiled</param>
       /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
       /// <exception cref="ApiException<ErrorResponse>">A server side error occurred.</exception>
       public async System.Threading.Tasks.Task<CompileResponse> TealCompileAsync(System.IO.Stream source, System.Threading.CancellationToken cancellationToken)
       {
              if (source == null) throw new System.ArgumentNullException("source");
              var urlBuilder_ = new System.Text.StringBuilder();
              urlBuilder_.Append("v2/teal/compile");
              var client_ = _httpClient;
              var disposeClient_ = false;
              try
              {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                     request_.Method = new System.Net.Http.HttpMethod("POST");
                     request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));
                     var content_ = new System.Net.Http.StreamContent(source);
                     content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("text/plain");
                     request_.Content = content_;

                    PrepareRequest(client_, request_, urlBuilder_);

                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if (response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach (var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if (status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponseAsync<CompileResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                            if (objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        //Algorand Generator cannot distinguish between response codes
                        {
                            var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                            if (objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            throw new ApiException<ErrorResponse>("Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                        }
                    }
                    finally
                    {
                        if (disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }

       }


       

       /// <summary>Executes TEAL program(s) in context and returns debugging information about the
/// execution. This endpoint is only enabled when a node's configuration file sets
/// EnableDeveloperAPI to true.
       /// </summary>
       /// <param name="request">Transaction (or group) and any accompanying state-simulation data.</param>
       /// <exception cref="ApiException">A server side error occurred.</exception>
       public System.Threading.Tasks.Task<DryrunResponse> TealDryrunAsync(DryrunRequest request)
       {
              return TealDryrunAsync(request, System.Threading.CancellationToken.None);
       }

       /// <summary>>Executes TEAL program(s) in context and returns debugging information about the
/// execution. This endpoint is only enabled when a node's configuration file sets
/// EnableDeveloperAPI to true.
       /// </summary>
       /// <param name="request">Transaction (or group) and any accompanying state-simulation data.</param>
       /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
       /// <exception cref="ApiException<ErrorResponse>">A server side error occurred.</exception>
       public async System.Threading.Tasks.Task<DryrunResponse> TealDryrunAsync(DryrunRequest request, System.Threading.CancellationToken cancellationToken)
       {
              var urlBuilder_ = new System.Text.StringBuilder();
              urlBuilder_.Append("v2/teal/dryrun");
              var client_ = _httpClient;
              var disposeClient_ = false;
              try
              {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                     request_.Method = new System.Net.Http.HttpMethod("POST");
                     request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));
                     System.Net.Http.ByteArrayContent content_ = new System.Net.Http.ByteArrayContent(Encoder.EncodeToMsgPackOrdered(request));
                     content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/msgpack");
                     request_.Content = content_;

                    PrepareRequest(client_, request_, urlBuilder_);

                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if (response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach (var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if (status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponseAsync<DryrunResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                            if (objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        //Algorand Generator cannot distinguish between response codes
                        {
                            var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                            if (objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            throw new ApiException<ErrorResponse>("Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                        }
                    }
                    finally
                    {
                        if (disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }

       }



       protected struct ObjectResponseResult<T>
       {
       public ObjectResponseResult(T responseObject, string responseText)
       {
              this.Object = responseObject;
              this.Text = responseText;
       }

       public T Object { get; }

       public string Text { get; }
       }

       public bool ReadResponseAsString { get; set; }

       protected virtual async System.Threading.Tasks.Task<ObjectResponseResult<T>> ReadObjectResponseAsync<T>(System.Net.Http.HttpResponseMessage response, System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> headers, System.Threading.CancellationToken cancellationToken)
       {
       if (response == null || response.Content == null)
       {
              return new ObjectResponseResult<T>(default(T), string.Empty);
       }

       if (ReadResponseAsString)
       {
              string responseText;
                if (response.Content.Headers.ContentType.MediaType == "application/msgpack")
                {
                    using (MessagePackReader reader = new MessagePackReader(await response.Content.ReadAsStreamAsync().ConfigureAwait(false)))
                    {
                        responseText = reader.ReadAsString();
                    }
                }
                else
                {
                    responseText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                }
                
              try
              {
                     var typedBody = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(responseText, JsonSerializerSettings);
                     return new ObjectResponseResult<T>(typedBody, responseText);
              }
              catch (Newtonsoft.Json.JsonException exception)
              {
                     var message = "Could not deserialize the response body string as " + typeof(T).FullName + ".";
                     throw new ApiException(message, (int)response.StatusCode, responseText, headers, exception);
              }
       }
       else
       {
                 try
                {
                    if (response.Content.Headers.ContentType.MediaType == "application/msgpack")
                    {
                        using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                        using (var reader = new MessagePackReader(responseStream))
                        {
                            var serializer = Newtonsoft.Json.JsonSerializer.Create(JsonSerializerSettings);
                            var typedBody = serializer.Deserialize<T>(reader);
                            return new ObjectResponseResult<T>(typedBody, string.Empty);
                        }
                    }
                    else
                    {
                        using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                        using (var streamReader = new System.IO.StreamReader(responseStream))
                        using (var jsonTextReader = new Newtonsoft.Json.JsonTextReader(streamReader))
                        {
                            var serializer = Newtonsoft.Json.JsonSerializer.Create(JsonSerializerSettings);
                            var typedBody = serializer.Deserialize<T>(jsonTextReader);
                            return new ObjectResponseResult<T>(typedBody, string.Empty);
                        }
                    }
                                      
                }
              catch (Newtonsoft.Json.JsonException exception)
              {
              var message = "Could not deserialize the response body stream as " + typeof(T).FullName + ".";
              throw new ApiException(message, (int)response.StatusCode, string.Empty, headers, exception);
              }
       }
       }

       private string ConvertToString(object value, System.Globalization.CultureInfo cultureInfo)
       {
              if (value == null)
              {
                     return "";
              }

              if (value is System.Enum)
              {
                     var name = System.Enum.GetName(value.GetType(), value);
                     if (name != null)
                     {
                     var field = System.Reflection.IntrospectionExtensions.GetTypeInfo(value.GetType()).GetDeclaredField(name);
                     if (field != null)
                     {
                            var attribute = System.Reflection.CustomAttributeExtensions.GetCustomAttribute(field, typeof(System.Runtime.Serialization.EnumMemberAttribute))
                            as System.Runtime.Serialization.EnumMemberAttribute;
                            if (attribute != null)
                            {
                            return attribute.Value != null ? attribute.Value : name;
                            }
                     }

                     var converted = System.Convert.ToString(System.Convert.ChangeType(value, System.Enum.GetUnderlyingType(value.GetType()), cultureInfo));
                     return converted == null ? string.Empty : converted;
                     }
              }
              else if (value is bool)
              {
                     return System.Convert.ToString((bool)value, cultureInfo).ToLowerInvariant();
              }
              else if (value is byte[])
              {
                     return System.Convert.ToBase64String((byte[])value);
              }
              else if (value.GetType().IsArray)
              {
                     var array = System.Linq.Enumerable.OfType<object>((System.Array)value);
                     return string.Join(",", System.Linq.Enumerable.Select(array, o => ConvertToString(o, cultureInfo)));
              }

              var result = System.Convert.ToString(value, cultureInfo);
              return result == null ? "" : result;
              
       }

    }

}
