﻿namespace ClassLibraryOfMemes.Migrations
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
                    Description = "Этот персонаж способен выражать удовольствие " +
                    "совершенно разного происхождения и от чего-нибудь порочного и неприличного " +
                    "до совершенно обыденного. Первоначально использовался только по отношению к " +
                    "половым извращениям, однако со временем распространилось на всё странное или " +
                    "отвратительное. «Me Gusta» по-испански означает «мне нравится». Поскольку изначально " +
                    "мем Me Gusta относился исключительно к половым извращениям, то принято считать " +
                    "эту фразу слегка ехидной, о том же напоминает и ухмылка фейса. Автор Me Gusta - " +
                    "пользователь одного хорошего сайта художников «Девиант Арт» под ником Insert31990. " +
                    "Сам же мем возник примерно в ноябре 2010-го. Позже мем распространился, как всегда, " +
                    "в имиджборде 4chan и завоевал Интернет.",
                    Year = 2010,
                    Likes = 0,
                    ImagePath = "/Memes/MeGusta.jpg"
                },
                new Meme
                {
                    Name = "Лягушонок Пепе",
                    Description = "Первое появление лягушки состоялось в серии комиксов " +
                    "«Boy's Club», авторства Мэта Фьюри. На оригинальных изображениях лягушонок улыбался. " +
                    "Из черно-белого комикса были взяты основные позы и выражения лица будущего мема. Впрочем, " +
                    "до 2008 года о нем никто не знал, пока картинку не запостили на имиджборде 4chan. Именно на 4chan " +
                    "лягушонка сделали грустным, опустив уголки губ вниз с помощью фотошопа. Там же морду Пепе " +
                    "раскрасили в уже привычный теперь зеленый цвет. Сейчас лягушка Пепе часто используется с " +
                    "устоявшимся выражением «тебе никогда не узнать, как» выполнять какое-то действие. Иногда к " +
                    "картинке с лягушонком просто добавляют жизненную надпись о чем-то печальном.",
                    Year = 2005,
                    Likes = 0,
                    ImagePath = "/Memes/PepeTheFrog.jpg"
                },
                new Meme
                {
                    Name = "Скрывающий боль Гарольд",
                    Description = "Дед Гарольд (Hide The Pain Harold, скрывающий боль Гарольд) — серия стоковых " +
                    "фотографий, ставших популярными благодаря необычному выражению мужчины. Сквозь натянутую улыбку " +
                    "Гарольда пробивается глубокая скрытая боль. Мода смеяться над фотографиями со стоков появилась " +
                    "примерно в 2015 году. Именно тогда было создано множество пабликов, смеивающих неловкие " +
                    "положения людей на фотографиях. Одной из таких моделей был пожилой седой мужчина, чьи фотографии " +
                    "использовали в рекламе различных товаров и услуг для пенсионеров. Фотографии деда появились на " +
                    "ресурсе dreamstime. Впервые деда в качестве шутки использовали на сайте Facepunch от 13 сентября " +
                    "2011 года: стоковую фотографии с ним опубликовал пользователь под ником Greenen72. 3 марта " +
                    "2016 года Гарольд заявил о себе. Он завел личную страницу во «ВКонтакте», из которой мы " +
                    "узнали, что мужчина из Венгрии, а зовут его Арато Андраш(Arató András). Личность Андраша " +
                    "верифицировало сообщество Hide The Pain Harold & Co.",
                    Year = 2011,
                    Likes = 0,
                    ImagePath = "/Memes/Harold.jpg"
                },
                new Meme
                {
                    Name = "Вжух",
                    Description = "Вжух — кот-волшебник с колпаком и нарисованной палочкой, которая исполняет " +
                    "любые желания. Под магической пыльцой на картинке обычно приписывают «Вжух, и ты…». " +
                    "Всё началось с фотографии грустного кота в праздничном колпаке на руках у бородатого мужчины. " +
                    "Изображение появилось в 2013 году в англоязычном интернете. Популярной фотография стала после " +
                    "публикации на сайте Just Cute Animals с подписью «Я толстый, давайте веселиться». " +
                    "Годом позже фотография была замечена на сайте Funnienst Memes с подписью «Мне нужно свериться с картами». " +
                    "По данным издания TJ, автором оригинального «Вжуха» является молодой человек под ником Man-In Gabba. " +
                    "Он утверждает, что увидел картинку про кота-волшебника с длинной надписью и решил её сократить. " +
                    "Так и появился Вжух. Упрощённая картинка с незамысловатой надписью впервые появилась 6 ноября " +
                    "2016 года в сообществе MIG. Уже оттуда мем разлетелся по всем пабликам и стал мегапопулярным к концу декабря.",
                    Year = 2016,
                    Likes = 0,
                    ImagePath = "/Memes/Vzhukh.jpg"
                },
                new Meme
                {
                    Name = "Угрюмый кот",
                    Description = "Grumpy cat (угрюмый кот) — бело-коричневый кот с голубыми глазами и опущенными " +
                    "вниз уголками рта, что придает его морде предельно угрюмый вид. Выражает грусть, печаль, " +
                    "угрюмое, унылое настроение. Кошка, которой было суждено стать знаменитой Grumpy cat в 2012, " +
                    "появилась в семье Табаты Бундесен из Аризоны. Дочь Табаты назвала животное Соус Тардар (Tardar Sauce), " +
                    "потому что пятнышки на ее шерсти напомнили ей соус тартар. Девочка ошиблась на одну букву, " +
                    "но кличку решили оставить. Брат Табаты Брайан сфотографировал кошку в сентябре 2012 года и " +
                    "опубликовал фото на Reddit. Интернет буквально влюбился в Grumpy cat, в 2013 ее признали " +
                    "«Мемом года» по версии  Webby Award. На страницу кошки в фейсбуке подписаны 8,7 миллионов " +
                    "человек. Grumpy cat является примером коммерчески успешного мема, по подсчетам прессы, уже в " +
                    "2014 году семья Бундесен заработала на кошке около 100 миллионов долларов. Сердитый котик стал " +
                    "культурным феноменом, сходство с которым стали искать в других животных и людях.",
                    Year = 2013,
                    Likes = 0,
                    ImagePath = "/Memes/GrumpyCat.jpg"
                },
                new Meme
                {
                    Name = "Роберт Дауни закатывает глаза",
                    Description = "Роберт Дауни закатывает глаза (Твое лицо, когда, Tony Stark face) — мем-фейс " +
                    "с фотографией актера Роберта Дауни младшего, который стоит, скрестив руки на груди, и " +
                    "закатывает глаза, выражая недовольство. Используется как реакция на ситуации, вызывающие " +
                    "недовольство или раздражение. Кадр взят из фильма «Мстители» 2012 года о вселенной " +
                    "супергероев Marvel, где Роберт Дауни Младший сыграл Тони Старка (Железного человека). " +
                    "Сначала кадр с закатывающим глаза Дауни гулял по англоязычному интернету, к концу 2012 года " +
                    "картинка появилась в пабликах «ВКонтакте» и стала широко использоваться в рунете благодаря «Пикабу».",
                    Year = 2012,
                    Likes = 0,
                    ImagePath = "/Memes/TonyStarkFace.jpg"
                },
                new Meme
                {
                    Name = "Моя остановочка",
                    Description = "Моя остановочка — изображение с различными органами, которые, совершая остановку " +
                    "в какой-то момент жизни, выражают собеседнику почтение, приподнимая свою шляпу. В меме фигура " +
                    "речи приобретает физическое воплощение. Прикрученные к органам перчатки с тростью и шляпой являются " +
                    "частью образа героя российского мультипликационного сериала «Смешарики», медведя Копатыча. " +
                    "Он предстал в экстравагантном амплуа во второй серии «Смешарики — Новогодняя сказка».",
                    Year = 2013,
                    Likes = 0,
                    ImagePath = "/Memes/MyStation.jpg"
                },
                new Meme
                {
                    Name = "Остров проклятых",
                    Description = "Остров проклятых — комикс, на котором персонажи Леонардо Ди Каприо и " +
                    "Марка Руффало обмениваются фразами, а в конце Лео обиженно молчит. Комикс основан на кадрах " +
                    "из мистического триллера Мартина Скорсезе «Остров проклятых» (2009). По сюжету два судебных " +
                    "пристава отправляются на остров в штате Массачусетс, чтобы расследовать исчезновение пациентки " +
                    "клиники для умалишенных преступников. Их диалог в начале фильма и стал основой для мема. Обычно " +
                    "мем имеет четкую структуру. На первой картинке Марк Руффало что-то спрашивает у Лео, на второй " +
                    "следует ответ. На третьей картинке Руффало задает уточняющий вопрос, и его собеседник отворачивается, " +
                    "делает кислую мину и молчит. В некоторых вариантах он отвечает что-то сквозь зубы. Есть и укороченные " +
                    "варианты мема. В них есть только один вопрос и реакция Лео.",
                    Year = 2009,
                    Likes = 0,
                    ImagePath = "/Memes/ShutterIsland.jpg"
                },
                new Meme
                {
                    Name = "Избирательный Дрейк",
                    Description = "Избирательный Дрейк (Drakeposting) — четырехпанельный комикс с канадским рэпером " +
                    "Дрейком в оранжевой куртке, который отмахивается от чего-то рукой. Используется, чтобы показать " +
                    "отрицательное и положительное отношение к двум похожим объектам. 20 октября 2015 года вышел клип " +
                    "канадского рэп-исполнителя Дрейка на песню Hotline Bling. В музыкальном ролике рэпер танцует в " +
                    "разных костюмах, включая оранжевую курточку. Сначала пользователей удивили странные танцевальные " +
                    "движения Дрейка. И из этого на короткое время вылилась волна вайнов, коубов и нарезок. И осенью " +
                    "2015 года главным трендом англоязычного твиттера были ролики с танцующим под разную музыку Дрейком. " +
                    "В том же 2015 году пользователи имиджборда 4chan стали первыми использовать стоп-кадры из клипа " +
                    "в качестве картинок-макросов. Особенно полюбился кадр с Дрейком в оранжевой куртке, который делает " +
                    "жест рукой, означающий отказ или неприятие чего-то. В таком виде мем некоторое время циркулировал " +
                    "в англоязычном интернете, пока не приобрел новую форму, в какой и известен русскоязычному пользователю.",
                    Year = 2015,
                    Likes = 0,
                    ImagePath = "/Memes/Drake.jpg"
                },
                new Meme
                {
                    Name = "Умный негр",
                    Description = "Негр с пальцем у виска (Roll Safe) — темнокожий парень в черной кожаной куртке и с золотыми " +
                    "часами на руке прикладывает к виску палец, намекая на мыслительный процесс. Используется для иллюстрации " +
                    "очевидных и бесполезных советов. Летом 2016 года на BBC Three вышел сериал Hood Documentary с короткими " +
                    "выпусками, снятыми как имитация документального кино. Актер Кайод Овуми (Kayode Ewumi) играет в нем Риза " +
                    "Симпсона по прозвищу Roll Safe. Риз рассказывает в одной из серий о своей девушке Рейчел. В этот момент " +
                    "он прикладывает палец к виску. Осенью на кадр обратили внимание в англоязычном твиттере, а в январе 2017 " +
                    "года он распространился достаточно широко и стал полноценным мемом. Мем называют Roll Safe по имени " +
                    "персонажа или You can`t fail it if you drop it («Ты не сможешь провалиться в чем-то, если бросишь это дело»). " +
                    "В рунете стал активно распространяться в феврале 2017 года под названиями «Умный негр», «Негр с пальцем " +
                    "у виска».",
                    Year = 2017,
                    Likes = 0,
                    ImagePath = "/Memes/RollSafe.jpg"
                },
                new Meme
                {
                    Name = "Неверный парень",
                    Description = "Неверный парень (Disloyal man, Я и мои слабости) — мем, основанный на стоковой фотографии про " +
                    "парня, который, пока идёт по улице за ручку со своей девушкой, оглядывается на другую девушку. Мем " +
                    "состоит из трех персонажей: условный Я, условная мечта или желание и условное препятствие на пути " +
                    "к этому желанию. А дальше действует фантазия. Шаблоном для мема послужила обычная стоковая фотка с сайта " +
                    "Shutterstock. В фотобанке она так и называется: «Неверный парень идет со своей девушкой и оглядывается " +
                    "на другую красотку». В январе турецкое сообщество, посвященное прогрессивному року, опубликовало шутку " +
                    "про музыканта Фила Коллинза, который хочет изменить року с попсой. В феврале 2017 года пользователь " +
                    "Инстаграма под ником _dekhbai_ опубликовал фотографию, предложив другим пользователям упоминать в " +
                    "комментариях своих друзей, которые влюбляются каждый месяц. В середине августа эту картинку взяли на " +
                    "вооружение пользователи Твиттера и стали штамповать свои варианты, кем этот парень может быть и на " +
                    "что он может оглядываться с таким выражением.",
                    Year = 2017,
                    Likes = 0,
                    ImagePath = "/Memes/DisloyalMan.jpg"
                },
                new Meme
                {
                    Name = "Подлый Том",
                    Description = "Ребята, я в этом шарю (Sneaky Tom, Подлый Том) — мем с изображением Тома из «Тома и Джерри», " +
                    "который выходит из комнаты. Символизирует подлый поступок или самоуверенность. Кадр с Томом, ставший " +
                    "мемом, вырезан из серии «Джерри и Лев» (Jerry and the Lion) 1950 года. В этом эпизоде мышонок Джерри " +
                    "прикрывает сбежавшего из зоопарка льва. Во время пребывания льва в доме Тома и Джерри, мышонок делает " +
                    "попытки добыть еду для своего нового друга. И в это время за ним постоянно охотится Том. Многие думают, " +
                    "что на картинке Том открывает дверь и заходит в комнату. Но в оригинале кот не заходит, а выходит из " +
                    "комнаты в кладовку, куда проник Джерри. С хитрым видом и в предвкушении мести Том закрывает за собой дверь, " +
                    "но не знает, что внутри его ждёт огромный Лев. Кадр из мультфильма стал мемом в 2013 году. Пользователи " +
                    "выкладывали его в Твиттере с различными подписями о подлых ситуациях в жизни. В рунете мем стал " +
                    "распространяться с подписью «Ребята, я в этом шарю».",
                    Year = 2013,
                    Likes = 0,
                    ImagePath = "/Memes/SneakyTom.jpg"
                }
            };

            Group[] groups =
            {
                new Group
                {
                    Name = "хайер скул оф мемс | ВШЭ",
                    Url = "https://vk.com/hsemem"
                },
                new Group
                {
                    Name ="4ch",
                    Url = "https://vk.com/cs_4ch"
                },
                new Group
                {
                    Name = "9GAG",
                    Url = "https://vk.com/ru9gag"

                },
                new Group
                {
                    Name = "Бездна книжного уюта",
                    Url = "https://vk.com/bezdna_bku"
                },
                new Group
                {
                    Name = "Смейся до слёз",
                    Url = "https://vk.com/ifun"
                },
                new Group
                {
                    Name = "Биржа мемов",
                    Url = "https://vk.com/leprofun"
                },
                new Group
                {
                    Name = "1001 мем",
                    Url = "https://vk.com/mem1001"
                },
                new Group
                {
                    Name = "абстрактные мемы для элиты всех сортов",
                    Url = "https://vk.com/abstract_memes"
                },
                new Group
                {
                    Name = "Душоновская Уточка",
                    Url = "https://vk.com/dushonovskayautka"
                }
            };

            context.Memes.AddOrUpdate(m => m.Name, memes);

            context.Groups.AddOrUpdate(g => g.Name, groups);
            
        }
    }
}
