using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using ClassLibraryOfMemes.Model;
using System.Reflection;

namespace ClassLibraryOfMemes
{
    public class Repository
    {
        public event Action<Meme> MemeAdded;
        public event Action<Group> GroupAdded;
        public event Action<UsersMeme> UsersMemeAdded;
        public event Action<UsersMeme> UsersMemeDeleted;
        public event Action<int> LikesChanged;


        public IEnumerable<Meme> Memes
        {
            get
            {
                using (var context = new ContextOfMemes())
                    return context.Memes.ToList();
            }
        }
        public IEnumerable<Group> Groups
        {
            get
            {
                using (var context = new ContextOfMemes())
                    return context.Groups.ToList();
            }
        }
        public IEnumerable<UsersMeme> UserMemes
        {
            get
            {
                using (var context = new ContextOfMemes())
                    return context.UserMemes.ToList();
            }
        }
        public void EditMeme(Meme editedmeme, string description, List<Group> groups)
        {
            using (var context = new ContextOfMemes())
            {
                try
                {
                    var memetoedit = context.Memes.ToList().Find(m => m.Id == editedmeme.Id);
                    memetoedit.Description = editedmeme.Description;
                    //memetoedit.Groups = editedmeme.Groups;
                    context.SaveChanges();
                }
                catch (Exception)
                {

                    throw new Exception("Editing was provided incorrectly.");
                }
            }
        }
        public void EditGroup(Group group, string url)
        {
            using (var context = new ContextOfMemes())
            {
                try
                {
                    context.Groups.ToList().Find(g => g.Id == group.Id).Url = url;
                    context.SaveChanges();
                    GroupAdded?.Invoke(group);
                }
                catch (Exception)
                {
                    throw new Exception("Error during editing group in database.");
                }
            }
        }
        public void AddMeme(Meme meme)
        {
            using (var context = new ContextOfMemes())
            {
           
                try
                {
                    context.Memes.Add(meme);
                    context.SaveChanges();
                    MemeAdded?.Invoke(meme);
                }
                catch (Exception)
                {
                    throw new Exception("Error during adding meme to database.");
                }
            }
        }
        public void AddGroup(Group group)
        {
            using (var context = new ContextOfMemes())
            {
               
                try
                {
                    context.Groups.Add(group);
                    context.SaveChanges();
                    GroupAdded?.Invoke(group);
                }
                catch (Exception)
                {
                    throw new Exception("Error during adding group to database.");
                }
            }
        }

        public void DeleteGroup(Group group)
        {
            using (var context = new ContextOfMemes())
            {
                try
                {
                    var groupInDB = context.Groups.First(g => g.Id == group.Id);
                    context.Groups.Remove(groupInDB);
                    context.SaveChanges();
                }
                catch (Exception)
                {
                    throw new Exception("No delete was provided succesfully.");
                }
            }
        }

        public string GetImagePath(string relativePath)
        {
            
            var appDir = AppDomain.CurrentDomain.BaseDirectory;
            var filePath = Path.Combine(appDir, relativePath);
            return filePath;
        }
        

        public void AddUsersMeme(UsersMeme umeme)
        {
            using (var context = new ContextOfMemes())
            {
                try
                {
                    context.UserMemes.Add(umeme);
                    context.SaveChanges();
                    UsersMemeAdded?.Invoke(umeme);
                }
                catch (Exception)
                {
                    throw new Exception("Error during adding group to database.");
                }
            }
        }

        public void DeleteUsersMeme(UsersMeme umeme)
        {
            using (var context = new ContextOfMemes())
            {
                try
                {
                    var umemeInDB = context.UserMemes.First(m => m.Id == umeme.Id);
                    context.UserMemes.Remove(umemeInDB);
                    context.SaveChanges();
                    UsersMemeDeleted?.Invoke(umeme);
                }
                catch (Exception)
                {
                    throw new Exception("No delete was provided succesfully.");
                }
            }
        }
     
    }
}

