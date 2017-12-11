namespace ClassLibraryOfMemes.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ContextOfMemes>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ContextOfMemes context)
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
                    Likes = 0,
                    ImagePath = "../../Memes/Me Gusta.jpg"
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

            context.Memes.AddOrUpdate(m => m.Name, memes);

            context.Groups.AddOrUpdate(g => g.Name, groups);
            
        }
    }
}
