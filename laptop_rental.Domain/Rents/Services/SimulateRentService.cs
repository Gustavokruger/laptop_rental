using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using laptop_rental.Dtos;
using laptop_rental.laptop_rental.Domain.Rents.Services.Interfaces;

namespace laptop_rental.laptop_rental.Domain.Rents.Services
{
    public class SimulateRentService : ISimulateRentService
    {
        public SimulateRent simulate(SimulateRent rent)
        {
            int daysAmount = (
                    DateTime
                    .ParseExact(
                        rent.rentExpirationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces)
                    .Subtract(
                        DateTime
                        .ParseExact(
                            rent.rentDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces))).Days;

            rent.items
            .ToList()
            .ForEach(item =>
            {
                rent.fullPrice += (item.laptop.DailyPrice * item.quantity * daysAmount);
            });


            return rent;
        }
    }
}