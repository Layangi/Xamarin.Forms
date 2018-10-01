using EnterpriseApp.Data;
using EnterpriseApp.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EnterpriseApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserProfile : ContentPage
	{
        DataRetriever _dr;

        public UserProfile(int postId)
        {
            InitializeComponent();

            Title = "User Profile";
            BackgroundImage ="image2.png" ;

            _dr = new DataRetriever();

            Posts post = _dr.GetPostById(postId);

            int userId = post.ID;

            LoadUser(userId);
        }

        public void LoadUser(int userId)
        {
            List<User> users = _dr.GetUsers();

            foreach (User user in users)
            {
                if (user.Id == userId)
                {
                    BindingContext = user;
                }
            }
        }


    }
}