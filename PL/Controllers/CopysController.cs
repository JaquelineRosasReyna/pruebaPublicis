using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class CopysController : Controller
    {
        public ActionResult GetAll()
        {
            ML.Copys copys = new ML.Copys();
            ML.Result result = BL.Copys.GetAll();

            if (result.Correct)
            {
                copys.Copies = result.Objects.ToList();
                return View(copys);
            }
            else
            {
                ViewBag.Message = "OCURRIO UN ERROR AL OBTENER LA INFORMACIÓN " + result.ErrorMessage;
                return PartialView("Modal");
            }
;
        }

        [HttpGet]
        public ActionResult Form(int Id)
        {
            ML.Copys copys = new ML.Copys();
            ML.Result resultcategory = BL.Categories.GetAll();

            copys.Categories = new ML.Categories();
            copys.Categories.categories = resultcategory.Objects.ToList();

            if (Id == 0)
            {
                copys.Action = "Add";
                return View(copys);
            }
            else
            {
                copys.Action = "Update";
                ML.Result result = BL.Copys.GetById(Id);
                if (result.Correct)
                {
                    copys = (ML.Copys)result.Object;
                    copys.Categories.categories = resultcategory.Objects.ToList();
                    return View(copys);
                }
                return View();
            }
        }
        [HttpPost]
        public ActionResult Form (ML.Copys copys)
        {
            IFormFile file = Request.Form.Files["IFImagen"];

           
            if (file != null)
            {
                byte[] ImagenBytes = ConvertToBytes(file);
                copys.File = Convert.ToBase64String(ImagenBytes);
            }
            if (copys.Action == "Add")
            {
                ML.Result result = BL.Copys.Add(copys);
                if (result.Correct)
                {
                    ViewBag.Message = "SE INSERTO CORRECTAMENTE ";
                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Message = "OCURRIO UN ERROR AL INSERTAR " + result.ErrorMessage;
                    return PartialView("Modal");
                }
            }
            else
            {
                ML.Result result = BL.Copys.Update(copys);
                if (result.Correct)
                {
                    ViewBag.Message = "SE ACTUALIZO CORRECTAMENTE ";
                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Message = "OCURRIO UN ERROR AL ACTUALIZAR " + result.ErrorMessage;
                    return PartialView("Modal");
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Delete(int Id)
        {
            ML.Result resultcopys = new ML.Result();
            ML.Copys copys = new ML.Copys();
            copys.Id = Id;
            var result = BL.Copys.Delete(copys);

            if (result.Correct)
            {
                ViewBag.Message = "SE ELIMINIO CORRECTAMENTE EL REGISTRO";
            }
            else
            {
                ViewBag.Message = "OCURRIO UN PROBLEMA AL ELIMINAR EL USUSARIO " + result.ErrorMessage;
            }
            return PartialView("Modal");
        }
        public static byte[] ConvertToBytes(IFormFile imagen)
        {

            using var fileStream = imagen.OpenReadStream();

            byte[] bytes = new byte[fileStream.Length];
            fileStream.Read(bytes, 0, (int)fileStream.Length);

            return bytes;
        }
    }
}
