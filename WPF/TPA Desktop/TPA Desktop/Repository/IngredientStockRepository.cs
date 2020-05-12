using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Mediator;
using TPA_Desktop.Model;

namespace TPA_Desktop.Repository
{
    class IngredientStockRepository
    {
        public List<Ingredient> getAllIngredientStock()
        {
            Connection con = Connection.getConnection();
            return con.db.Ingredient.ToList();
        }
    }
}
