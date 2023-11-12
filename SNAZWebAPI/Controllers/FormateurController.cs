using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SNAZWebAPI.data;
using SNAZWebAPI.Models.Domian;
using SNAZWebAPI.Models.DTO;

namespace SNAZWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormateurController : ControllerBase
    {
        private readonly _DbContext _Dbcontext;

        public FormateurController(_DbContext _DbContext) 
        {
            this._Dbcontext = _DbContext;
        }

        [HttpGet]
        public IActionResult GetAllFormateur()
        {
            var allFormateur = _Dbcontext.Formateurs.Select(x => new { x.FormateurId, x.Name, x.Adrress,Group= new {x.Group.Name,x.Group.GroupId }  }).ToList();
            return Ok(allFormateur);
        }

        [HttpPost]
        public IActionResult addFormateur([FromBody]FormateurDTO formateurDTO)
        {

            Formateur formateur = new Formateur
            {
                FormateurId = Guid.NewGuid(),
                Name=formateurDTO.Name,
                Adrress=formateurDTO.Adrress,
                GroupId=formateurDTO.GroupId
            };

            _Dbcontext.Formateurs.Add(formateur);
            _Dbcontext.SaveChanges();
            var allFormateur = _Dbcontext.Formateurs.Select(x => new { x.FormateurId, x.Name, x.Adrress, Group = new { x.Group.Name, x.Group.GroupId } }).ToList();
            return Ok(allFormateur);
        }

        [HttpDelete]
        [Route ("{id:Guid}")]

        public IActionResult DeleteFormateur([FromRoute]Guid id)
        {

            Formateur formateur =_Dbcontext.Formateurs.Find(id);

            _Dbcontext.Formateurs.Remove(formateur);
            _Dbcontext.SaveChanges();
            // pour affiche all Formateurs 
            var allFormateur = _Dbcontext.Formateurs.Select(x => new { x.FormateurId, x.Name, x.Adrress, Group = new { x.Group.Name, x.Group.GroupId } }).ToList();
            return Ok(allFormateur);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult UpdateFromateurs(Guid id , [FromBody]FormateurDTO formateurDto)
        {
            Formateur formateur = _Dbcontext.Formateurs.Find(id);
            formateur.Name= formateurDto.Name;
            formateur.Adrress= formateurDto.Adrress;
            formateur.GroupId= formateurDto.GroupId;
            _Dbcontext.SaveChanges();

            // pour affiche all Formateurs 
            var allFormateur = _Dbcontext.Formateurs.Select(x => new { x.FormateurId, x.Name, x.Adrress, Group = new { x.Group.Name, x.Group.GroupId } }).ToList();
            return Ok(allFormateur);
        }


    }
}