﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace T28_API_JWT_Ex1.Models
{
    public partial class Proveedores
    {
        public Proveedores()
        {
            Suministra = new HashSet<Suministra>();
        }

        public string Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Suministra> Suministra { get; set; }
    }
}
