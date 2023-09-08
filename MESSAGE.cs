using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace AKTARPV22_2_1
{
    public class Message
    {
        List<string> messagelist = new List<string> { "Tere", "Hello", "Bonjour", "Morgen", "TAR","Privet" };
        private readonly string _content;
        private readonly string _author;
        private readonly DateTime _time;
        private int _likes;

        public Message(string content, string author, DateTime time)
        {
            this._content = content;
            this._author = author;
            this._time = time;
        }
        public Message() 
        {

        }
        public int Likes { get => _likes; }
        public DateTime Time { get => _time; }
        public string Author { get => _author; }
        public string Content { get => _content; }

        public void AddLike()
        {
            _likes++;
        }

        public double GetPopularity()
        {
            double elapsed = DateTime.Now.Subtract(this._time).TotalSeconds;
            if (elapsed == 0)
            {
                return _likes;
            }
            return _likes / elapsed;

        }

        public void ShowMessageInfo()
        {
            Console.WriteLine();
            Console.WriteLine("Tekst = " + Content);
            Console.WriteLine("Aeg = " + Time);
            Console.WriteLine("Likes = " + Likes);
            Console.WriteLine("Populaarsus = " + GetPopularity());
        }

        public void GetPopularityInfo(List<Message> messages)
        {
            Message koigepopularmessage = new Message();
            double popcounter = 0;
            foreach (Message message in messages)
            {
                if (message.GetPopularity() > popcounter)
                {
                    popcounter = message.GetPopularity();
                    koigepopularmessage = message;
                }
            }
            
            Console.WriteLine("kõige populaarsem sõnum on " + koigepopularmessage.Content + " ja tema autor on " + koigepopularmessage.Author);

        }

        public void Popularitycheck(double esimine, double teine)
        {
            double checknum = esimine - teine;
            if (checknum > 0)
            {
                Console.WriteLine("m1 on populaarsem");
            }
            else if (checknum < 0)
            {
                Console.WriteLine("m2 on vähem populaarne");
            }
            else
            {
                Console.WriteLine("m1 ja m2 on populaarsuse poolest samad");
            }
            return;
        }

        public static void MainAuto()
        {
            List<Message> messagelist = new List<Message> { };

            Random rnd = new Random();
            int like_counter = 0;
            int counter = rnd.Next(2, 5);
            Console.WriteLine("Loo {0} sõnumit", counter);
            for (int i = 0; i < counter; i++)
            {
                Console.WriteLine("Luua sõnum number {0}", i + 1);
                string messagetext = Console.ReadLine();
                Console.WriteLine("Mis on teie kasutajanimi");
                string username = Console.ReadLine();
                int t = -1 * rnd.Next(0, 1000000);
                DateTime dhm = DateTime.Now.Date.AddSeconds(t);

                Message newmessage = new Message(messagetext, username, dhm);
                like_counter = rnd.Next(0, 50);
                for (int ii = 0; ii < like_counter; ii++)
                {
                    newmessage.AddLike();

                }
                messagelist.Add(newmessage);
                messagelist[i].ShowMessageInfo();

                Console.WriteLine();
            }
            messagelist[0].GetPopularityInfo(messagelist);


        }
    }



}
