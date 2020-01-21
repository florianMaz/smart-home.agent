/* 
 * openHAB REST API
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: 2.5
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Openhab.Client.Model
{
    /// <summary>
    /// FirmwareStatusDTO
    /// </summary>
    [DataContract]
    public partial class FirmwareStatusDTO :  IEquatable<FirmwareStatusDTO>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FirmwareStatusDTO" /> class.
        /// </summary>
        /// <param name="status">status.</param>
        /// <param name="updatableVersion">updatableVersion.</param>
        public FirmwareStatusDTO(string status = default(string), string updatableVersion = default(string))
        {
            Status = status;
            UpdatableVersion = updatableVersion;
        }
        
        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        [DataMember(Name="status", EmitDefaultValue=false)]
        public string Status { get; set; }

        /// <summary>
        /// Gets or Sets UpdatableVersion
        /// </summary>
        [DataMember(Name="updatableVersion", EmitDefaultValue=false)]
        public string UpdatableVersion { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class FirmwareStatusDTO {\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  UpdatableVersion: ").Append(UpdatableVersion).Append("\n");
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
            return Equals(input as FirmwareStatusDTO);
        }

        /// <summary>
        /// Returns true if FirmwareStatusDTO instances are equal
        /// </summary>
        /// <param name="input">Instance of FirmwareStatusDTO to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(FirmwareStatusDTO input)
        {
            if (input == null)
                return false;

            return 
                (
                    Status == input.Status ||
                    (Status != null &&
                    Status.Equals(input.Status))
                ) && 
                (
                    UpdatableVersion == input.UpdatableVersion ||
                    (UpdatableVersion != null &&
                    UpdatableVersion.Equals(input.UpdatableVersion))
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
                if (Status != null)
                    hashCode = hashCode * 59 + Status.GetHashCode();
                if (UpdatableVersion != null)
                    hashCode = hashCode * 59 + UpdatableVersion.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
