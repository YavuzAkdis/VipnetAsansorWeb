using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Abstract;
using System.Linq;

namespace Vipnet_Asansor.ViewComponents
{
    public class ReferenceList : ViewComponent
    {
        private readonly IReferenceService _referenceService;

        public ReferenceList(IReferenceService referenceService)
        {
            _referenceService = referenceService;
        }

        public IViewComponentResult Invoke()
        {
            var references = _referenceService.TGetList(); // veya uygun bir metod
            return View(references);
        }
    }
}
