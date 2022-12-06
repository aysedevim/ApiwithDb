using ApiwithDb.Data;
using ApiwithDb.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiwithDb.Controllers
{
    [Route("/[controller]/[action]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        MyContext _db;
        Response _response;
        public CityController(MyContext db, Response response)
        {
            _db = db;
            _response = response;
        }
        [HttpGet]
        public List<City> GetCities()
        {
            return _db.Set<City>().ToList();
        }
        [HttpGet("{id:int}")]
        public City GetCity(int Id)
        {
            return _db.Set<City>().Find(Id);
        }

        [HttpPost]
        public Response Add(City city)
        {
            try
            {
                _db.Set<City>().Add(city);
                _db.SaveChanges();
                _response.Error = false;
                _response.Msg = $"{city.Name} Başarılı Şekilde Eklendi";
                
            }
            catch (Exception ex)
            {
                _response.Error = true;
                _response.Msg = ex.Message;

            }
            return _response;
        }

        [HttpPut] //post eder.
        public Response Update(City city)
        {
            try
            {
                _db.Set<City>().Update(city);
                _db.SaveChanges();
                _response.Error = false;
                _response.Msg = $"{city.Name} Başarılı Şekilde Güncellendi";
              
            }
            catch (Exception ex)
            {
                _response.Error = true;
                _response.Msg = ex.Message;

            }
            return _response;
        }


        [HttpDelete] 
        public Response Delete(City city)
        {
            try
            {
                _db.Set<City>().Remove(city);
                _db.SaveChanges();
                _response.Error = false;
                _response.Msg = $"{city.Name} Başarılı Şekilde Silindi";
                
            }
            catch (Exception ex)
            {
                _response.Error = true;
                _response.Msg = ex.Message;

            }
            return _response;
        }

        [HttpDelete("{id:int}")]
        public Response DeleteById(int id)
        {
            return Delete(GetCity(id));
        }

    }
}
