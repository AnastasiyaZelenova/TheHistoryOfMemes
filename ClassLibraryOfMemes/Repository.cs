using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryOfMemes
{
    class Repository
    {
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
    }
}
