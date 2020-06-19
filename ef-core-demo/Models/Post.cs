using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ef_core_demo.Models
{
    public class Post
    {
        
        public int PostId { get; set; }//若不加任何屬性(此欄位會自動為Key且為自動新增)
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }

        public DateTime? UpdateTime { get; set; }
        public int? Counter { get; set; }


    }
}
