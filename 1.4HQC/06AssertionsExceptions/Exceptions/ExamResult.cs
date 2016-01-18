using System;

public class ExamResult
{
    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        if (grade < 0)
        {
            throw new Exception("The grade cannot be 0 or negative");
        }

        if (minGrade < 0)
        {
            throw new Exception("The minimum grade cannot be 0 or negative");
        }

        if (maxGrade <= minGrade)
        {
            throw new Exception("Maximum grade cannot be less then the minimum grade");
        }

        if (string.IsNullOrEmpty(comments))
        {
            throw new Exception("Comments cannot be empty or null");
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }

    public int Grade { get; private set; }

    public int MinGrade { get; private set; }

    public int MaxGrade { get; private set; }

    public string Comments { get; private set; }
}
