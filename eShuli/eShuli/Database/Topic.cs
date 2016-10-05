using SQLite.Net.Attributes;

namespace eShuli.Database
{
    [Table("Topic")]
    public class Topic
    {
       [PrimaryKey]
        public int TopicID { get; set; }
        public int SubjectId { get; set; }
        public string TopicTitle { get; set; }
        public string Overview { get; set; }
        public string Notes { get; set; }
        public string Updated_Notes { get; set; }
        public string Updated_at { get; set; }
        public string teacher_full_names { get; set; }
        public int Folder_Id { get; set; }
        public string Folder_Name { get; set; }
        public Topic() { }
        public Topic(int id, int sid, string title, string overview, string notes, string update, string teacher, int folder_id, string folder_name)
        {
            TopicID = id;
            SubjectId = sid;
            TopicTitle = title;
            Updated_Notes = notes;
            Overview = overview;
            Updated_at = update;
            teacher_full_names = teacher;
            Folder_Name = folder_name;
            Folder_Id = folder_id;
        }
    }
}