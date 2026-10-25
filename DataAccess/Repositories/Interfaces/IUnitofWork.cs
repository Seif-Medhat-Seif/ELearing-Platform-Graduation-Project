using ELProject.ExternalServices;

namespace ELProject.DataAccess.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAuthRepository Auths { get; }
        IOrderRepository Orders { get; }
        ITransactionRepository Transactions { get; }
        IEnrollmentRepository Enrollments { get; }
        ICourseRepository Courses { get; }
        ICategoryRepository Categories { get; }
        IInstructorRepository Instructors { get; }
        ILessonRepository Lessons { get; }
        IPaymobService PaymobServices { get; }
        IUserRepository Users { get; }
        ISectionRepository Sections { get; }
        IQuizRepository Quizzes { get; }
        Task<int> CompleteAsync();
    }
}