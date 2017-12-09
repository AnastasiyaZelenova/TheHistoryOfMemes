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
                    Description = "���� �������� �������� �������� ������������ " +
                    "���������� ������� ������������� � �� ����-������ ��������� � ������������ " +
                    "�� ���������� ����������. ������������� ������������� ������ �� ��������� � " +
                    "������� �����������, ������ �� �������� ���������������� �� �� �������� ��� " +
                    "��������������. \"Me Gusta\" ��-�������� �������� \"��� ��������\". ��������� ���������� " +
                    "��� Me Gusta ��������� ������������� � ������� �����������, �� ������� ������� " +
                    "��� ����� ������ �������, � ��� �� ���������� � ������� �����. ����� Me Gusta - " +
                    "������������ ������ �������� ����� ���������� \"������� ���\" ��� ����� Insert31990. " +
                    "��� �� ��� ������ �������� � ������ 2010-��. ����� ��� ���������������, ��� ������, " +
                    "� ������� 4ch � �������� ��������.",
                    Year = 2010,
                    Likes = 0
                }
            };

            
            

            Group[] groups =
            {
                new Group
                {
                    Name = "����� ���� �� ���� | ���",
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
