﻿
using System;
using Sdl.Web.Common.Configuration;

namespace Sdl.Web.Common.Mapping
{
    /// <summary>
    /// Represents the semantics of a Schema: Prefix and Entity.
    /// </summary>
    /// <remarks>
    /// Deserialized from JSON in schemas.json.
    /// </remarks>
    public class SchemaSemantics
    {
        /// <summary>
        /// Gets or set the semantic Vocabulary prefix.
        /// </summary>
        public string Prefix { get; set; }

        /// <summary>
        /// Gets or sets the semantic Entity name.
        /// </summary>
        public string Entity { get; set; }

        /// <summary>
        /// Gets or set the semantic Vocabulary URI.
        /// </summary>
        public string Vocab { get; set; }

        #region Constructors

        /// <summary>
        /// Initializes a new empty instance of the <see cref="SchemaSemantics"/> class.
        /// </summary>
        /// <remarks>
        /// Used by JSON deserialer.
        /// </remarks>
        public SchemaSemantics()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SchemaSemantics"/> class, using default semantic vocabulary prefix.
        /// </summary>
        /// <param name="entity">Entity name.</param>
        [Obsolete("Deprecated in DXA 1.7. Use the overload with three parameters.")]
        public SchemaSemantics(string entity)
            : this(SemanticMapping.DefaultPrefix, entity, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SchemaSemantics"/> class.
        /// </summary>
        /// <param name="prefix">Vocabulary prefix</param>
        /// <param name="entity">Entity name</param>
        [Obsolete("Deprecated in DXA 1.7. Use the overload with three parameters.")]
        public SchemaSemantics(string prefix, string entity)
            : this(prefix, entity, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SchemaSemantics"/> class.
        /// </summary>
        /// <param name="prefix">Vocabulary prefix</param>
        /// <param name="entity">Entity name</param>
        /// <param name="localization">The context Localization (used to determine <see cref="Vocab"/>).</param>
        public SchemaSemantics(string prefix, string entity, Localization localization)
        {
            Prefix = prefix;
            Entity = entity;

            if (localization != null)
            {
                Initialize(localization);
            }
        }

        #endregion

        /// <summary>
        /// Initializes an existing instance: determines the <see cref="Vocab"/> property.
        /// </summary>
        /// <param name="localization">The context Localization.</param>
        public void Initialize(Localization localization)
        {
            Vocab = localization.GetSemanticVocabulary(Prefix).Vocab;
        }

        /// <summary>
        /// Provides a string representation of the object.
        /// </summary>
        /// <returns>A string representation in format <c>Vocab/Prefix:Entity</c>.</returns>
        public override string ToString()
        {
            return string.Format("{0}:{1}", Vocab ?? Prefix, Entity);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current <see cref="SchemaSemantics"/>.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the specified object is equal to the current one.
        /// </returns>
        /// <param name="obj">The object to compare with the current object. </param>
        public override bool Equals(object obj)
        {
            FieldSemantics other = obj as FieldSemantics;
            if (other == null)
            {
                return false;
            }

            if (Vocab == null)
            {
                return Prefix == other.Prefix && Entity == other.Entity;
            }

            return Vocab == other.Vocab && Entity == other.Entity;
        }

        /// <summary>
        /// Serves as a hash function for a particular type. 
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="SchemaSemantics"/>.
        /// </returns>
        public override int GetHashCode()
        {
            int result = Prefix.GetHashCode() ^ Entity.GetHashCode();
            if (Vocab != null)
            {
                result ^= Vocab.GetHashCode();
            }
            return result;
        }
    }
}