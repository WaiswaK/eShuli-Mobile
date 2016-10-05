namespace eShuli.Models
{
    public class TopicModel
    {
        public string TopicTitle { get; set; }
        public int TopicID { get; set; }
        public string body { get; set; }
        public string overview { get; set; }
        public string teacher { get; set; }      
        public string Updated_at { get; set; }
        public string folder_name { get; set; }
        public int folder_id { get; set; }
        public TopicModel(int _topicId, string _notes, string _overview, string _title, string full_names, string _updated, int _folder_id, string _folder_name)
        {
            TopicTitle = _title;
            TopicID = _topicId;
            body = _notes;
            overview = _overview;
            teacher = full_names;
            Updated_at = _updated;
            folder_id = _folder_id;
            folder_name = _folder_name;
        }
        public TopicModel() { }
    }
}