using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace ClassLibraryOfMemes
{
    public class Repository
    {
        public event Action<Meme> MemeAdded;
        public event Action<Group> GroupAdded;
        public ContextOfMemes Context { get; set; }
        public List<Meme> Memes { get; set; }
        public List<Group> Groups { get; set; }
        public Repository(ContextOfMemes context)
        {
            Context = context;
            Memes = context.Memes.ToList();
            Groups = context.Groups.ToList();
        }
        public void EditMeme(Meme editedmeme)
        {
            try
            {
                var memetoedit = Memes.Find(m => m.Id == editedmeme.Id);
                memetoedit.Name = editedmeme.Name;
                memetoedit.Image = editedmeme.Image;
                memetoedit.Year = editedmeme.Year;
                memetoedit.Description = editedmeme.Description;
                memetoedit = Context.Memes.ToList().Find(m => m.Id == editedmeme.Id);
                memetoedit.Name = editedmeme.Name;
                memetoedit.Image = editedmeme.Image;
                memetoedit.Year = editedmeme.Year;
                memetoedit.Description = editedmeme.Description;
                Context.SaveChanges();
                MemeAdded?.Invoke(editedmeme);
            }
            catch (Exception)
            {

                throw new Exception("Editing was provided incorrectly.");
            }
        }
        public void EditGroup(Group group, string url)
        {
            try
            {
                Groups.Find(g => g.Id == group.Id).Url = url;
                Context.Groups.ToList().Find(g => g.Id == group.Id).Url = url;
                Context.SaveChanges();
                GroupAdded?.Invoke(group);
            }
            catch(Exception)
            {
                throw new Exception("Error during editing group in database.");
            }
        }
        public void AddMeme(Meme meme)
        {
            if (Memes.Find(m => m.Id == meme.Id) != null) throw new ArgumentException("Ids must be unique.");
            try
            {
                Memes.Add(meme);
                Context.Memes.Add(meme);
                Context.SaveChanges();
                MemeAdded?.Invoke(meme);
            }

            catch (Exception)
            {

                throw new Exception("Error during adding meme to database.");
            }
        }
        public void AddGroup(Group group)
        {
            if (Groups.Find(g => g.Id == group.Id) != null) throw new ArgumentException("Ids must be unique.");
            try
            {
                Groups.Add(group);
                Context.Groups.Add(group);
                Context.SaveChanges();
                GroupAdded?.Invoke(group);

            }

            catch (Exception)
            {

                throw new Exception("Error during adding group to database.");
            }
        }
        public void DeleteGroup(Group group)
        {
            try
            {
                Groups.Remove(group);
                Context.Groups.Remove(group);
                Context.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("No delete was provided succesfully.");
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
    }
    }
