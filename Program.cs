namespace AKTARPV22_2_1
{
    public class Program
    {
        public static void Main()
        {
            Message m1 = new Message("Hello", "John", DateTime.Now.AddDays(-10));
            m1.AddLike();
            m1.ShowMessage();
            
            Console.WriteLine(m1.GetPopularity());


            Message m2 = new Message("Hi", "Mary", DateTime.Now.AddMinutes(-1));
            for (int i = 0; i < 10; i++) { m2.AddLike(); }
            m2.ShowMessage();
            
            
            Console.WriteLine(m2.GetPopularity());
            Console.WriteLine(m1.GetPopularityInfo(m1.GetPopularity(),m2.GetPopularity()));

            Message m3 = new Message("Soup", "Alex", DateTime.Now.AddDays(-5));
            Message m4 = new Message("Meee", "Andrei", DateTime.Now.AddMinutes(-45));
            Message m5 = new Message("Grrr", "King", DateTime.Now.AddDays(-30));
            List<Message> list = new List<Message>();
            
            Console.WriteLine(m1.GetPopularityInfoN(list));
        }
    }
}