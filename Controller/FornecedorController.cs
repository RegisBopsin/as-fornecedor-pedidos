using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[ApiController]
[Route("api/[controller]")]
public class FornecedorController : ControllerBase{
    private readonly IFornecedorRepository _fornecedorRepository;

    public FornecedorController(IFornecedorRepository fornecedorRepository)
    {
        _fornecedorRepository = fornecedorRepository;
    }



    [HttpGet]

    public ActionResult<IEnumerable<Fornecedor>> GetAll()
    {
        var fornecedores = _fornecedorRepository.GetAll(); 
        return Ok(fornecedores);
    }



    [HttpGet("{id}")]

    public ActionResult<Fornecedor> GetById(int id)
    {
        var fornecedor = _fornecedorRepository.GetById(id); 

        if (fornecedor == null)
            return NotFound();
        return Ok(fornecedor);
    }



    [HttpPost]

    public ActionResult Create(Fornecedor fornecedor)
    {
        _fornecedorRepository.Add(fornecedor); 
        return CreatedAtAction(nameof(GetById), new { id = fornecedor.Id }, fornecedor);
    }



    [HttpPut("{id}")]

    public ActionResult Update(int id, Fornecedor fornecedor)
    {
        if (id != fornecedor.Id)
            return BadRequest("Id não encontrado!!!");
        _fornecedorRepository.Update(fornecedor); 
        return NoContent();
    }



    [HttpDelete("{id}")]

    public ActionResult Delete(int id)
    {
        var fornecedor = _fornecedorRepository.GetById(id); 

        if (fornecedor == null)
            return NotFound();
        _fornecedorRepository.Delete(id); 
        return NoContent();
    }
}