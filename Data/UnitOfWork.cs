using ServicioMecanico.Models;
using System.Threading.Tasks;

namespace Data
{
    public class UnitOfWork
    {
        public UnitOfWork()
        {
            this.context = new CarServicesEntities();
        }
        private readonly CarServicesEntities context;

        private GenericRepository<Owner> ownersRepository;
        public GenericRepository<Owner> OwnersRepository
        {
            get
            {
                if (this.ownersRepository == null)
                {
                    this.ownersRepository = new GenericRepository<Owner>(this.context);
                }
                return this.ownersRepository;
            }
        }

        private GenericRepository<Car> carsRepository;
        public GenericRepository<Car> CarsRepository
        {
            get
            {
                if (this.carsRepository == null)
                {
                    this.carsRepository = new GenericRepository<Car>(this.context);
                }
                return this.carsRepository;
            }
        }

        public async Task SaveChangesAsync()
        {
            await this.context.SaveChangesAsync();
        }
    }
}