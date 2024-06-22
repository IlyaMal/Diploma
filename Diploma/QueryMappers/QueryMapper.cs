using Diploma.DAL.Models;
using Diploma.QueryModels;

namespace Diploma.QueryMappers;

public class QueryMapper
{
    public static Student MapExcelToStudent(QueryStudentModel model)
    {
        return new Student()
        {
            Name = model.Name,
            Nomination = model.Nomination,
            Organisation = model.Organisation,
            Place = model.Place

        };
    }
    
    public static Teacher MapExcelToTeacher(QueryTeacherModel model)
    {
        return new Teacher()
        {
            Name = model.Name,
            Nomination = model.Nomination,
            Organisation = model.Organisation,
            Place = model.Place,
            Position = model.Position

        };
    }
}