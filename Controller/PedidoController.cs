using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PedidoController : ControllerBase{
    private readonly IPedidoRepository _pedidoRepository;

    public PedidoController(IPedidoRepository pedidoRepository)
    {
        _pedidoRepository = pedidoRepository;
    }



    [HttpGet]

    public ActionResult<IEnumerable<Pedido>> GetAll()
    {
        var pedidos = _pedidoRepository.GetAll(); 
        return Ok(pedidos);
    }



    [HttpGet("{id}")]

    public ActionResult<Pedido> GetById(int id)
    {
        var pedido = _pedidoRepository.GetById(id); 

        if (pedido == null)
            return NotFound();
        return Ok(pedido);
    }



    [HttpPost]

    public ActionResult Create(Pedido pedido)
    {
        _pedidoRepository.Add(pedido); 
        return CreatedAtAction(nameof(GetById), new { id = pedido.Id }, pedido);
    }



    [HttpPut("{id}")]

    public ActionResult Update(int id, Pedido pedido)
    {
        if (id != pedido.Id)
            return BadRequest("Id não encontrado!!");
        _pedidoRepository.Update(pedido); 
        return NoContent();
    }



    [HttpDelete("{id}")]

    public ActionResult Delete(int id)
    {
        var pedido = _pedidoRepository.GetById(id); 

        if (pedido == null)
            return NotFound();
        _pedidoRepository.Delete(id); 
        return NoContent();
    }
}