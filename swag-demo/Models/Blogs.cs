﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace swag_demo.Models
{
    public partial class Blogs
    {
        public Blogs()
        {
            Posts = new HashSet<Posts>();
        }

        [Key]
        public int BlogId { get; set; }
        public string Url { get; set; }

        [InverseProperty("Blog")]
        public virtual ICollection<Posts> Posts { get; set; }
    }
}