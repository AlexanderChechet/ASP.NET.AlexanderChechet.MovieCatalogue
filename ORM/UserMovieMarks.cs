namespace ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserMovieMarks
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int IdUser { get; set; }

        public int IdMovie { get; set; }

        public int Mark { get; set; }

        public virtual Movies Movies { get; set; }

        public virtual Users Users { get; set; }
    }
}
