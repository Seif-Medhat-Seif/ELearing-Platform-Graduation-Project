using ELProject.Domain.Models;
using ELProject.Shared.DTOs.Instructor;

namespace ELProject.DataAccess.Repositories.Interfaces
{
    public interface IInstructorRepository
    {
        Task<IList<ApplicationUser>> GetAllInstructorsAsync();
        Task<InstructorStatisticsDto> GetInstructorStatisticsAsync(string instructorId);
        Task<IReadOnlyList<InstructorCourseDto>> GetInstructorCoursesAsync(string instructorId);
        Task<IReadOnlyList<RecentActivityDto>> GetRecentActivityAsync(string instructorId, int count = 4);
        Task<InstructorProfileDto> GetInstructorProfileAsync(string instructorId);
        Task<bool> EditInstructorProfileAsync(string instructorId, EditInstructorProfileDto dto);
    }
}
