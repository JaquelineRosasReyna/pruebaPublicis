using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Categories
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JRosasPublicisGroupContext contex = new DL.JRosasPublicisGroupContext())
                {
                    var query = contex.Categories.FromSqlRaw($"CategoriesGetAll").ToList();
                    result.Objects = new List<object>();
                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Categories categories = new ML.Categories();

                            categories.Id = obj.Id;
                            categories.Ref_id = obj.Id;
                            categories.Name = obj.Name;
                            categories.Alias = obj.Alias;

                            result.Objects.Add(obj);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "NO SE ENCONTRARON REGISTROS";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }
}
