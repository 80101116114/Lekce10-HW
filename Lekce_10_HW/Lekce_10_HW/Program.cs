namespace Lekce_10_HW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            var names = new List<string> { "Alice", "Bob", "Charlie", "Diana", "Edward", "Fiona", "George", "Hannah", "Ian", "Julia" };
            var students = new List<Student>();

            for (int i = 0; i < 100; i++)
            {
                var student = new Student
                {
                    Name = names[random.Next(names.Count)] + i,
                    Age = random.Next(18, 25),
                    Grades = new List<int> { random.Next(20, 100), random.Next(50, 100), random.Next(70, 100) }
                };
                students.Add(student);
            }
            var studentNames = students.Select(x => x.Name).ToList();
            Console.WriteLine("Seznam studentu " );
            Console.WriteLine(string.Join("," , studentNames));

            var studentGrade = students.Where(x => x.Grades.Any(z => z > 90)).ToList();
            Console.WriteLine("Studenti, kteri maji alespon jednu znamku vyssi nez 90: " );

            foreach (var student in studentGrade)
            {
                Console.WriteLine(student.Name + " Známky: " + string.Join(", ", student.Grades));
            }

            var allGradesHigherThan80 = students.Any(x => x.Grades.All(z => z > 80)).ToString();
            Console.WriteLine("Ma nejaky student vsechny znamky vyssi nez 80? Odpoved = " + allGradesHigherThan80);
            
            
            var seznamUspesnychStudentu = students.Where(x => x.Grades.All(z => z > 80)).ToList();
            var pocetUspesnychStudentu = seznamUspesnychStudentu.Count();
            Console.WriteLine("Pocet studentu, kteri maji vsechny znamky vyssi nez 80: "+ pocetUspesnychStudentu);
            foreach (var student in seznamUspesnychStudentu)
            {
                Console.WriteLine("Student " + student.Name + " Známky: " + ( string.Join(", ", student.Grades)));
            }
            

            var allGrades = students.SelectMany(x => x.Grades).ToList();
            Console.WriteLine("Vsechny znamky studentu");
            Console.WriteLine(string.Join("," +
                " ", allGrades));

            var sortAge = students.OrderBy(x => x.Age).ToList();
            Console.WriteLine("Serazeny vek studentu");
            
            foreach (var student in sortAge)
            {
               
                Console.Write("Student: "+ student.Name + " ma: "+  student.Age+ " let, ");
            }
           
        }
    }
}
