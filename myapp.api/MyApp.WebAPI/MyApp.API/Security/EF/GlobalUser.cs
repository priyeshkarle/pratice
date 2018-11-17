namespace MyApp.API.Security.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GlobalUser
    {
        public Guid ID { get; set; }

        [Required]
        [StringLength(20)]
        public string Username { get; set; }

        [Required]
        [StringLength(20)]
        public string Password { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        public Guid? Token { get; set; }

        public bool IsActive { get; set; }
    }
}
