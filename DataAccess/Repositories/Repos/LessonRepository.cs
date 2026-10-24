using ELProject.DataAccess.Repositories.Interfaces;
using ELProject.Domain.Models;
using ELProject.ExternalServices;
using ELProject.Shared.DTOs.Lessons;
using Microsoft.EntityFrameworkCore;

namespace ELProject.DataAccess.Repositories.Repos
{
    public class LessonRepository : Repository<Lesson, int>, ILessonRepository
    {
        private readonly AppDbContext _context;
        private readonly IFileStorageService _fileService;

        public LessonRepository(AppDbContext context, IFileStorageService fileService) : base(context)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<IEnumerable<Lesson>> GetLessonsBySectionId(int sectionId)
        {
            return await _context.Lessons
                .AsNoTracking()
                .Where(l => l.SectionId == sectionId)
                .OrderBy(l => l.Order)
                .ToListAsync();
        }

        public async Task<Lesson?> GetLessonWithInstructorId(string instructorId, int lessonId)
        {
            return await _context.Lessons
                .AsNoTracking()
                .Include(l => l.Section)
                .ThenInclude(s => s.Course)
                .Where(l => l.Section.Course.UserId == instructorId)
                .FirstOrDefaultAsync(l => l.Id == lessonId);
        }

        public async Task<int?> GetOrderOfLastLessonInSection(int sectionId)
        {
            return await _context.Lessons
            .Where(l => l.SectionId == sectionId)
            .MaxAsync(l => (int?)l.Order); // return null if there aren't lessons in the section
        }

        public async Task UpdateLesson(Lesson lesson, UpdateLessonDto dto)
        {
            if (dto.File != null)
            {
                if (!string.IsNullOrEmpty(lesson.FileUrl))
                    await _fileService.DeleteFileAsync(lesson.FileUrl, lesson.Type);

                var url = await _fileService.UploadFileAsync(dto.File, dto.Type);
                lesson.FileUrl = url;
                lesson.DurationInSeconds = dto.DurationInSeconds;
            }

            lesson.Title = dto.Title ?? lesson.Title;
            lesson.Order = dto.Order == 0 ? lesson.Order : dto.Order;
            lesson.Type = dto.Type;

            _context.Lessons.Update(lesson);
        }
    }
}
