using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.OleDb;

namespace BL
{
    public class Copys
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JRosasPublicisGroupContext context = new DL.JRosasPublicisGroupContext())
                {
                    var query = context.Copys.FromSqlRaw($"copysGetAll").ToList();
                    result.Objects = new List<object>();
                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Copys copys = new ML.Copys();
                            copys.Id = obj.Id;
                            copys.Medio = obj.Medio;
                            copys.Fecha = obj.Fecha.Value.ToString("dd-MM-yyyy");
                            copys.Marca = obj.Marca;
                            copys.Producto = obj.Producto;
                            copys.Version = obj.Version;
                            copys.Vehiculo = obj.Vehiculo;
                            copys.Anunciante = obj.Anunciante;
                            copys.Tema = obj.Tema;

                            copys.Categories = new ML.Categories();
                            copys.Categories.Id = obj.IdCategory.Value; 
                            copys.Categories.Name = obj.CategoryName;

                            copys.Processing = (bool)obj.Processing;
                            copys.File = obj.File;

                            result.Objects.Add(copys);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "NO SE ENCONTRARON REGISTROS EN LA BASE DE DATOS";
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

        public static ML.Result GetById (int Id)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JRosasPublicisGroupContext context = new DL.JRosasPublicisGroupContext())
                {
                    var query = context.Copys.FromSqlRaw($"copysGetById {Id}").AsEnumerable().FirstOrDefault();
                    result.Objects = new List<object>();
                    if (query != null)
                    {
                        ML.Copys copys = new ML.Copys();
                        copys.Id = query.Id;
                        copys.Medio = query.Medio;
                        copys.Fecha = query.Fecha.Value.ToString("dd/MM/yyyy");
                        copys.Marca = query.Marca;
                        copys.Producto = query.Producto;
                        copys.Version = query.Version;
                        copys.Vehiculo = query.Vehiculo;
                        copys.Anunciante = query.Anunciante;
                        copys.Tema = query.Tema;

                        copys.Categories = new ML.Categories();
                        copys.Categories.Id = query.IdCategory.Value;
                        copys.Categories.Name = query.CategoryName;

                        copys.Processing = (bool)query.Processing;
                        copys.File = query.File;

                        result.Object = copys;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "OCURRIO UN PROBLEMA AL TRAER LA INFORMACION";
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

        public static ML.Result Add(ML.Copys copys)
        {
            copys.Processing = true;
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JRosasPublicisGroupContext context = new DL.JRosasPublicisGroupContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"copysAdd {copys.Id},'{copys.Medio}','{copys.Fecha}'," +
                        $"'{copys.Marca}','{copys.Producto}','{copys.Version}','{copys.Vehiculo}','{copys.Anunciante}'," +
                        $"'{copys.Tema}',{copys.Categories.Id}, {copys.Processing},'{copys.File}'");

                    if (query >=1 )
                    {
                        result.Correct=true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "NO SE INSERTO EL REGISTRO";
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result Update(ML.Copys copys)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JRosasPublicisGroupContext context = new DL.JRosasPublicisGroupContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"copysUpdate {copys.Id},'{copys.Medio}','{copys.Fecha}'," +
                        $"'{copys.Marca}','{copys.Producto}','{copys.Version}','{copys.Vehiculo}','{copys.Anunciante}'," +
                        $"'{copys.Tema}',{copys.Categories.Id},{copys.Processing},'{copys.File}'");

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "NO SE ACTUALIZO EL REGISTRO";
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result Delete(ML.Copys copys)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JRosasPublicisGroupContext context = new DL.JRosasPublicisGroupContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"copysDelete {copys.Id}");

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "NO SE ELIMINO EL REGISTRO";
                    }
                    result.Correct = true;
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