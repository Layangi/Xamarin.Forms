using EnterpriseApp.Data;
using EnterpriseApp.Net;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EnterpriseApp
{
    public partial class ListPage : ContentPage
    {  
        //this.NavigationController.NavigationBar.TintColor = UIColor.Magenta;
      
        public ObservableCollection<Posts> PostsList { get; }

        DataRetriever _dr;
       // private int _clickCount;

        public ListPage()
        {
            InitializeComponent();
            this.InitializeComponent();

            this.BindingContext = this;

            Title = "Posts";
            BackgroundImage = "image1.jpg";

            PostsList = new ObservableCollection<Posts>();

            UsersListView.ItemsSource = PostsList;


            UsersListView.ItemSelected += UsersListView_ItemSelected;

            _dr = new DataRetriever();


            // LoadData();
            SomeLongRunningTaskAsync();

        }

        private async Task SomeLongRunningTaskAsync()
        {
            // here's your long running task.
            // set to busy at the start
            IsBusy = true;

            // run your task... 
         
            await Task.Delay(1500);
            //await Task.Delay(2500)
               // .ContinueWith(task => { _clickCount++; });

            
            LoadData();

            // switch the busy indicator back.
            IsBusy = false;
        }

        private void UsersListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                CommentDetails data = new CommentDetails(e.SelectedItem as Posts);
                Navigation.PushAsync(data);
              
            }

            // Clear selection
            UsersListView.SelectedItem = null;
        }

        private void LoadData()
        {

            PostsList.Clear();

            List<Posts> posts = _dr.GetPosts();

            foreach (Posts u in posts)
            {
               
                PostsList.Add(u);
        
            }
            
        }
        
    }



}


    

