using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ef_core_demo.Models
{
    public class Blog
    {
        //還有哪些屬性可以設:
        //https://docs.microsoft.com/zh-tw/dotnet/api/system.componentmodel.dataannotations?view=netcore-3.1

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BlogId { get; set; }
        
        public string Url { get; set; }

        public List<Post> Posts { get; } = new List<Post>();
    }
}
