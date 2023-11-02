using OpticSalon.Data.Mappers.EntityMapping;

namespace OpticSalon.Data.Repositories
{
    public class BaseRepository
    {
        protected readonly ApplicationContext Context;
        protected DatabaseMapper Mapper = new DatabaseMapper();

        protected BaseRepository(ApplicationContext context)
        {
            Context = context;
        }
    }
}
