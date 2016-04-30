using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ColossusBets.Calculator.DataService.Ef6Model
{
    /// <summary>
    ///     Model object to store a result
    /// </summary>
    public class Record
    {
        /// <summary>
        ///     Record base constructor
        /// </summary>
        public Record()
        {
            CreatedAt = DateTimeOffset.UtcNow;
        }

        /// <summary>
        ///     The ID of the record
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        /// <summary>
        ///     The amount evaluated
        /// </summary>
        [Required]
        public decimal Amount { get; set; }

        /// <summary>
        ///     The result obtained
        /// </summary>
        [Required]
        public string Combination { get; set; }

        /// <summary>
        ///     The date of creation to the record
        /// </summary>
        [Required]
        public DateTimeOffset CreatedAt { get; set; }
    }
}