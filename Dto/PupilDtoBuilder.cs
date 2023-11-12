namespace Student.Web.Api.Dto
{
    // Builder for PupilDto
public class PupilDtoBuilder : IDtoBuilder<PupilDto>
{
    private PupilDto _pupilDto = new PupilDto();

    public PupilDtoBuilder WithStudentInfo(string studentId, string lastName, string firstName, string middleName)
    {
        _pupilDto.StudentId = studentId;
        _pupilDto.LastName = lastName;
        _pupilDto.FirsName = firstName;
        _pupilDto.MiddleName = middleName;
        return this;
    }

    public PupilDto Build()
    {
        return _pupilDto;
    }
}
}