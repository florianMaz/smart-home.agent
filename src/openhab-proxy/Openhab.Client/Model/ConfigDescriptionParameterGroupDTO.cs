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
    /// ConfigDescriptionParameterGroupDTO
    /// </summary>
    [DataContract]
    public partial class ConfigDescriptionParameterGroupDTO :  IEquatable<ConfigDescriptionParameterGroupDTO>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigDescriptionParameterGroupDTO" /> class.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="context">context.</param>
        /// <param name="advanced">advanced (default to false).</param>
        /// <param name="label">label.</param>
        /// <param name="description">description.</param>
        public ConfigDescriptionParameterGroupDTO(string name = default(string), string context = default(string), bool? advanced = false, string label = default(string), string description = default(string))
        {
            Name = name;
            Context = context;
            // use default value if no "advanced" provided
            if (advanced == null)
            {
                Advanced = false;
            }
            else
            {
                Advanced = advanced;
            }
            Label = label;
            Description = description;
        }
        
        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Context
        /// </summary>
        [DataMember(Name="context", EmitDefaultValue=false)]
        public string Context { get; set; }

        /// <summary>
        /// Gets or Sets Advanced
        /// </summary>
        [DataMember(Name="advanced", EmitDefaultValue=false)]
        public bool? Advanced { get; set; }

        /// <summary>
        /// Gets or Sets Label
        /// </summary>
        [DataMember(Name="label", EmitDefaultValue=false)]
        public string Label { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ConfigDescriptionParameterGroupDTO {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Context: ").Append(Context).Append("\n");
            sb.Append("  Advanced: ").Append(Advanced).Append("\n");
            sb.Append("  Label: ").Append(Label).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
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
            return Equals(input as ConfigDescriptionParameterGroupDTO);
        }

        /// <summary>
        /// Returns true if ConfigDescriptionParameterGroupDTO instances are equal
        /// </summary>
        /// <param name="input">Instance of ConfigDescriptionParameterGroupDTO to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ConfigDescriptionParameterGroupDTO input)
        {
            if (input == null)
                return false;

            return 
                (
                    Name == input.Name ||
                    (Name != null &&
                    Name.Equals(input.Name))
                ) && 
                (
                    Context == input.Context ||
                    (Context != null &&
                    Context.Equals(input.Context))
                ) && 
                (
                    Advanced == input.Advanced ||
                    (Advanced != null &&
                    Advanced.Equals(input.Advanced))
                ) && 
                (
                    Label == input.Label ||
                    (Label != null &&
                    Label.Equals(input.Label))
                ) && 
                (
                    Description == input.Description ||
                    (Description != null &&
                    Description.Equals(input.Description))
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
                if (Name != null)
                    hashCode = hashCode * 59 + Name.GetHashCode();
                if (Context != null)
                    hashCode = hashCode * 59 + Context.GetHashCode();
                if (Advanced != null)
                    hashCode = hashCode * 59 + Advanced.GetHashCode();
                if (Label != null)
                    hashCode = hashCode * 59 + Label.GetHashCode();
                if (Description != null)
                    hashCode = hashCode * 59 + Description.GetHashCode();
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
