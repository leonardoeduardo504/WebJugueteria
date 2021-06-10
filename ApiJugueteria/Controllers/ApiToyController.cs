using ApiJugueteria.Models;
using ApiJugueteria.Repository;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;

namespace ApiJugueteria.Controllers
{
    public class ApiToyController : ApiController
    {
        private readonly IToyRepository _repository;
        public ApiToyController(IToyRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public JsonResult<List<Toy>> GetAll()
        {                        
            var items = _repository.GetAllToy();
            return Json<List<Toy>>(items);
        }

        [HttpGet]
        public JsonResult<Toy> Get(int id)
        {
            var item = _repository.GetToyById(id);
            return Json<Toy>(item);
        }

        [HttpPost]
        public bool Create(Toy toy)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                _repository.CreateToy(toy);
                status = true;
            }
            return status;
        }

        [HttpPut]
        public bool Update(Toy toy)
        {
            bool status = false;
            _repository.UpdateToy(toy);
            status = true;
            return status;
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            bool status = false;
            _repository.DeleteToy(id);
            status = true;
            return status;
        }
    }
}
