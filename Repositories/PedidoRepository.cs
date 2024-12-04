using Microsoft.EntityFrameworkCore;
public class PedidoRepository : IPedidoRepository{
    private readonly AppDbContext _context;
    public PedidoRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public IEnumerable<Pedido> GetAll()
    {
        return _context.Pedidos.ToList();
    }
    
    public Pedido? GetById(int id)
    {
        return _context.Pedidos.Find(id);
    }
    
    public void Add(Pedido pedido)
    {
        _context.Pedidos.Add(pedido);
        _context.SaveChanges();
    }
    
    public void Update(Pedido pedido)
    {
        _context.Pedidos.Update(pedido);
        _context.SaveChanges();
    }
    
    public void Delete(int id)
    {
        var pedido = GetById(id);
        if (pedido != null)
        {
            _context.Pedidos.Remove(pedido);
            _context.SaveChanges();
        }
    }
}