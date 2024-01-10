namespace Day05
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Employee employee = new()
            {
                EmpID = 1,
                Fullname = "huda"
            };

            Console.WriteLine(employee.ToString());

            Employee employee2 = new()
            {
                Fullname = "Bootcamp"
            };
            Console.WriteLine(employee2.ToString());

            Employee employee3 = new()
            {
                Fullname = "Bootcasdasdmp"
            };
            Console.WriteLine(employee3.ToString());
        }
    }
}