﻿using System.Collections.Generic;

namespace eShuli.Models
{
    public class UserModel
    {
        public string email { get; set; }
        public string password { get; set; }
        public string full_names { get; set; }
        public SchoolModel School { get; set; }
        public List<SubjectModel> subjects { get; set; }
        public int update_status { get; set; }
        public LibraryModel Library { get; set; }
        public bool NotesImagesDownloading { get; set; }
    }
}
