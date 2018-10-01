using EnterpriseApp.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml.Linq;

namespace EnterpriseApp.Net
{
    public class DataRetriever
    {
        //public Posts BindingContext { get; private set; }
        public User BindingContext { get; private set; }

        public DataRetriever()
        {

        }

        // Get all users
        public List<User> GetUsers()
        {
            List<User> users = new List<User>();

            using (WebClient wc = new WebClient())
            {
                string json = wc.DownloadString("https://jsonplaceholder.typicode.com/users");

                if (!string.IsNullOrEmpty(json))
                {
                    users = JsonConvert.DeserializeObject<User[]>(json).ToList();
                }
            }

            return users;
        }

        public Posts GetPostById(Object pid)
        {
            int postid = (int)pid;
            Posts posts = new Posts();

            using (WebClient wc = new WebClient())
            {
                string json = wc.DownloadString("https://jsonplaceholder.typicode.com/posts/" + postid);

                if (!string.IsNullOrEmpty(json))
                {
                    posts = JsonConvert.DeserializeObject<Posts>(json);
                }
            }

            return posts;
        }


        //Get all the posts
        public List<Posts> GetPosts()
        {
            List<Posts> posts = new List<Posts>();

            using (WebClient wc = new WebClient())
            {   
                string json = wc.DownloadString("https://jsonplaceholder.typicode.com/posts");

                if (!string.IsNullOrEmpty(json))
                {
                    posts = JsonConvert.DeserializeObject<Posts[]>(json).ToList();
                }
            }

            return posts;
        }

        //Get all the comments
        public List<Comments> GetComment(Posts posts)
        {
            List<Comments> comments = new List<Comments>();

            //Posts ctx = BindingContext as Posts;

            using (WebClient wc = new WebClient())
            {
                string json = wc.DownloadString("https://jsonplaceholder.typicode.com/comments?postId=" + posts.ID);
 

                if (!string.IsNullOrEmpty(json))
                {
                    comments = JsonConvert.DeserializeObject<Comments[]>(json).ToList();
                }
            }

            return comments;
        }
    }
}
