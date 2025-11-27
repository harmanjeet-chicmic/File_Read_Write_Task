using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ClosedXML.Excel;
using Newtonsoft.Json;

public class StudentMark
{
    public int RollNumber { get; set; }
    public string Name { get; set; }
    public int Maths { get; set; }
    public int Science { get; set; }
    public int English { get; set; }
    public int SST { get; set; }
    public double Percentage { get; set; }
    public int Rank { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        string filePath = "MOCK_DATA.csv";
        string jsonFilePath = "StudentMarks.json";
        string excelFilePath = "StudentMarks.xlsx";
        int maxMarksPerSubject = 100;
        List<StudentMark> studentMarks = ReadCsv(filePath, maxMarksPerSubject);
        CalculatePercentages(studentMarks, maxMarksPerSubject);
        AssignRanks(studentMarks);
        string json = JsonConvert.SerializeObject(studentMarks, Formatting.Indented);
        File.WriteAllText(jsonFilePath, json);
        ExportToExcel(studentMarks, excelFilePath);
    }

    // --------------read data from csv ---------------
    static List<StudentMark> ReadCsv(string filePath, int maxMarksPerSubject)
    {
        List<StudentMark> studentMarks = new List<StudentMark>();
        using (StreamReader reader = new StreamReader(filePath))
        {
            reader.ReadLine(); 
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(',');
                var student = new StudentMark
                {
                  RollNumber = int.Parse(parts[0]),
                    Name = parts[1],
                    Maths = int.Parse(parts[3]),
                    Science = int.Parse(parts[4]),
                    English = int.Parse(parts[2]),
                    SST = int.Parse(parts[5])
                };
                studentMarks.Add(student);
            }
        }
        return studentMarks;
    }

    // -------------------calculate percentage ------------------------
    static void CalculatePercentages(List<StudentMark> studentMarks, int maxMarksPerSubject)
    {
        foreach (var student in studentMarks)
            {
            int totalMarks = student.Maths + student.Science + student.English + student.SST;
            int totalPossibleMarks = maxMarksPerSubject * 4;
            student.Percentage = (double)totalMarks / totalPossibleMarks * 100;
        }
    }

    // -----------------------------  RANKS ogics-------------------------------
    static void AssignRanks(List<StudentMark> studentMarks)
    {
        var sorted = studentMarks.OrderByDescending(s => s.Percentage).ToList();
        int rank = 1;
        for (int i = 0; i < sorted.Count; i++)
        {
            if (i>0 && sorted[i].Percentage < sorted[i-1].Percentage)
            {
                rank = i + 1; 
            }
            sorted[i].Rank = rank;
        }
    }

    // -------------------
    static void ExportToExcel(List<StudentMark> studentMarks, string filePath)
    {
        using (var workbook = new XLWorkbook())
        {
            var worksheet = workbook.Worksheets.Add("Student Marks");
            worksheet.Cell(1, 1).Value = "Roll Number";
            worksheet.Cell(1, 2).Value = "Name";
            worksheet.Cell(1, 3).Value = "Maths";
            worksheet.Cell(1, 4).Value = "Science";
            worksheet.Cell(1, 5).Value = "English";
            worksheet.Cell(1, 6).Value = "SST";
            worksheet.Cell(1, 7).Value = "Percentage";
            worksheet.Cell(1, 8).Value = "Rank";

            for (int i = 0; i < studentMarks.Count; i++)
            {
                var student = studentMarks[i];
                worksheet.Cell(i + 2, 1).Value = student.RollNumber;
                worksheet.Cell(i + 2, 2).Value = student.Name;
                worksheet.Cell(i + 2, 3).Value = student.Maths;
                worksheet.Cell(i + 2, 4).Value = student.Science;
                worksheet.Cell(i + 2, 5).Value = student.English;
                worksheet.Cell(i + 2, 6).Value = student.SST;
                worksheet.Cell(i + 2, 7).Value = student.Percentage;
                worksheet.Cell(i + 2, 8).Value = student.Rank;
            }

            workbook.SaveAs(filePath);
        }
    }
}
