using DentOffice.WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentOffice.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecommenderController : ControllerBase
    {
        private readonly IRecommenderService _recommenderService;
        public RecommenderController(IRecommenderService recommenderService)
        {
            _recommenderService = recommenderService;
        }

        [HttpGet("{stomatologID}")]
        public List<Model.Korisnik> GetRecommendedStomatolog(int stomatologID)
        {
            return _recommenderService.GetRecommendedStomatolog(stomatologID);
        }
    }
}
