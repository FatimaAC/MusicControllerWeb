using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicController.BL.OutletServices;
using MusicController.DTO.APiResponesClass;
using MusicController.DTOModel.DTOS;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicController.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OutletsController : ControllerBase
    {
        private readonly IOutletService _outletService;
        private readonly IMapper _mapper;
        public OutletsController(IOutletService outletService, IMapper mapper)
        {
            _outletService = outletService;
            _mapper = mapper;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<Response<List<OutletNameDTO>>> GetOutles()
        {
            var outlets = await _outletService.GetAllOutlets();
            var outletDTO = _mapper.Map<List<OutletNameDTO>>(outlets);
            var response = new Response<List<OutletNameDTO>>(outletDTO);
            return response;
        }
    }
}
