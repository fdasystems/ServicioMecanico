using ServicioMecanico.Models;
using ServicioMecanico.Repositories;
using System.Threading.Tasks;

namespace Data
{
    public class UnitOfWork
    {
        public UnitOfWork()
        {
            this.context = new CarServiceEntitiesModel();
        }
        private readonly CarServiceEntitiesModel context;

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

        private GenericRepository<CarBrand> carsBrandRepository;
        public GenericRepository<CarBrand> CarsBrandRepository
        {
            get
            {
                if (this.carsBrandRepository == null)
                {
                    this.carsBrandRepository = new GenericRepository<CarBrand>(this.context);
                }
                return this.carsBrandRepository;
            }
        }

        private GenericRepository<Service> servicesRepository;
        public GenericRepository<Service> ServicesRepository
        {
            get
            {
                if (this.servicesRepository == null)
                {
                    this.servicesRepository = new GenericRepository<Service>(this.context);
                }
                return this.servicesRepository;
            }
        }

        private GenericRepository<ServicesCar> servicesCarRepository;
        public GenericRepository<ServicesCar> ServicesCarRepository
        {
            get
            {
                if (this.servicesCarRepository == null)
                {
                    this.servicesCarRepository = new GenericRepository<ServicesCar>(this.context);
                }
                return this.servicesCarRepository;
            }
        }

        public async Task SaveChangesAsync()
        {
            await this.context.SaveChangesAsync();
        }
    }
}