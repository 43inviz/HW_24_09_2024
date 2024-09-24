namespace HW_24_09
{

    class Room
    {
        private int _roomNumber;
        private Thread _thread;
        private static readonly Random _random = new Random();
        private bool _isRunning;



        public Room(int roomNumber)
        {
            _roomNumber = roomNumber;
            _thread = new Thread(MonitorTemperature);
            _isRunning = true;
        }



        public void Start() {
            _thread.Start();
        }

        public void Stop()
        {
            _isRunning = false;
        }


        private void MonitorTemperature()
        {
            while (_isRunning)
            {
                int temparature = _random.Next(-10,35);
                Console.WriteLine($"Room {_roomNumber}:  Temperature = {temparature}'c'");
                int sleepTime = _random.Next(2, 6) * 1000;
                Thread.Sleep( sleepTime );
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Room> rooms = new List<Room>();
            for(int i = 1; i <= 5; i++)
            {
                rooms.Add(new Room(i));
            }



            foreach(var el in rooms)
            {
                el.Start();
            }


            Thread.Sleep(30000);
            

            foreach(var el in rooms)
            {
                el.Stop();
            }
        }
    }
}
