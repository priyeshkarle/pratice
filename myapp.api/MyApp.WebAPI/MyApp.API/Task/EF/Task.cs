namespace MyApp.API.Task.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Task
    {
        public Guid ID { get; set; }

        [Required]
        [StringLength(250)]
        public string Title { get; set; }

        public DateTime DueDate { get; set; }

        [Required]
        [StringLength(20)]
        public string Priority { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; }

        [Required]
        [StringLength(500)]
        public string Notes { get; set; }

        public Guid UserID { get; set; }
    }
}
