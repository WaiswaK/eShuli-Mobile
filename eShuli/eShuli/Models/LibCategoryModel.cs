using System.Collections.Generic;

namespace eShuli.Models
{
    public class LibCategoryModel
    {
        public int category_id { get; set; }
        public string category_name { get; set; }
        public int book_count { get; set; }
        public string category_image { get; set; }
        public List<BookModel> category_books { get; set; }
        public LibCategoryModel()
        {
        }
    }
}
