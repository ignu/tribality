using System;
using System.Web.Mvc;
using Tribality.Models;
using Tribality.Repository;
using Tribality.Services;

namespace Tribality.Controllers
{
    public interface IPairRequestController
    {
        ViewResult List(int? pageNumber);
    }

    public class PairRequestController : ControllerBase, IPairRequestController
    {
        private IPairRequestRepository pairRequestRepository;
        public const int PAGE_SIZE = 20;

        public PairRequestController(IPairRequestRepository pairRequestRepository1)
        {
            this.pairRequestRepository = pairRequestRepository1;
        }

        public PairRequestController()
        {
            this.pairRequestRepository = Container.Resolve<IPairRequestRepository>();
        }

        public ViewResult List(int? pageNumber)
        {
            int firstPage = pageNumber ?? 1;
            return View(pairRequestRepository.GetPage(firstPage, PAGE_SIZE));
        }

        public string Save(PairRequest pairRequest)
        {
            pairRequestRepository.Save(pairRequest);
            return "Pair Request Saved.";
        }
    }
}