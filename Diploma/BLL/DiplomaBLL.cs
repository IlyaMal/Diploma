using Diploma.DAL;
using Diploma.DAL.Models;
using SixLabors.ImageSharp;

namespace Diploma.BLL;

public class DiplomaBLL: IDiplomaBLL
{
    public readonly ISettingDAL _SettingDal;
    public readonly ITeacherDAL _TeacherDal;
    public readonly IStudentDAL _StudentDal;


    public DiplomaBLL(ISettingDAL settingDal, ITeacherDAL teacherDal, IStudentDAL studentDal)
    {
        _SettingDal = settingDal;
        _TeacherDal = teacherDal;
        _StudentDal = studentDal;
    }

    public async Task AddStudentAsync(Student model)
    {
        await _StudentDal.AddStudentAsync(model);
    }

    public async Task AddTeacherAsync(Teacher model)
    {
        await _TeacherDal.AddTeacherAsync(model);
    }

    public async Task AddSettingsAsync()
    {
        throw new NotImplementedException();
    }

    public async Task DiplomaGeneration()
    {
        Image image;
        Generate gen = new Generate();
        var settings = await _SettingDal.GetAllSettingsAsync();

        var students = await _StudentDal.GetAllStudentAsync();
        foreach (Student student in students)
        {
            image = Image.Load("C:\\Users\\vombe\\OneDrive\\Рабочий стол\\Лаборатория\\Diploma\\Diploma\\Diploma\\DAL\\src\\foo.png");
            image = gen.AddTextToImage(image, student.Name??"", settings[0].fontSize, settings[0].x, settings[0].y, Color.Red);
            image = gen.AddTextToImage(image, student.Organisation??"", settings[1].fontSize, settings[1].x, settings[1].y, Color.Black);
            image = gen.AddTextToImage(image, student.Place??"", settings[2].fontSize, settings[2].x, settings[2].y, Color.Red);
            image = gen.AddTextToImage(image, student.Nomination??"", settings[3].fontSize, settings[3].x, settings[3].y, Color.Black);
            image.Save($"Diplomas/Ученики/{student.Name.Trim( new Char[] { '"', '*', '.' } )+Guid.NewGuid()}.png");
            
        }
        var teachers = await _TeacherDal.GetAllTeachersAsync();
        foreach (Teacher teacher in teachers)
        {
            image = Image.Load("C:\\Users\\vombe\\OneDrive\\Рабочий стол\\Лаборатория\\Diploma\\Diploma\\Diploma\\DAL\\src\\foo.png");
            image = gen.AddTextToImage(image, teacher.Name??"", settings[0].fontSize, settings[0].x, settings[0].y, Color.Red);
            image = gen.AddTextToImage(image, teacher.Organisation??"", settings[1].fontSize, settings[1].x, settings[1].y, Color.Black);
            image = gen.AddTextToImage(image, teacher.Place??"", settings[2].fontSize, settings[2].x, settings[2].y, Color.Red);
            image = gen.AddTextToImage(image, teacher.Nomination??"", settings[3].fontSize, settings[3].x, settings[3].y, Color.Black);
            image = gen.AddTextToImage(image, teacher.Position??"", settings[4].fontSize, settings[4].x, settings[4].y, Color.Black);

            image.Save($"Diplomas/Учитель/{teacher.Name.Trim( new Char[] { '"', '*', '.' } )+Guid.NewGuid()}.png");
            
        }
        
    }
}