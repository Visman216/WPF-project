using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;


namespace Tellisense.Data
{

    /// <summary>
    /// The Interface defining methods for Create Employee and Read All Employees  
    /// </summary>
    public interface IDataAccessService
    {
        ObservableCollection<Forum> GetForums();
        ObservableCollection<SubForum> GetSubForums(int forumID);
        ObservableCollection<Thread> GetThreads(int threadID);
        ObservableCollection<Post> GetPosts(int postID);

        void RemovePost(int postID);
        void RemoveThread(int threadId);
        void RemoveSubforum(int subforumID);
        void RemoveForum(int forumID);

        Post GetPost(int postID);
        User GetUser(int UserID);

        ObservableCollection<Thread> SearchThreads(string searchkey);

        void createForums(Forum forum);
        void createSubforum(SubForum subforum);
        void createThread(Thread thread);
        void createPost(Post post);

        void EditForums(Forum forum);
        void EditSubforum(SubForum subforum);
        void EditThread(Thread thread);
        void EditPost(Post post);

    }
     

    public class DataAccessService : IDataAccessService
    {
        Tellisense_DatabaseEntities context;

        public DataAccessService()
        {
            context = new Tellisense_DatabaseEntities();
        }

        /// <summary>
        /// Read service
        /// </summary>
        
        public ObservableCollection<Forum> GetForums()
        {
            ObservableCollection<Forum> forums = new ObservableCollection<Forum>();
            foreach (var item in context.Forum)
            {
                forums.Add(item);
            }
            return forums;
        }

        public ObservableCollection<SubForum> GetSubForums(int forumID)
        {
            ObservableCollection<SubForum> subforums = new ObservableCollection<SubForum>();
            foreach (var item in context.SubForum)
            {
                if (item.in_forum == forumID)
                    subforums.Add(item);
            }
            return subforums;
        }

        public ObservableCollection<Thread> GetThreads(int subforumID)
        {
            ObservableCollection<Thread> threads = new ObservableCollection<Thread>();
            foreach (var item in context.Thread)
            {
                if (item.in_subforum == subforumID)
                    threads.Add(item);
            }
            return threads;
        }

        public ObservableCollection<Post> GetPosts(int threadID)
        {
            ObservableCollection<Post> posts = new ObservableCollection<Post>();
            foreach (var item in context.Post)
            {
                if (item.in_thread == threadID)
                    posts.Add(item);
            }
            return posts;
        }

        /// <summary>
        /// Search Service
        /// </summary>
        
        public ObservableCollection<Thread> SearchThreads(string searchkey)
        {
            ObservableCollection<Thread> threads = new ObservableCollection<Thread>();
            foreach (var item in context.Thread)
            {
                
            }

            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete Service
        /// </summary>

        public void RemovePost(int postID)
        {
            Post post = (from p in context.Post where p.post_ID == postID select p).SingleOrDefault();
            context.Post.Remove(post);
            context.SaveChanges();
        }

        public void RemoveThread(int threadId)
        {
            Thread thread = (from t in context.Thread where t.thread_ID == threadId select t).SingleOrDefault();
            foreach(var item in context.Post)
            {
                if (item.in_thread == thread.thread_ID)
                    RemovePost(item.post_ID);
            }
            context.Thread.Remove(thread);
            context.SaveChanges();
        }

        public void RemoveSubforum(int subforumID)
        {
            SubForum subforum = (from s in context.SubForum where s.subforum_ID == subforumID select s).SingleOrDefault();
            foreach (var item in context.Thread)
            {
                if (item.in_subforum == subforum.subforum_ID)
                    RemoveThread(item.thread_ID);
            }
            context.SubForum.Remove(subforum);
            context.SaveChanges();
        }

        public void RemoveForum(int forumID)
        {
            Forum forum = (from f in context.Forum where f.forum_ID == forumID select f).SingleOrDefault();
            foreach (var item in context.SubForum)
            {
                if (item.in_forum == forum.forum_ID)
                    RemoveThread(item.subforum_ID);
            }
            context.Forum.Remove(forum);
            context.SaveChanges();
        }

        /// <summary>
        /// Helper Functions
        /// </summary>

        public Post GetPost(int postID)
        {
            foreach (var item in context.Post)
            {
                if (item.post_ID == postID)
                    return item;
            }
            return null;
        }

        public User GetUser(int UserID)
        {
            foreach (var item in context.User)
            {
                if (item.user_ID == UserID)
                    return item;
            }
            return null;
        }
        
        /// <summary>
        /// Add Service
        /// </summary>
        
        public void createForums(Forum forum)
        {
            context.Forum.Add(forum);
            context.SaveChanges();
        }

        public void createSubforum(SubForum subforum)
        {
            context.SubForum.Add(subforum);
            context.SaveChanges();
        }

        public void createThread(Thread thread)
        {
            context.Thread.Add(thread);
            context.SaveChanges();
        }

        public void createPost(Post post)
        {
            context.Post.Add(post);
            context.SaveChanges();
        }

        /// <summary>
        /// Edit Service
        /// </summary>    
                        
        public void EditForums(Forum forum)
        {
            throw new NotImplementedException();
        }

        public void EditSubforum(SubForum subforum)
        {
            throw new NotImplementedException();
        }

        public void EditThread(Thread thread)
        {
            throw new NotImplementedException();
        }

        public void EditPost(Post post)
        {
            throw new NotImplementedException();
        }
    }
}