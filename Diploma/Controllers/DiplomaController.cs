using Diploma.BLL;
using Microsoft.AspNetCore.Mvc;

namespace Diploma.Controllers;

public class DiplomaController: Controller
{
    public readonly IDiplomaBLL _DiplomaBll;


    public DiplomaController(IDiplomaBLL diplomaBll)
    {
        _DiplomaBll = diplomaBll;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        await _DiplomaBll.DiplomaGeneration();
        return View();
        
    }
}