// using System.Collections.Generic;
// using System.Threading.Tasks;
// using laptop_rental.Models;
// using laptoprental.Data;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;

// namespace laptop_rental.Controllers
// {
//     public class CartService
//     {
//         private DataContext _context;

//         public CartService(DataContext context)
//         {
//             _context = context;
//         }
//         public async Task<ActionResult<List<Cart>>> getAll([FromServices] DataContext context)
//         {
//             return await context.Carts.Include(cart => cart.laptop).Include(cart => cart.order).ToListAsync();
//         }
//         public async Task<ActionResult<Cart>> getByOrder([FromServices] DataContext context, int id)
//         {
//             return await context.Carts
//             .Include(cart => cart.laptop)
//             .Include(cart => cart.order)
//             .AsNoTracking()
//             .FirstOrDefaultAsync(cart => cart.order.Id == id);

//         }

//         [HttpPost]
//         public async Task<ActionResult<Laptop>> Post(
//             [FromServices] DataContext context,
//             [FromBody] Laptop laptop)
//         {
//             if (ModelState.IsValid)
//             {
//                 context.Laptops.Add(laptop);
//                 await context.SaveChangesAsync();
//                 return laptop;
//             }
//             else
//             {
//                 return BadRequest(ModelState);
//             }
//         }


//     }
// }