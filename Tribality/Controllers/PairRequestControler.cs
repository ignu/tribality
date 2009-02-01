using System.Web.Mvc;
using Tribality.Repository;

namespace Tribality.Controllers
{
    public class PairRequestControler : ControllerBase
    {
        private IPairRequestRepository pairRequestRepository1;

        public PairRequestControler(IPairRequestRepository pairRequestRepository1)
        {
            this.pairRequestRepository1 = pairRequestRepository1;
        }

        public ViewResult List(int pageNumber)
        {
            return View(pairRequestRepository1.GetAll());
        }

        
    }
}