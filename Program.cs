namespace CSBeadando
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<Employee> boschEmployee = new HashSet<Employee>()
            {
                new Employee("Kis Jozsef", "4/10/2000", "+36201234567", 600000),
                new Employee("Kovacs Ferenc", "4/10/1735", "+36201244567", 600000),
                new Employee("Varga Árpád", "1/4/2004", "+36201234887", 400000),
                new Employee("Seprenyi Kristóf", "1/12/2001", "+36308234567", 1000000)
            };
            Console.WriteLine("Bosch employee HashSet count: {0}", boschEmployee.Count);

            boschEmployee.Add(new Employee("Szabó Zoltán", "4/10/2000", "+36201282567", 500000));
            Employee fajderPatrik = new Employee("Pfizer Patrik Zoltán", "03/04/2001", "+36706666969", 0);
            boschEmployee.Add(fajderPatrik);
            Console.WriteLine("Bosch employee HashSet count after added two Employee: {0}", boschEmployee.Count);

            Thread thread = new Thread(() => AddMoreToHashSet(boschEmployee));
            Console.WriteLine(thread.ThreadState.ToString());

            thread.Start();


            thread.Join();

            Console.WriteLine(thread.ThreadState.ToString());

            HashSet<Employee> otherEmployee = new HashSet<Employee>()
            {
                new Employee("Gyenge Jellem", "4/10/2000", "+36201282567", 500000),
                new Employee("Erős Jellem", "4/10/2000", "+36201282567", 500000),
                new Employee("Közepes Jellem", "4/10/2000", "+36201282567", 500000)
            };

            otherEmployee.Add(new Employee("xd Jellem", "4/10/2000", "+36201282567", 500000));
            Console.WriteLine("Other employee HashSet count: {0}", otherEmployee.Count);

            Employee Kristof = new Employee("Seprenyi Kristóf", "1/12/2001", "+36308234567", 1000000);
            bool b = boschEmployee.Contains(Kristof);
            Console.WriteLine("HashSet contains Employee Seprenyi Kristof (1/12/2001, +3630...): {0}", b);

            List<Employee> intersectEmployees = new List<Employee>() {
                new Employee("Kis Jozsef", "4/10/2000", "+36201234567", 600000),
                new Employee("Kovacs Ferenc", "4/10/1735", "+36201244567", 600000),
                new Employee("Varga Árpád", "1/4/2004", "+36201234887", 400000),
                new Employee("Seprenyi Kristóf", "1/12/2001", "+36308234567", 1000000)
            };

            boschEmployee.IntersectWith(intersectEmployees);
            Console.WriteLine("HashSet count after IntersectWith: {0}", boschEmployee.Count);

            boschEmployee.UnionWith(otherEmployee);
            Console.WriteLine("HashSet count after UnionWith: {0}", boschEmployee.Count);



        }

        internal static void AddMoreToHashSet(HashSet<Employee> hashset)
        {
            Console.WriteLine(Thread.CurrentThread.ThreadState.ToString());
            ConsoleKeyInfo info;
            do
            {
                try
                {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                    Console.Write("Add the Employee's name: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                    string name = Console.ReadLine();
                    Console.Write("Add date of birt (dd/MM/yyyy): ");
                    string birth = Console.ReadLine();
                    Console.Write("Add phone number: ");
                    string number = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                    Console.Write("Add salary: ");
                    int salary = 0;
                    Int32.TryParse(Console.ReadLine(), out salary);
                    if (!name.Equals(null) && !birth.Equals(null) && !number.Equals(null) && !salary.Equals(null)) { hashset.Add(new Employee(name, birth, number, salary)); }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                }
                catch (Exception) { Console.WriteLine("Incorrect input!!!"); }

                Console.WriteLine("Press ESC to quit or press ANY BUTTON to add another employee");
                info = Console.ReadKey(false);
                if (info.Key == ConsoleKey.Escape) return;

            } while (true); //while(info.Key != ConsoleKey.Escape);
        }
    }
}