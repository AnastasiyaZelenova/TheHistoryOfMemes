namespace ClassLibraryOfMemes.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ClassLibraryOfMemes.ContextOfMemes>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ClassLibraryOfMemes.ContextOfMemes context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            Repository repository = new Repository();

            Meme[] memes =
            {
                new Meme
                {
                    Name = "Me Gusta",
                    Description = "Этот персонаж способен выражать удовольствие " +
                    "совершенно разного происхождения и от чего-нибудь порочного и неприличного " +
                    "до совершенно обыденного. Первоначально использовался только по отношению к " +
                    "половым извращениям, однако со временем распростронилось на всё странное или " +
                    "отвратительное. \"Me Gusta\" по-испански означает \"мне нравится\". Поскольку изначально " +
                    "мем Me Gusta относился исключительно к половым извращениям, то принято считать " +
                    "эту фразу слегка ехидной, о том же напоминает и ухмылка фейса. Автор Me Gusta - " +
                    "пользователь одного хорошего сайта художников \"Девиант Арт\" под ником Insert31990. " +
                    "Сам же мем возник примерно в ноябре 2010-го. Позже мем распростронился, как всегда, " +
                    "в паблике 4ch и завоевал Интернет.",
                    Year = 2010,
                    Likes = 0
                }
            };

            
            

            Group[] groups =
            {
                new Group
                {
                    Name = "хайер скул оф мемс | ВШЭ",
                    Url = "https://vk.com/hsemem"
                }
            };

            foreach (Meme m in memes)
            {
                var addressExists = context.Memes.Where(
                    t => t.Name == m.Name).SingleOrDefault();
                if (addressExists == null)
                    repository.SaveImageToDatabase(m);
            }
            //context.Memes.AddOrUpdate(m => m.Name, memes);
            context.Groups.AddOrUpdate(g => g.Name, groups);

        }
    }
}
