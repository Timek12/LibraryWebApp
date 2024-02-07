using LibraryWeb.DataAccess.Repository.IRepository;
using LibraryWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace LibraryWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            List<Product> productsList = _unitOfWork.Product.GetAll().ToList();
            return View(productsList);
        }



    }
}
