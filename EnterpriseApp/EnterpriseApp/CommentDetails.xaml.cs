using EnterpriseApp.Data;
using EnterpriseApp.Net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace EnterpriseApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CommentDetails : ContentPage
	{

        public ObservableCollection<Comments> CommentsList { get; }

        DataRetriever _dr;
        UserProfile _up;


        public CommentDetails (Posts posts)
		{
			InitializeComponent ();
            this.InitializeComponent();
        
            this.BindingContext = this;

            Title = "Comments";
            BackgroundImage = "image1.jpg";

            CommentsList = new ObservableCollection<Comments>();

            CommentsListView.ItemsSource = CommentsList;

            CommentsListView.ItemSelected += CommentsListView_ItemSelected;

            _dr = new DataRetriever();

            LongRunningTaskAsync(posts);

            AddToolbarItem(posts);
        
        }

        private void CommentsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
            //popupView.IsVisible = true;

            if (e.SelectedItem != null)
            {
                var item = (Comments)e.SelectedItem;

                //Comments ctx = BindingContext as Comments;
                Console.WriteLine("Press Email :" + item.Email);
                string urlToLaunch = "mailto:" + item.Email;
                Device.OpenUri(new Uri(urlToLaunch));

            }

        }

        private void LoadComment(Posts posts)
        {
            CommentsList.Clear();

            List<Comments> comments = _dr.GetComment(posts);

            foreach (Comments u in comments)
            {
                CommentsList.Add(u);
            }
          

        }

        //private void Onclick(object sender, EventArgs e)
        //{

        //    Image lblClicked = (Image)sender;

        //    var item = (TapGestureRecognizer)lblClicked.GestureRecognizers[0];
        //    int postId = (int)item.CommandParameter;

        //    //pass post id to UserProfile page
        //    UserProfile userProf = new UserProfile(postId);

        //    Navigation.PushAsync(userProf);

        //}

        private async Task LongRunningTaskAsync(Posts posts)
        {
            // set to busy at the start
            IsBusy = true;

            // run your task... 
            await Task.Delay(1500);

            LoadComment(posts);

            // switch the busy indicator back
            IsBusy = false;
        }

        private void AddToolbarItem(Posts posts)
        {
            ToolbarItem toolbarItem = new ToolbarItem(null, "user.png", () =>
            {

                UserProfile userProf = new UserProfile(posts.ID);
                Navigation.PushAsync(userProf);

            }, 0, 0);
            ToolbarItems.Add(toolbarItem);
        }

    }
}