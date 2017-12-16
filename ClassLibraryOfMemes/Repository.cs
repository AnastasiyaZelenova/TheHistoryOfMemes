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
        public event Action<Meme> MemesChanged;
        public event Action<Group> GroupsChanged;
        public event Action<UsersMeme> UsersMemesChanged;
        public event Action<int> OnLikesChanged;


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


        public void EditMeme(Meme editedmeme, string name, int year, string description, string imagePath)
        {
            using (var context = new ContextOfMemes())
            {
                try
                {
                    context.Memes.ToList().Find(m => m.Id == editedmeme.Id).Name = name;
                    context.Memes.ToList().Find(m => m.Id == editedmeme.Id).Year = year;
                    context.Memes.ToList().Find(m => m.Id == editedmeme.Id).Description = description;
                    context.Memes.ToList().Find(m => m.Id == editedmeme.Id).ImagePath = imagePath;
                    context.SaveChanges();
                    MemesChanged?.Invoke(editedmeme);
                }
                catch (Exception)
                {
                    throw new Exception("Editing was provided incorrectly.");
                }
            }
        }
        public void EditGroup(Group group, string url, string name)
        {
            using (var context = new ContextOfMemes())
            {
                try
                {
                    context.Groups.ToList().Find(g => g.Id == group.Id).Url = url;
                    context.Groups.ToList().Find(g => g.Id == group.Id).Name = name;
                    context.SaveChanges();
                    GroupsChanged?.Invoke(group);
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
                    MemesChanged?.Invoke(meme);
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
                    GroupsChanged?.Invoke(group);
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
                    GroupsChanged?.Invoke(group);
                }
                catch (Exception)
                {
                    throw new Exception("No delete was provided succesfully.");
                }
            }
        }

        public void AddUsersMeme(UsersMeme umeme)
        {
            using (var context = new ContextOfMemes())
            {
                try
                {
                    context.UserMemes.Add(umeme);
                    context.SaveChanges();
                    UsersMemesChanged?.Invoke(umeme);
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
                    UsersMemesChanged?.Invoke(umeme);
                }
                catch (Exception)
                {
                    throw new Exception("No delete was provided succesfully.");
                }
            }
        }

        public void DeleteMeme(Meme meme)
        {
            using (var context = new ContextOfMemes())
            {
                try
                {
                    var memeInDB = context.Memes.First(m => m.Id == meme.Id);
                    context.Memes.Remove(memeInDB);
                    context.SaveChanges();
                    MemesChanged?.Invoke(meme);
                }
                catch (Exception)
                {
                    throw new Exception("No delete was provided succesfully.");
                }
            }
        }

        public int IncreaseLikes(int likes, Meme meme)
        {
            using (var context = new ContextOfMemes())
            {
                var memeInDB = context.Memes.First(m => m.Id == meme.Id);
                memeInDB.Likes =  likes++;
                OnLikesChanged?.Invoke(likes);
                context.SaveChanges();

                return likes;
            }
                
        }

    }
}

