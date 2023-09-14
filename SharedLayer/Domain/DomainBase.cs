using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SharedLayer.Domain
{
    public abstract class DomainBase : IDomain
    {
        #region Ctor
        public DomainBase()
        {
            this.ModifiedOnDate = DateTimeOffset.Now;
        }
        #endregion

        //[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }

        public DateTimeOffset CreatedOnDate { get; set; }

        public DateTimeOffset ModifiedOnDate { get; set; }

        [NotMapped]
        public DomainStateType State { get; set; }


        /// <summary>
        /// Determines whether the specified object is valid.
        /// </summary>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>
        /// A collection that holds failed-validation information.
        /// </returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            IEnumerable<ValidationResult> validationResults = this.Validate();

            if (validationResults == null)
            {
                switch (this.State)
                {
                    case DomainStateType.Added:
                        validationResults = this.OnValidateWhileCreate();
                        break;
                    case DomainStateType.Modified:
                        validationResults = this.OnValidateWhileUpdate();
                        break;
                    case DomainStateType.Deleted:
                        validationResults = this.OnValidateWhileDelete();
                        break;

                }
            }

            return validationResults;
        }

        /// <summary>
        /// Called when [validate while create].
        /// </summary>
        /// <returns></returns>
        /// <devnote>Not an abstract method since child entities may not have any validation to do.</devnote>
        protected virtual IEnumerable<ValidationResult> OnValidateWhileCreate()
        {
            return null;
        }

        /// <summary>
        /// Called when [validate while update].
        /// </summary>
        /// <returns></returns>
        protected virtual IEnumerable<ValidationResult> OnValidateWhileUpdate()
        {
            return null;
        }

        /// <summary>
        /// Called when [validate while delete].
        /// </summary>
        /// <returns></returns>
        protected virtual IEnumerable<ValidationResult> OnValidateWhileDelete()
        {
            return null;
        }

        /// <summary>
        /// Called when [validate always].
        /// </summary>
        /// <returns></returns>
        private IEnumerable<ValidationResult> Validate()
        {
            //todo: validation logic which must run in all cases on common properties
            return null;
        }
    }
}
