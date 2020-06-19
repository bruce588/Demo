﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace swag_demo.Models
{
    public partial class Posts
    {
        [Key]
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; }
        public int? Counter { get; set; }
        public DateTime? UpdateTime { get; set; }

        [ForeignKey(nameof(BlogId))]
        [InverseProperty(nameof(Blogs.Posts))]
        public virtual Blogs Blog { get; set; }
    }
}