using Microsoft.AspNetCore.Mvc;
using System;
using ApiEscolaridade.Data.Collections;
using ApiEscolaridade.Models;
using MongoDB.Driver;

namespace ApiEscolaridade.Controllers
{
    [ApiController]
    [Route("controller")]
    public class ClientsController : ControllerBase
    {
        Data.MongoDB _mongoDB;
        IMongoCollection<Client> _clientCollection;

        public ClientsController(Data.MongoDB mongoDB)
        {
            _mongoDB = mongoDB;
            _clientCollection = _mongoDB.DB.GetCollection<Client>(typeof(Client).Name.ToLower());
        }

        [HttpPost]
        public ActionResult AddClient([FromBody] ClientDTO dto)
        {
            var client = new Client(dto.Id, dto.BirthYear, dto.Gender, dto.EducLevel, dto.BasicGradYear);

            _clientCollection.InsertOne(client);
            
            return StatusCode(201, "CLIENT ADDED SUCCESSFULLY");
        }

        [HttpGet]

        public ActionResult GetClient()
        {
            var client = _clientCollection.Find(Builders<Client>.Filter.Empty).ToList();
            
            return Ok(client);
        }

        [HttpPatch]
        public ActionResult UpdateClient([FromBody] ClientDTO dto)
        {
            _clientCollection.UpdateOne(Builders<Client>.Filter.Where(_ => _.Id == dto.Id), Builders<Client>.Update.Set("gender", dto.Gender));
            
            return Ok("PERSON DATA UPDATED SUCCESSFULLY");
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteClient(int id)
        {
            _clientCollection.DeleteOne(Builders<Client>.Filter.Where(_ => _.Id == id));
                        
            return Ok("PERSON REMOVED SUCCESSFULLY");
        }
    }
}