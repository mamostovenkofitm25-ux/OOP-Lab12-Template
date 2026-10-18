namespace Lab12_StudentApp
{
    public class Car
    {
        public string Model { get; }

        // Композиція. Властивості лише для читання (get без set): підмінити двигун
        // чи масив коліс ззовні не можна. Усе створюється в конструкторі.
        public Engine CarEngine { get; }
        public Wheel[] Wheels { get; }

        // Агрегація: водій призначається ззовні й може бути null.
        public Driver? CarDriver { get; set; }

        // Одометр (км). Змінюється лише методом Drive().
        public double Mileage { get; private set; }

        public Car(string model)
        {
            Model = model;
            CarEngine = new Engine(150, "Бензин");

            Wheels = new Wheel[4];
            for (int i = 0; i < Wheels.Length; i++)
            {
                Wheels[i] = new Wheel(16);
            }
        }

        // Уже реалізовано (з Лабораторної 11).
        public Driver? RemoveDriver()
        {
            Driver? leaving = CarDriver;
            CarDriver = null;
            return leaving;
        }

        // Завдання 3. Делегування: чи працює двигун цього автомобіля.
        public bool IsEngineRunning
        {
            get { return CarEngine.IsRunning; }
        }

        // Завдання 3. Делегування: заглушіть двигун цього автомобіля.
        public void StopEngine()
        {
            CarEngine.Stop();
        }

        // Завдання 4. Завести двигун. Без водія двигун не заведеш.
        public bool TryStartEngine()
        {
            if (CarDriver == null)
            {
                return false;
            }

            CarEngine.Start();
            return true;
        }

        // Завдання 5. Скільки шин спущено (Wheel.IsFlat). Від 0 до 4.
        public int CountFlatWheels()
        {
            int count = 0;
            foreach (var wheel in Wheels)
            {
                if (wheel.IsFlat)
                {
                    count++;
                }
            }
            return count;
        }

        // Завдання 5. Підкачати КОЖНУ шину на bar бар (як на АЗС).
        public void PumpAllWheels(double bar)
        {
            foreach (var wheel in Wheels)
            {
                wheel.Inflate(bar);
            }
        }

        // Завдання 6. Замінити колесо на позиції index на newWheel.
        public Wheel? ReplaceWheel(int index, Wheel newWheel)
        {
            if (index < 0 || index >= Wheels.Length || newWheel == null)
            {
                return null;
            }

            Wheel oldWheel = Wheels[index];
            Wheels[index] = newWheel;
            return oldWheel;
        }

        // Завдання 7. Оновіть метод з Лабораторної 11. Тепер авто готове до поїздки,
        // лише якщо одночасно: є водій, двигун працює, жодна шина не спущена.
        public bool IsReadyToDrive()
        {
            return CarDriver != null && IsEngineRunning && CountFlatWheels() == 0;
        }

        // Завдання 7. Поїздка на km кілометрів. Повертає, скільки км проїхали.
        public double Drive(double km)
        {
            if (km <= 0 || !IsReadyToDrive())
            {
                return 0;
            }

            Mileage += km;
            return km;
        }
    }
}