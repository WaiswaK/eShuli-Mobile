
using eShuli.Models;
using Xamarin.Forms;

namespace eShuli.Views
{
    public partial class PDFReader : ContentPage
    {
        public PDFReader(AttachmentModel file)
        {
            InitializeComponent();
            BindingContext = new ViewModels.PDFReaderViewModel(file);
        }
        public PDFReader(BookModel book)
        {
            InitializeComponent();
            BindingContext = new ViewModels.PDFReaderViewModel(book);
        }
        public PDFReader(TopicModel topic)
        {
            InitializeComponent();
            BindingContext = new ViewModels.PDFReaderViewModel(topic);
        }
    }
}
