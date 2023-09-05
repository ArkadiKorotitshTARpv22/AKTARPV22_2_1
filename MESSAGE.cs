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
            private readonly string _content;
            private readonly string _author;
            private readonly DateTime _time;
            private int _likes;
            
            public Message() { }
            public Message(string content, string author, DateTime time)
            {
                this._content = content;
                this._author = author;
                this._time = time;
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
        public void ShowMessage()
        {
            
            Console.WriteLine("Sisu: {0}\nAutor: {1}\nLikes: {2}\n------------", Content,Author,_likes);
        }

        public string GetPopularityInfo(double esimene, double teine)
        {
            string rezult = "";
            if (esimene > teine) { rezult = "Esimene sõnum on populaarsem kui teine"; };
            if (esimene < teine) { rezult = "Teine sõnum on populaarsem kui esimene"; };
            return rezult;
        }

        

        public string GetPopularityInfoN(List<Message> messages)
        {

            string result = "";
            double popularity = 0;
            for (int i=0; i < messages.Count; i++)
            {
                if (messages[i].GetPopularity() > popularity)
                {
                    popularity = messages[i].GetPopularity();
                    result = messages[i].Content + " on kõige populaarsem sõuna, seda kirjutas " + messages[i].Author;
                }

            }

            return result;
        }

    }


        
}
