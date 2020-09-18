/* 
 * Indexer
 *
 * Algorand ledger analytics API.
 *
 * OpenAPI spec version: 2.0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using SwaggerDateConverter = Algorand.V2.Indexer.Client.SwaggerDateConverter;

namespace Algorand.V2.Indexer.Model
{
    /// <summary>
    /// Fields for application transactions.  Definition: data/transactions/application.go : ApplicationCallTxnFields
    /// </summary>
    [DataContract]
        public partial class TransactionApplication :  IEquatable<TransactionApplication>, IValidatableObject
    {
        /// <summary>
        /// Gets or Sets OnCompletion
        /// </summary>
        [DataMember(Name="on-completion", EmitDefaultValue=false)]
        public OnCompletion OnCompletion { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionApplication" /> class.
        /// </summary>
        /// <param name="accounts">\\[apat\\] List of accounts in addition to the sender that may be accessed from the application&#x27;s approval-program and clear-state-program..</param>
        /// <param name="applicationArgs">\\[apaa\\] transaction specific arguments accessed from the application&#x27;s approval-program and clear-state-program..</param>
        /// <param name="applicationId">\\[apid\\] ID of the application being configured or empty if creating. (required).</param>
        /// <param name="approvalProgram">\\[apap\\] Logic executed for every application transaction, except when on-completion is set to \&quot;clear\&quot;. It can read and write global state for the application, as well as account-specific local state. Approval programs may reject the transaction..</param>
        /// <param name="clearStateProgram">\\[apsu\\] Logic executed for application transactions with on-completion set to \&quot;clear\&quot;. It can read and write global state for the application, as well as account-specific local state. Clear state programs cannot reject the transaction..</param>
        /// <param name="foreignApps">\\[apfa\\] Lists the applications in addition to the application-id whose global states may be accessed by this application&#x27;s approval-program and clear-state-program. The access is read-only..</param>
        /// <param name="foreignAssets">\\[apas\\] lists the assets whose parameters may be accessed by this application&#x27;s ApprovalProgram and ClearStateProgram. The access is read-only..</param>
        /// <param name="globalStateSchema">globalStateSchema.</param>
        /// <param name="localStateSchema">localStateSchema.</param>
        /// <param name="onCompletion">onCompletion (required).</param>
        public TransactionApplication(List<string> accounts = default(List<string>), List<string> applicationArgs = default(List<string>), int? applicationId = default(int?), byte[] approvalProgram = default(byte[]), byte[] clearStateProgram = default(byte[]), List<int?> foreignApps = default(List<int?>), List<int?> foreignAssets = default(List<int?>), StateSchema globalStateSchema = default(StateSchema), StateSchema localStateSchema = default(StateSchema), OnCompletion onCompletion = default(OnCompletion))
        {
            // to ensure "applicationId" is required (not null)
            if (applicationId == null)
            {
                throw new InvalidDataException("applicationId is a required property for TransactionApplication and cannot be null");
            }
            else
            {
                this.ApplicationId = applicationId;
            }
            // to ensure "onCompletion" is required (not null)
            if (onCompletion == null)
            {
                throw new InvalidDataException("onCompletion is a required property for TransactionApplication and cannot be null");
            }
            else
            {
                this.OnCompletion = onCompletion;
            }
            this.Accounts = accounts;
            this.ApplicationArgs = applicationArgs;
            this.ApprovalProgram = approvalProgram;
            this.ClearStateProgram = clearStateProgram;
            this.ForeignApps = foreignApps;
            this.ForeignAssets = foreignAssets;
            this.GlobalStateSchema = globalStateSchema;
            this.LocalStateSchema = localStateSchema;
        }
        
        /// <summary>
        /// \\[apat\\] List of accounts in addition to the sender that may be accessed from the application&#x27;s approval-program and clear-state-program.
        /// </summary>
        /// <value>\\[apat\\] List of accounts in addition to the sender that may be accessed from the application&#x27;s approval-program and clear-state-program.</value>
        [DataMember(Name="accounts", EmitDefaultValue=false)]
        public List<string> Accounts { get; set; }

        /// <summary>
        /// \\[apaa\\] transaction specific arguments accessed from the application&#x27;s approval-program and clear-state-program.
        /// </summary>
        /// <value>\\[apaa\\] transaction specific arguments accessed from the application&#x27;s approval-program and clear-state-program.</value>
        [DataMember(Name="application-args", EmitDefaultValue=false)]
        public List<string> ApplicationArgs { get; set; }

        /// <summary>
        /// \\[apid\\] ID of the application being configured or empty if creating.
        /// </summary>
        /// <value>\\[apid\\] ID of the application being configured or empty if creating.</value>
        [DataMember(Name="application-id", EmitDefaultValue=false)]
        public int? ApplicationId { get; set; }

        /// <summary>
        /// \\[apap\\] Logic executed for every application transaction, except when on-completion is set to \&quot;clear\&quot;. It can read and write global state for the application, as well as account-specific local state. Approval programs may reject the transaction.
        /// </summary>
        /// <value>\\[apap\\] Logic executed for every application transaction, except when on-completion is set to \&quot;clear\&quot;. It can read and write global state for the application, as well as account-specific local state. Approval programs may reject the transaction.</value>
        [DataMember(Name="approval-program", EmitDefaultValue=false)]
        public byte[] ApprovalProgram { get; set; }

        /// <summary>
        /// \\[apsu\\] Logic executed for application transactions with on-completion set to \&quot;clear\&quot;. It can read and write global state for the application, as well as account-specific local state. Clear state programs cannot reject the transaction.
        /// </summary>
        /// <value>\\[apsu\\] Logic executed for application transactions with on-completion set to \&quot;clear\&quot;. It can read and write global state for the application, as well as account-specific local state. Clear state programs cannot reject the transaction.</value>
        [DataMember(Name="clear-state-program", EmitDefaultValue=false)]
        public byte[] ClearStateProgram { get; set; }

        /// <summary>
        /// \\[apfa\\] Lists the applications in addition to the application-id whose global states may be accessed by this application&#x27;s approval-program and clear-state-program. The access is read-only.
        /// </summary>
        /// <value>\\[apfa\\] Lists the applications in addition to the application-id whose global states may be accessed by this application&#x27;s approval-program and clear-state-program. The access is read-only.</value>
        [DataMember(Name="foreign-apps", EmitDefaultValue=false)]
        public List<int?> ForeignApps { get; set; }

        /// <summary>
        /// \\[apas\\] lists the assets whose parameters may be accessed by this application&#x27;s ApprovalProgram and ClearStateProgram. The access is read-only.
        /// </summary>
        /// <value>\\[apas\\] lists the assets whose parameters may be accessed by this application&#x27;s ApprovalProgram and ClearStateProgram. The access is read-only.</value>
        [DataMember(Name="foreign-assets", EmitDefaultValue=false)]
        public List<int?> ForeignAssets { get; set; }

        /// <summary>
        /// Gets or Sets GlobalStateSchema
        /// </summary>
        [DataMember(Name="global-state-schema", EmitDefaultValue=false)]
        public StateSchema GlobalStateSchema { get; set; }

        /// <summary>
        /// Gets or Sets LocalStateSchema
        /// </summary>
        [DataMember(Name="local-state-schema", EmitDefaultValue=false)]
        public StateSchema LocalStateSchema { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TransactionApplication {\n");
            sb.Append("  Accounts: ").Append(Accounts).Append("\n");
            sb.Append("  ApplicationArgs: ").Append(ApplicationArgs).Append("\n");
            sb.Append("  ApplicationId: ").Append(ApplicationId).Append("\n");
            sb.Append("  ApprovalProgram: ").Append(ApprovalProgram).Append("\n");
            sb.Append("  ClearStateProgram: ").Append(ClearStateProgram).Append("\n");
            sb.Append("  ForeignApps: ").Append(ForeignApps).Append("\n");
            sb.Append("  ForeignAssets: ").Append(ForeignAssets).Append("\n");
            sb.Append("  GlobalStateSchema: ").Append(GlobalStateSchema).Append("\n");
            sb.Append("  LocalStateSchema: ").Append(LocalStateSchema).Append("\n");
            sb.Append("  OnCompletion: ").Append(OnCompletion).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as TransactionApplication);
        }

        /// <summary>
        /// Returns true if TransactionApplication instances are equal
        /// </summary>
        /// <param name="input">Instance of TransactionApplication to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TransactionApplication input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Accounts == input.Accounts ||
                    this.Accounts != null &&
                    input.Accounts != null &&
                    this.Accounts.SequenceEqual(input.Accounts)
                ) && 
                (
                    this.ApplicationArgs == input.ApplicationArgs ||
                    this.ApplicationArgs != null &&
                    input.ApplicationArgs != null &&
                    this.ApplicationArgs.SequenceEqual(input.ApplicationArgs)
                ) && 
                (
                    this.ApplicationId == input.ApplicationId ||
                    (this.ApplicationId != null &&
                    this.ApplicationId.Equals(input.ApplicationId))
                ) && 
                (
                    this.ApprovalProgram == input.ApprovalProgram ||
                    (this.ApprovalProgram != null &&
                    this.ApprovalProgram.Equals(input.ApprovalProgram))
                ) && 
                (
                    this.ClearStateProgram == input.ClearStateProgram ||
                    (this.ClearStateProgram != null &&
                    this.ClearStateProgram.Equals(input.ClearStateProgram))
                ) && 
                (
                    this.ForeignApps == input.ForeignApps ||
                    this.ForeignApps != null &&
                    input.ForeignApps != null &&
                    this.ForeignApps.SequenceEqual(input.ForeignApps)
                ) && 
                (
                    this.ForeignAssets == input.ForeignAssets ||
                    this.ForeignAssets != null &&
                    input.ForeignAssets != null &&
                    this.ForeignAssets.SequenceEqual(input.ForeignAssets)
                ) && 
                (
                    this.GlobalStateSchema == input.GlobalStateSchema ||
                    (this.GlobalStateSchema != null &&
                    this.GlobalStateSchema.Equals(input.GlobalStateSchema))
                ) && 
                (
                    this.LocalStateSchema == input.LocalStateSchema ||
                    (this.LocalStateSchema != null &&
                    this.LocalStateSchema.Equals(input.LocalStateSchema))
                ) && 
                (
                    this.OnCompletion == input.OnCompletion ||
                    (this.OnCompletion != null &&
                    this.OnCompletion.Equals(input.OnCompletion))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.Accounts != null)
                    hashCode = hashCode * 59 + this.Accounts.GetHashCode();
                if (this.ApplicationArgs != null)
                    hashCode = hashCode * 59 + this.ApplicationArgs.GetHashCode();
                if (this.ApplicationId != null)
                    hashCode = hashCode * 59 + this.ApplicationId.GetHashCode();
                if (this.ApprovalProgram != null)
                    hashCode = hashCode * 59 + this.ApprovalProgram.GetHashCode();
                if (this.ClearStateProgram != null)
                    hashCode = hashCode * 59 + this.ClearStateProgram.GetHashCode();
                if (this.ForeignApps != null)
                    hashCode = hashCode * 59 + this.ForeignApps.GetHashCode();
                if (this.ForeignAssets != null)
                    hashCode = hashCode * 59 + this.ForeignAssets.GetHashCode();
                if (this.GlobalStateSchema != null)
                    hashCode = hashCode * 59 + this.GlobalStateSchema.GetHashCode();
                if (this.LocalStateSchema != null)
                    hashCode = hashCode * 59 + this.LocalStateSchema.GetHashCode();
                if (this.OnCompletion != null)
                    hashCode = hashCode * 59 + this.OnCompletion.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
