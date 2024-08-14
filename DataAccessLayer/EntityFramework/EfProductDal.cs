using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;

public class EfProductDal : GenericRepository<Product>, IProductDal
{
    private readonly Context _context;

    public EfProductDal()
    {
    }

    public EfProductDal(Context context)
    {
        _context = context;
    }

    // Ürünleri Url göre listeleme
    public Product Get(Func<Product, bool> filter)
    {
        return _context.Set<Product>().FirstOrDefault(filter);
    }


    public IEnumerable<Product> GetAll()
    {
        return _context.Products.ToList();
    }
}
