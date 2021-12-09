using System;
using System.Collections.Generic;

namespace _9_dec_assignment
{
    public enum Gender
    {
        Male= 1,
        Female= 2,
        Othe= 3
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            int batchCount = 3;
            int studentCount = 12;
           

            List<Student> students = new List<Student>();
            Random random = new Random();
            for (int count = 0; count < studentCount; count++)// adding students
            {
                Student stud = new Student()
                {
                    StudentId = count+1,
                    StudentName = ((char)random.Next(65, 90)).ToString(),
                    Sex= (Gender)random.Next(1,3),
                    
                };
                students.Add(stud);   
            }
            List<Batch> Batches = new List<Batch>();
            int countStud = 0;
            for (int count = 0; count < batchCount; count++)//adding batches
            {
                List<Student> studentBatch = new List<Student>();//adding student to a temp list so tht can be directly added to batch list of batch class
                for (int studCount = 0; studCount < 4; studCount++)
                {
                    studentBatch.Add(students[countStud]);
                    countStud++;
                }
                try
                {
                    Batch batch = new Batch() //adding students and associated batches to batch list
                    {
                        Id = count + 1,
                        Name = $"Batch_{(char)(count + 65)}",
                        student = studentBatch

                    };

                    Batches.Add(batch);                    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                   
                }
                
            }
            foreach (var batch in Batches)//printing all students 
            {
                Batch.Print(batch);
                Console.WriteLine();
            }
            Batch.GetStudent(Batches, 3, 8);//swaping student with id 3 and 8
            foreach (var batch in Batches)
            {
                Batch.Print(batch);
            }



        }
        public class Student
        {
            public int StudentId { get; set; }
            public string StudentName { get; set; }
            public Gender Sex { get; set; }
        }
        public class Batch
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public List<Student> student { get; set; }
            public static void Print(Batch batch)//print function for individual Batch
            {
                try
                {
                    Console.WriteLine(batch.Id);
                    Console.WriteLine(batch.Name);
                    batch.student.ForEach(stud => Console.WriteLine("ID: {0} \nName: {1} \nGender: {2}", stud.StudentId, stud.StudentName, stud.Sex));
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            public static void GetStudent(List<Batch> allbatch, int studentIdOne, int studentIdTwo)//swap function to swap students
            {
                int batchOne =0, studentOne =0, batchTwo=0, studentTwo=0;   
                for (int i = 0; i < allbatch.Count; i++)
                {
                    for (int j = 0; j < allbatch[i].student.Count; j++)
                    {
                        if (allbatch[i].student[j].StudentId == studentIdOne)
                        {
                            batchOne = i;
                            studentOne = j;
                        }
                        else if (allbatch[i].student[j].StudentId == studentIdTwo)
                        {
                            batchTwo = i;
                            studentTwo = j;
                        }
                    }
                }
                object temp;
                temp = allbatch[batchOne].student[studentOne];
                allbatch[batchOne].student[studentOne]= allbatch[batchTwo].student[studentTwo];
                allbatch[batchTwo].student[studentTwo]=(Student)temp;
            }



        }

    }
}
