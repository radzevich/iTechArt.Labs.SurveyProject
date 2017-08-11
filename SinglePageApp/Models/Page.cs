﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SinglePageApp.Models
{
    public class Page
    {
        public int Id { get; set; }

        [StringLength(256)]
        public string Title { get; set; }

        public virtual ICollection<Question> Questions { get; set; }

        public Page()
        {
            Questions = new List<Question>();
        }
    }
}