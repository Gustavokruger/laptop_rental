using laptop_rental.Infraestructure.Contexts;

namespace laptop_rental.Persistence.Repositories
{
    public class BaseRepository
    {
        protected readonly DataContext _context;

        public BaseRepository(DataContext context)
        {
            _context = context;
        }
    }
}