using CubeSummation.Models;
using CubeSummation.Services;
using System.Web.Mvc;

namespace CubeSummation.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ExecuteTestCase(ExecuteTestCaseModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            try
            {
                IOperationCreator creator = new OperationCreator();
                ITestCaseService service = new TestCaseService(creator);
                var result = service.Execute(model.Content);

                TestCaseResultModel resultModel = new TestCaseResultModel()
                {
                    Conten = model.Content,
                    Result = result
                };

                return View("Result", resultModel);
            }
            catch
            {
                return View("Error");
            }
        }
    }
}