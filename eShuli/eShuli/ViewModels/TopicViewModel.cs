using System.Collections.Generic;
using eShuli.Models;


namespace eShuli.ViewModels
{
    class TopicViewModel 
    {
        private string _topicTitle;
        public string TopicName
        {
            get { return _topicTitle; }
            set { _topicTitle = value; }
        }
        private List<AttachmentModel> _attachments;
        public List<AttachmentModel> TopicFiles
        {
            get { return _attachments; }
            set { _attachments = value; }
        }
        private Xamarin.Forms.HtmlWebViewSource _htmlWebViewSource;
        public Xamarin.Forms.HtmlWebViewSource NotesHtmlWebViewSource
        {
            get
            {
                return _htmlWebViewSource;
            }
            set
            {
                _htmlWebViewSource = value;
            }
        }
        public TopicViewModel(TopicModel Topic, string new_notes)
        {
            TopicName = Topic.TopicTitle;
            Xamarin.Forms.HtmlWebViewSource temp = new Xamarin.Forms.HtmlWebViewSource();
            temp.Html = new_notes;
            NotesHtmlWebViewSource = temp;
        }
    }
}
