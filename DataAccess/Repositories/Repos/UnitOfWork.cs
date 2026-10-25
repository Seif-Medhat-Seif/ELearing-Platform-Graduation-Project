using ELProject.DataAccess.Repositories.Interfaces;
using ELProject.ExternalServices;
namespace ELProject.DataAccess.Repositories.Repos
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IAuthRepository Auths { get; }
        public IOrderRepository Orders { get; }
        public ITransactionRepository Transactions { get; }
        public IEnrollmentRepository Enrollments { get; }
        public ICourseRepository Courses { get; }
        public ICategoryRepository Categories { get; }
        public IInstructorRepository Instructors { get; }
        public IPaymobService PaymobServices { get; }
        public IUserRepository Users { get; }
        public ILessonRepository Lessons { get; }
        public ISectionRepository Sections { get; }
        public IQuizRepository Quizzes { get; }

        public UnitOfWork(
            AppDbContext context,
            IAuthRepository auths,
            IOrderRepository orders,
            ITransactionRepository transactions,
            IEnrollmentRepository enrollments,
            ICourseRepository courses,
            ICategoryRepository categories,
            IInstructorRepository instructors,
            IPaymobService paymobServices,
            IUserRepository users,
            ILessonRepository lessons,
            ISectionRepository sections,
            IQuizRepository quizzes)
        {
            _context = context;

            Auths = auths;
            Orders = orders;
            Transactions = transactions;
            Enrollments = enrollments;
            Courses = courses;
            Categories = categories;
            Instructors = instructors;
            PaymobServices = paymobServices;
            Users = users;
            Lessons = lessons;
            Sections = sections;
            Quizzes = quizzes;
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}