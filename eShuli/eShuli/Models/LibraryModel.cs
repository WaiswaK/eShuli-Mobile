﻿using System.Collections.Generic;

namespace eShuli.Models
{
    public class LibraryModel
    {
        public int library_id { get; set; }
        public List<LibCategoryModel> categories { get; set; }
        public LibraryModel()
        {
        }
    }
}
