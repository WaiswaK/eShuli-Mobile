using eShuli.Core;
using eShuli.Database;
using eShuli.Models;
using eShuli.ViewModels;
using System.Linq;
using Xamarin.Forms;

namespace eShuli.Views
{
    public partial class TopicsView : ContentPage
    {
        public TopicsView(FolderModel MainTopic)
        {
            InitializeComponent();
            BindingContext = new TopicsViewModel(MainTopic);
        }
        void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        => ((ListView)sender).SelectedItem = null;
        async void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var notes = ((ListView)sender).SelectedItem as TopicModel;
            if (notes == null)
                return;
            else
            {
                if (await DependencyService.Get<Interfaces.ITask>().FileExists(notes.body))
                    await Navigation.PushAsync(new PDFReader(notes));
                else
                {
                    if (DependencyService.Get<Interfaces.ITask>().IsInternetConnectionAvailable())
                    {
                        bool fullydownloaded = false;
                        IsBusy = true;
                        try
                        {
                            await DependencyService.Get<Interfaces.ITask>().DownloadFile(notes.body, notes.folder_id + notes.TopicID + notes.folder_name);
                            fullydownloaded = true;
                        }
                        catch
                        {
                            fullydownloaded = false;
                            IsBusy = false;
                        }

                        if (fullydownloaded == true)
                        {
                            IsBusy = false;
                            using (var db = DependencyService.Get<Interfaces.IDatabase>().GetConnection())
                            {
                                var query = (db.Table<Topic>().Where(c => c.TopicID == notes.TopicID)).Single();
                                string downloadpath = query.Folder_Id + query.TopicID + query.Folder_Name;
                                string newPath = DependencyService.Get<Interfaces.ITask>().pdfPath(downloadpath + Core.Constant.PDF_extension);
                                newPath = newPath.Replace(' ', '_');
                                TopicModel topic = new TopicModel(query.TopicID, query.Notes, query.Overview,
                                    query.TopicTitle, query.teacher_full_names, query.Updated_at, query.Folder_Id,
                                    query.Folder_Name);
                                db.Update(topic);
                                notes.body = newPath;
                            }
                            await Navigation.PushAsync(new PDFReader(notes));
                        }
                        else
                        {
                            await DisplayAlert(Message.Download_Header, Message.Download_Error, Message.Ok);
                        }

                    }
                    else
                    {
                        await DisplayAlert(Message.File_Access_Header, Message.Offline_File_Unavailable, Message.Ok);
                    }
                }
            }
        }
    }
}
