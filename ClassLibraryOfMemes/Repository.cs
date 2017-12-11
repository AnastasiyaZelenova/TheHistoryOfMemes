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

namespace ClassLibraryOfMemes
{
    public class Repository
    {
        public event Action<Meme> MemeAdded;
        public event Action<Group> GroupAdded;

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
        //public ContextOfMemes Context { get; set; }
        //public List<Meme> Memes { get; set; }
        //public List<Group> Groups { get; set; }
        //public Repository(ContextOfMemes context)
        //{
        //    Context = context;
        //    Memes = context.Memes.ToList();
        //    Groups = context.Groups.ToList();
        //}
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
                //foreach (var m in Memes)
                //{
                //    if (m.Id == meme.Id)
                //        throw new ArgumentException("Codes must be unique.");
                //}
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
                //foreach (var g in Groups)
                //{
                //    if (g.Id == group.Id)
                //        throw new ArgumentException("Ids must be unique.");
                //}
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
        public byte[] SetBitmat(Bitmap bmp)// method was taken from https://ru.stackoverflow.com/questions/72679/%D0%9A%D0%B0%D0%BA-%D0%B7%D0%B0%D0%B3%D1%80%D1%83%D0%B7%D0%B8%D1%82%D1%8C-%D0%BA%D0%B0%D1%80%D1%82%D0%B8%D0%BD%D0%BA%D1%83-%D0%B2-%D0%B1%D0%B0%D0%B7%D1%83-%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85-%D0%B8-%D0%BE%D1%82%D0%BE%D0%B1%D1%80%D0%B0%D0%B7%D0%B8%D1%82%D1%8C-%D1%84%D0%BE%D1%82%D0%BE-%D0%B2-%D0%BE%D0%B1%D1%8A%D0%B5%D0%BA%D1%82%D0%B5-picture
        {
            using (MemoryStream ms = new MemoryStream())
            {
                bmp.Save(ms, bmp.RawFormat);
                return ms.ToArray();
            }
        }

        public string GettingImagePath(string relativePath)
        {
            var appDir = AppDomain.CurrentDomain.BaseDirectory;
            var filename = Path.Combine(appDir, relativePath);
            return filename;
        }
        public void infoShow()
        {
            using (var context = new ContextOfMemes())
            {
                foreach (var meme in context.Memes)
                {
                    var data = File.ReadAllBytes(meme.ImagePath);
                    using (var ms = new MemoryStream(data))
                    {
                        using (var img = Image.FromStream(ms))
                        {
                        }
                    }
                }
            }
        }
        }
}

